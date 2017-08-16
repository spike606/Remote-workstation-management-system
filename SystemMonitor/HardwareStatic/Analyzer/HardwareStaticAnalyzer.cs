using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Analyzed;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;

namespace SystemMonitor.HardwareStatic.Analyzer
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

        public List<SMARTData> GetSmartData(
            List<SmartFailurePredictStatus> smartFailurePredictStatus,
            List<SmartFailurePredictData> smartFailurePredictData,
            List<SmartFailurePredictThresholds> smartFailurePredictThresholds)
        {
            List<SMARTData> smartData = new List<SMARTData>();

            this.ExtractFailurePredictStatus(smartData, smartFailurePredictStatus);
            this.ExtractFailurePredictData(smartData, smartFailurePredictData);
            this.ExtractFailrePredictThresholds(smartData, smartFailurePredictThresholds);

            this.SetSmartAttributesStatusBasedOnThresholdValues(smartData);

            foreach (var data in smartData)
            {
                Console.WriteLine("ID                   Current  Worst  Threshold  Data  Status");
                foreach (var attr in data.Attributes)
                {
                    Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}\t {5}\t", attr.Value.AttributeName, attr.Value.Current, attr.Value.Worst, attr.Value.Threshold, attr.Value.Raw, attr.Value.Status);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            return smartData;
        }

        public List<Storage> GetStorageData(
            List<Disk> disks,
            List<DiskPartition> diskPartition,
            List<Volume> volume,
            List<DiskToPartition> diskToPartition,
            List<PartitionToVolume> partitionToVolume)
        {
            List<Storage> storageData = new List<Storage>();

            foreach (var disk in disks)
            {
                storageData.Add(new Storage((Disk)disk));
            }

            this.ExtractPartitionsForStorage(storageData, diskToPartition, diskPartition, partitionToVolume, volume);

            this.MatchLogicalPartitionsToExtendedPartitions(storageData);

            return storageData;
        }

        private void ExtractFailurePredictStatus(List<SMARTData> smartData, List<SmartFailurePredictStatus> smartFailurePredictStatus)
        {
            List<SmartFailurePredictStatus> smartFailurePredictStatusList = smartFailurePredictStatus.Cast<SmartFailurePredictStatus>().ToList();

            foreach (var driveData in smartFailurePredictStatusList)
            {
                smartData.Add(new SMARTData
                {
                    InstanceName = driveData.InstanceName,
                    PredictFailure = driveData.PredictFailure
                });
            }
        }

        private void ExtractFailurePredictData(List<SMARTData> smartData, List<SmartFailurePredictData> smartFailurePredictData)
        {
            foreach (var driveData in smartFailurePredictData)
            {
                for (int i = 0; i < BLOCKS_IN_VENDOR_ARRAY; ++i)
                {
                    int currentBlock = i * BLOCK_SIZE;
                    try
                    {
                        int attributeId = driveData.VendorSpecific[currentBlock + ARIBUTE_ID_OFFSET];
                        int value = driveData.VendorSpecific[currentBlock + VALUE_OFFSET];
                        int worst = driveData.VendorSpecific[currentBlock + WORST_OFFSET];
                        int rawData = BitConverter.ToInt32(driveData.VendorSpecific, currentBlock + RAW_OFFSET_LSB);
                        if (attributeId == 0)
                        {
                            continue;
                        }

                        var smartDrive = smartData.Where(x => x.InstanceName == driveData.InstanceName).First();
                        SmartAttributesDictionary smartAttributesDictionary = new SmartAttributesDictionary();
                        var currentAttributeFromDictionary = smartAttributesDictionary.Attributes.Where(x => x.Key == attributeId).First();

                        smartDrive.Attributes.Add(currentAttributeFromDictionary.Key, currentAttributeFromDictionary.Value);
                        var currentAttribute = smartDrive.Attributes[currentAttributeFromDictionary.Key];
                        currentAttribute.Current = value;
                        currentAttribute.Worst = worst;
                        currentAttribute.Raw = rawData;
                    }
                    catch
                    {
                        // key does not exist in attribute collection
                    }
                }
            }
        }

        private void ExtractFailrePredictThresholds(List<SMARTData> smartData, List<SmartFailurePredictThresholds> smartFailurePredictThresholds)
        {
            foreach (var driveData in smartFailurePredictThresholds)
            {
                byte[] bytes = driveData.VendorSpecific;
                for (int i = 0; i < BLOCKS_IN_VENDOR_ARRAY; ++i)
                {
                    int currentBlock = i * BLOCK_SIZE;

                    try
                    {
                        int attributeId = bytes[currentBlock + ARIBUTE_ID_OFFSET];
                        int threshold = bytes[currentBlock + THRESHOLD_OFFSET];
                        if (attributeId == 0)
                        {
                            continue;
                        }

                        var smartDrive = smartData.Where(x => x.InstanceName == driveData.InstanceName).First();
                        var attribute = smartDrive.Attributes[attributeId];
                        attribute.Threshold = threshold;
                    }
                    catch
                    {
                        // key does not exist in attribute collection
                    }
                }
            }
        }

        private void SetSmartAttributesStatusBasedOnThresholdValues(List<SMARTData> smartData)
        {
            foreach (var driveData in smartData)
            {
                foreach (var attribute in driveData.Attributes)
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

        private void ExtractPartitionsForStorage(List<Storage> storageData, List<DiskToPartition> diskToPartition, List<DiskPartition> diskPartition, List<PartitionToVolume> partitionToVolume, List<Volume> volume)
        {
            foreach (var diskToPartitionAssociation in diskToPartition)
            {
                string substringBeginning = "objectid";
                string extendePartitionMbrType = "15";

                string diskAssociationLower = diskToPartitionAssociation.Disk.ToLower();
                string diskAssociationLowerSubstring = diskAssociationLower
                    .Substring(diskAssociationLower.IndexOf(substringBeginning) + substringBeginning.Length);
                string preparedDiskAssociation = Regex.Unescape(diskAssociationLowerSubstring);

                string partitionAssociationLower = diskToPartitionAssociation.Partition.ToLower();
                string partitionAssociationLowerSubstring = partitionAssociationLower
                    .Substring(partitionAssociationLower.IndexOf(substringBeginning) + substringBeginning.Length);
                string preparedPartitionAssociation = Regex.Unescape(partitionAssociationLowerSubstring);

                Storage currentStorage = storageData.First(x => preparedDiskAssociation.Contains(x.Disk.ObjectId.ToLower()));

                foreach (var currentPartition in diskPartition)
                {
                    if (preparedPartitionAssociation.Contains(currentPartition.ObjectId.ToLower()))
                    {
                        var currentPartitionToVolume = partitionToVolume
                            .FirstOrDefault(x => x.Partition.ToLower() == partitionAssociationLower);

                        if (currentPartitionToVolume != null)
                        {
                            this.AddPartitionToStorage(volume, substringBeginning, currentStorage, currentPartition, currentPartitionToVolume);
                        }
                        else if (currentPartitionToVolume == null && currentPartition.MbrType == extendePartitionMbrType)
                        {
                            this.AddLogicalPartitionToStorage(currentStorage, currentPartition);
                        }
                    }
                }
            }
        }

        private void AddPartitionToStorage(List<Volume> volume, string substringBeginning, Storage currentStorage, DiskPartition currentPartition, PartitionToVolume currentPartitionToVolume)
        {
            string volumeAssociationLower = currentPartitionToVolume.Volume.ToLower();
            string volumeAssociationLowerSubstring = volumeAssociationLower
                .Substring(volumeAssociationLower.IndexOf(substringBeginning) + substringBeginning.Length);
            string preparedVolumeAssociation = Regex.Unescape(volumeAssociationLowerSubstring);

            var currentVolume = volume.First(x => preparedVolumeAssociation
                .Contains(x.ObjectId.ToLower()));

            currentStorage.Partition.Add(new Partition()
            {
                DedupMode = currentVolume.DedupMode,
                DiskId = currentPartition.DiskId,
                DiskNumber = currentPartition.DiskNumber,
                DriveLetter = currentPartition.DriveLetter,
                DriveType = currentVolume.DriveType,
                FileSystem = currentVolume.FileSystem,
                FileSystemLabel = currentVolume.FileSystemLabel,
                HealthStatus = currentVolume.HealthStatus,
                IsActive = currentPartition.IsActive,
                IsBoot = currentPartition.IsBoot,
                IsHidden = currentPartition.IsHidden,
                IsOffline = currentPartition.IsOffline,
                IsReadOnly = currentPartition.IsReadOnly,
                IsShadowCopy = currentPartition.IsShadowCopy,
                IsSystem = currentPartition.IsSystem,
                MbrType = currentPartition.MbrType,
                NoDefaultDriveLetter = currentPartition.NoDefaultDriveLetter,
                ObjectIdAsPartition = currentPartition.ObjectId,
                ObjectIdAsVolume = currentVolume.ObjectId,
                Offset = currentPartition.Offset,
                PartitionNumber = currentPartition.PartitionNumber,
                Path = currentVolume.Path,
                SizeAsPartition = currentPartition.Size,
                SizeAsVolume = currentVolume.Size,
                SizeRemaining = currentVolume.SizeRemaining,
                UniqueId = currentVolume.UniqueId
            });
        }

        private void AddLogicalPartitionToStorage(Storage currentStorage, DiskPartition currentPartition)
        {
            currentStorage.Partition.Add(new LogicalPartition()
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
                NoDefaultDriveLetter = currentPartition.NoDefaultDriveLetter,
                ObjectIdAsPartition = currentPartition.ObjectId,
                Offset = currentPartition.Offset,
                PartitionNumber = currentPartition.PartitionNumber,
                SizeAsPartition = currentPartition.Size,
            });
        }

        private void MatchLogicalPartitionsToExtendedPartitions(List<Storage> storageData)
        {
            foreach (var storage in storageData)
            {
                var extendedPartitionsForStorage = storage.Partition
                    .Where(x => x.MbrType == "15").ToList();

                foreach (var extendedPartition in extendedPartitionsForStorage)
                {
                    var lowerRangeForExtendedPartition = long.Parse(extendedPartition.Offset.Value);
                    var upperRangeForExtendedPartition = lowerRangeForExtendedPartition + long.Parse(extendedPartition.SizeAsPartition.Value);

                    var partitionsOnDisk = storage.Partition
                        .Where(x => !extendedPartitionsForStorage.Any(y => y.PartitionNumber == x.PartitionNumber)).ToList();

                    foreach (var partition in partitionsOnDisk)
                    {
                        var lowerRange = long.Parse(partition.Offset.Value);
                        var upperRange = lowerRange + long.Parse(partition.SizeAsPartition.Value);

                        if (lowerRange >= lowerRangeForExtendedPartition && upperRange <= upperRangeForExtendedPartition)
                        {
                            extendedPartition.Partitions.Add(partition);
                        }
                    }
                }
            }
        }
    }
}
