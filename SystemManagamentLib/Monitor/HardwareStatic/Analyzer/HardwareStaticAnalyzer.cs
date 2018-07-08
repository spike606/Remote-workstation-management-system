using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;

namespace SystemManagament.Monitor.HardwareStatic.Analyzer
{
    public class HardwareStaticAnalyzer : IHardwareStaticAnalyzer
    {
        private const int BLOCK_SIZE = 12;
        private const int BLOCKS_IN_VENDOR_ARRAY = 41;
        private const int ARIBUTE_ID_OFFSET = 2;
        private const int VALUE_OFFSET = 5;
        private const int WORST_OFFSET = 6;
        private const int RAW_OFFSET_LSB = 7;
        private const int THRESHOLD_OFFSET = 3;
        private const string EXTENDED_PARTITION_MBR_TYPE = "15";

        public List<SMARTData> GetSmartData(
            List<SmartFailurePredictStatus> smartFailurePredictStatuses,
            List<SmartFailurePredictData> smartFailurePredictDatas,
            List<SmartFailurePredictThresholds> smartFailurePredictThresholds)
        {
            List<SMARTData> smartDataList = new List<SMARTData>();

            this.ExtractFailurePredictStatus(smartDataList, smartFailurePredictStatuses);
            this.ExtractFailurePredictData(smartDataList, smartFailurePredictDatas);
            this.ExtractFailrePredictThresholds(smartDataList, smartFailurePredictThresholds);

            this.SetSmartAttributesStatusBasedOnThresholdValues(smartDataList);

            return smartDataList;
        }

        public List<Storage> GetStorageData(
            List<Disk> disks,
            List<DiskPartition> diskPartitions,
            List<Volume> volumes,
            List<DiskToPartition> disksToPartitions,
            List<PartitionToVolume> partitionsToVolumes,
            List<SMARTData> smartData)
        {
            List<Storage> storageData = new List<Storage>();

            foreach (var disk in disks)
            {
                Storage storage = new Storage()
                {
                    Disk = disk,
                    Partition = new List<Partition>(),
                    ExtendedPartition = new List<Partition>(),
                    Volume = new List<Volume>()
                };

                storageData.Add(storage);
            }

            this.ExtractPartitionsForStorage(storageData, disksToPartitions, diskPartitions, partitionsToVolumes, volumes);

            this.MatchPartitionsToExtendedPartitions(storageData);

            this.MatchSmartDataForStorage(storageData, smartData);

            return storageData;
        }

        private void ExtractFailurePredictStatus(List<SMARTData> smartDataList, List<SmartFailurePredictStatus> smartFailurePredictStatuses)
        {
            foreach (var smartFailurePredictStatus in smartFailurePredictStatuses)
            {
                smartDataList.Add(new SMARTData
                {
                    InstanceName = smartFailurePredictStatus.InstanceName,
                    PredictFailure = smartFailurePredictStatus.PredictFailure
                });
            }
        }

        private void ExtractFailurePredictData(List<SMARTData> smartDataList, List<SmartFailurePredictData> smartFailurePredictDatas)
        {
            foreach (var smartFailurePredictData in smartFailurePredictDatas)
            {
                for (int i = 0; i < BLOCKS_IN_VENDOR_ARRAY; ++i)
                {
                    int currentBlock = i * BLOCK_SIZE;

                    int attributeId = smartFailurePredictData.VendorSpecific[currentBlock + ARIBUTE_ID_OFFSET];
                    int value = smartFailurePredictData.VendorSpecific[currentBlock + VALUE_OFFSET];
                    int worst = smartFailurePredictData.VendorSpecific[currentBlock + WORST_OFFSET];
                    int rawData = BitConverter.ToInt32(smartFailurePredictData.VendorSpecific, currentBlock + RAW_OFFSET_LSB);
                    if (attributeId == 0)
                    {
                        continue;
                    }

                    SMARTData smartData = smartDataList.Where(x => x.InstanceName == smartFailurePredictData.InstanceName).FirstOrDefault();
                    if (smartData == null)
                    {
                        continue;
                    }

                    KeyValuePair<int, SmartDataAttribute> currentAttributeFromDictionary = SmartAttributesDictionary.Attributes.Where(x => x.Key == attributeId).FirstOrDefault();
                    if (currentAttributeFromDictionary.Equals(default(KeyValuePair<int, SmartDataAttribute>)))
                    {
                        continue;
                    }

                    smartData.Attributes.Add(currentAttributeFromDictionary.Key, currentAttributeFromDictionary.Value);
                    var currentAttribute = smartData.Attributes[currentAttributeFromDictionary.Key];
                    currentAttribute.Current = value;
                    currentAttribute.Worst = worst;
                    currentAttribute.Raw = rawData;
                }
            }
        }

        private void ExtractFailrePredictThresholds(List<SMARTData> smartDataList, List<SmartFailurePredictThresholds> smartFailurePredictThresholds)
        {
            foreach (var smartFailurePredictThreshold in smartFailurePredictThresholds)
            {
                byte[] bytes = smartFailurePredictThreshold.VendorSpecific;
                for (int i = 0; i < BLOCKS_IN_VENDOR_ARRAY; ++i)
                {
                    int currentBlock = i * BLOCK_SIZE;

                    int attributeId = bytes[currentBlock + ARIBUTE_ID_OFFSET];
                    int threshold = bytes[currentBlock + THRESHOLD_OFFSET];
                    if (attributeId == 0)
                    {
                        continue;
                    }

                    SMARTData smartData = smartDataList.Where(x => x.InstanceName == smartFailurePredictThreshold.InstanceName).FirstOrDefault();
                    if (smartData == null)
                    {
                        continue;
                    }

                    SmartDataAttribute attribute = smartData.Attributes[attributeId];
                    attribute.Threshold = threshold;
                }
            }
        }

        private void SetSmartAttributesStatusBasedOnThresholdValues(List<SMARTData> smartDataList)
        {
            foreach (var smartData in smartDataList)
            {
                foreach (var attribute in smartData.Attributes)
                {
                    if (attribute.Value.Threshold.Equals(0))
                    {
                        attribute.Value.Status = SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED;
                    }
                    else if (attribute.Value.Worst > attribute.Value.Threshold)
                    {
                        attribute.Value.Status = SmartDataAttributeStatusEnum.OK_THRESHOLD_NOT_REACHED;
                    }
                    else if (attribute.Value.Worst <= attribute.Value.Threshold)
                    {
                        if (attribute.Value.IsCriticalAttribute)
                        {
                            attribute.Value.Status = SmartDataAttributeStatusEnum.FAILED_CRITICAL;
                        }
                        else
                        {
                            attribute.Value.Status = SmartDataAttributeStatusEnum.FAILED;
                        }
                    }
                }
            }
        }

        private void ExtractPartitionsForStorage(List<Storage> storageData, List<DiskToPartition> disksToPartitions, List<DiskPartition> diskPartitions, List<PartitionToVolume> partitionsToVolumes, List<Volume> volumes)
        {
            foreach (var diskToPartitionAssociation in disksToPartitions)
            {
                string substringBeginning = "objectid";

                string diskAssociationLower = diskToPartitionAssociation.Disk.ToLower();
                string diskAssociationLowerSubstring = diskAssociationLower
                    .Substring(diskAssociationLower.IndexOf(substringBeginning) + substringBeginning.Length);
                string preparedDiskAssociation = Regex.Unescape(diskAssociationLowerSubstring);

                string partitionAssociationLower = diskToPartitionAssociation.Partition.ToLower();
                string partitionAssociationLowerSubstring = partitionAssociationLower
                    .Substring(partitionAssociationLower.IndexOf(substringBeginning) + substringBeginning.Length);
                string preparedPartitionAssociation = Regex.Unescape(partitionAssociationLowerSubstring);

                Storage currentStorage = storageData.First(x => preparedDiskAssociation.Contains(x.Disk.ObjectId.ToLower()));

                foreach (var currentPartition in diskPartitions)
                {
                    if (preparedPartitionAssociation.Contains(currentPartition.ObjectId.ToLower()))
                    {
                        var currentPartitionToVolume = partitionsToVolumes
                            .FirstOrDefault(x => x.Partition.ToLower() == partitionAssociationLower);

                        if (currentPartitionToVolume != null)
                        {
                            this.AddVolumeToStorage(currentStorage, volumes, substringBeginning, currentPartitionToVolume);
                            this.AddPartitionToStorage(currentStorage, currentPartition, false);
                        }
                        else if (currentPartitionToVolume == null && currentPartition.MbrType == EXTENDED_PARTITION_MBR_TYPE)
                        {
                            this.AddPartitionToStorage(currentStorage, currentPartition, true);
                        }
                    }
                }
            }
        }

        private void AddVolumeToStorage(Storage currentStorage, List<Volume> volumes, string substringBeginning, PartitionToVolume currentPartitionToVolume)
        {
            string volumeAssociationLower = currentPartitionToVolume.Volume.ToLower();
            string volumeAssociationLowerSubstring = volumeAssociationLower
                .Substring(volumeAssociationLower.IndexOf(substringBeginning) + substringBeginning.Length);
            string preparedVolumeAssociation = Regex.Unescape(volumeAssociationLowerSubstring);

            var currentVolume = volumes.First(x => preparedVolumeAssociation
                .Contains(x.ObjectId.ToLower()));

            currentStorage.Volume.Add(currentVolume);
        }

        private void AddPartitionToStorage(Storage currentStorage, DiskPartition currentPartition, bool isExtendedPartition)
        {
            Partition partition = new Partition()
            {
                DiskId = currentPartition.DiskId,
                DiskNumber = currentPartition.DiskNumber,
                DriveLetter = currentPartition.DriveLetter,
                IsActive = currentPartition.IsActive,
                IsBoot = currentPartition.IsBoot,
                IsHidden = currentPartition.IsHidden,
                IsOffline = currentPartition.IsOffline,
                IsReadOnly = currentPartition.IsReadOnly,
                IsShadowCopy = currentPartition.IsShadowCopy,
                IsSystem = currentPartition.IsSystem,
                MbrType = currentPartition.MbrType,
                GptType = currentPartition.GptType,
                NoDefaultDriveLetter = currentPartition.NoDefaultDriveLetter,
                ObjectIdAsPartition = currentPartition.ObjectId,
                Offset = currentPartition.Offset,
                PartitionNumber = currentPartition.PartitionNumber,
                SizeAsPartition = currentPartition.Size,
            };

            if (isExtendedPartition)
            {
                currentStorage.ExtendedPartition.Add(partition);
            }
            else
            {
                currentStorage.Partition.Add(partition);
            }
        }

        private void MatchPartitionsToExtendedPartitions(List<Storage> storageData)
        {
            foreach (var storage in storageData)
            {
                var extendedPartitionsForStorage = storage.ExtendedPartition.ToList();

                foreach (var extendedPartition in extendedPartitionsForStorage)
                {
                    var lowerRangeForExtendedPartition = extendedPartition.Offset.Value;
                    var upperRangeForExtendedPartition = lowerRangeForExtendedPartition + extendedPartition.SizeAsPartition.Value;

                    if (lowerRangeForExtendedPartition == null || upperRangeForExtendedPartition == null)
                    {
                        continue;
                    }

                    var partitionsOnDisk = storage.Partition
                        .Where(x => !extendedPartitionsForStorage.Any(y => y.PartitionNumber == x.PartitionNumber)).ToList();

                    foreach (var partition in partitionsOnDisk)
                    {
                        var lowerRange = partition.Offset.Value;
                        var upperRange = lowerRange + partition.SizeAsPartition.Value;

                        if (lowerRange == null || upperRange == null)
                        {
                            continue;
                        }

                        if (lowerRange >= lowerRangeForExtendedPartition && upperRange <= upperRangeForExtendedPartition)
                        {
                            extendedPartition.Partitions.Add(partition);

                            storage.Partition.Remove(partition);
                        }
                    }
                }
            }
        }

        private void MatchSmartDataForStorage(List<Storage> storageData, List<SMARTData> smartData)
        {
            foreach (var smart in smartData)
            {
                foreach (var storage in storageData)
                {
                    string diskUniqueIdLower = storage.Disk.UniqueId.ToLower();
                    string diskUniqueIdLowerSubstring = diskUniqueIdLower.Substring(0, diskUniqueIdLower.LastIndexOf(":"));

                    if (smart.InstanceName.ToLower().Contains(diskUniqueIdLowerSubstring))
                    {
                        storage.SMARTData = smart;
                        break;
                    }
                }
            }
        }
    }
}
