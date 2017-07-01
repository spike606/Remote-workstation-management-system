using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private const int WORST_OFFSET = 5;
        private const int RAW_OFFSET = 7;
        private const int TRESHOLD_OFFSET = 3;
        private const int STATUS_OFFSET = 4;

        public List<SMARTData> GetSmartData(List<HardwareComponent> smartFailurePredictStatus, List<HardwareComponent> smartFailurePredictData, List<HardwareComponent> smartFailurePredictTresholds)
        {
            List<SMARTData> smartData = new List<SMARTData>();

            ExtractFailurePredictStatus(smartData, smartFailurePredictStatus);
            ExtractFailurePredictData(smartData, smartFailurePredictData);
            ExtractFailrePredictTresholds(smartData, smartFailurePredictTresholds);

            SetSmartAttributesStatusBasedOnTresholdValues(smartData);

            foreach (var data in smartData)
            {
                Console.WriteLine("ID                   Current  Worst  Threshold  Data  Status");
                foreach (var attr in data.Attributes)
                {
                    if (attr.Value.HasData)
                    {
                        Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}\t {5}\t", attr.Value.AttributeName, attr.Value.Current, attr.Value.Worst, attr.Value.Threshold, attr.Value.Raw, attr.Value.Status);
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            return smartData;
        }

        public List<Storage> GetStorageData(Disk disk, DiskPartition diskPartition, Volume volume, DiskToPartition diskToPartition, PartitionToVolume partitionToVolume)
        {
            throw new NotImplementedException();
        }

        private static void ExtractFailurePredictStatus(List<SMARTData> smartData, List<HardwareComponent> smartFailurePredictStatus)
        {
            List<SmartFailurePredictStatus> smartFailurePredictStatusList = smartFailurePredictStatus.Cast<SmartFailurePredictStatus>().ToList();

            foreach (var driveData in smartFailurePredictStatusList)
            {
                smartData.Add(new SMARTData
                {
                    InstanceName = driveData.InstanceName,
                    PredicFailure = driveData.PredictFailure
                });
            }
        }

        private static void ExtractFailurePredictData(List<SMARTData> smartData, List<HardwareComponent> smartFailurePredictData)
        {
            List<SmartFailurePredictData> smartFailurePredictDataList = smartFailurePredictData.Cast<SmartFailurePredictData>().ToList();

            foreach (var driveData in smartFailurePredictDataList)
            {
                for (int i = 0; i < BLOCKS_IN_VENDOR_ARRAY; ++i)
                {
                    int currentBlock = i * BLOCK_SIZE;
                    try
                    {
                        int attributeId = driveData.VendorSpecific[currentBlock + ARIBUTE_ID_OFFSET];
                        int flags = driveData.VendorSpecific[currentBlock + STATUS_OFFSET];
                        bool failureImminent = (flags & 0x1) == 0x1;
                        int value = driveData.VendorSpecific[currentBlock + VALUE_OFFSET];
                        int worst = driveData.VendorSpecific[currentBlock + WORST_OFFSET];
                        int rawData = BitConverter.ToInt32(driveData.VendorSpecific, currentBlock + RAW_OFFSET);
                        if (attributeId == 0)
                        {
                            continue;
                        }

                        var smartDrive = smartData.Where(x => x.InstanceName == driveData.InstanceName).First();

                        var attribute = smartDrive.Attributes[attributeId];
                        attribute.Current = value;
                        attribute.Worst = worst;
                        attribute.Raw = rawData;
                    }
                    catch
                    {
                        // key does not exist in attribute collection
                    }
                }
            }
        }

        private static void ExtractFailrePredictTresholds(List<SMARTData> smartData, List<HardwareComponent> smartFailurePredictTresholds)
        {
            List<SmartFailurePredictTresholds> smartFailurePredictTresholdsList = smartFailurePredictTresholds.Cast<SmartFailurePredictTresholds>().ToList();

            foreach (var driveData in smartFailurePredictTresholdsList)
            {
                byte[] bytes = driveData.VendorSpecific;
                for (int i = 0; i < BLOCKS_IN_VENDOR_ARRAY; ++i)
                {
                    int currentBlock = i * BLOCK_SIZE;

                    try
                    {
                        int attributeId = bytes[currentBlock + ARIBUTE_ID_OFFSET];
                        int threshold = bytes[currentBlock + TRESHOLD_OFFSET];
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

        private static void SetSmartAttributesStatusBasedOnTresholdValues(List<SMARTData> smartData)
        {
            foreach (var driveData in smartData)
            {
                foreach (var attribute in driveData.Attributes)
                {
                    if (attribute.Value.HasData)
                    {
                        if (attribute.Value.Threshold.Equals(0))
                        {
                            attribute.Value.Status = SmartDataAttributeStatusEnum.TRESHOLD_NOT_DEFINED;
                        }
                        else if (attribute.Value.Current > attribute.Value.Threshold)
                        {
                            attribute.Value.Status = SmartDataAttributeStatusEnum.OK_TRESHOLD_NOT_REACHED;
                        }
                        else if (attribute.Value.Current <= attribute.Value.Threshold)
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
        }
    }
}
