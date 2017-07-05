using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Analyzed;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitorLibUnitTest.HardwareStatic.Builder;

namespace SystemMonitorLibUnitTest.HardwareStatic.ClassData
{
    public class Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_Source : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[]
            {
                new Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_StructureData()
                {
                    SmartFailurePredictData = new List<HardwareComponent>()
                    {
                        new SmartFailurePredictData()
                        {
                            InstanceName = "SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  5, 0, 0, 100, 100,   0,  0, 0, 0, 0,
                                0, 0,  9, 0, 0,  99,  99, 200, 50, 0, 0, 0,
                                0, 0, 12, 0, 0,  98,  98, 250,  4, 0, 0, 0,
                            }
                        },
                        new SmartFailurePredictData()
                        {
                            InstanceName = "SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  1, 0, 0, 100, 100,   7,  0, 0, 0, 0,
                                0, 0,  2, 0, 0, 252, 252,   0,  0, 0, 0, 0,
                                0, 0,  3, 0, 0,  90,  89,  11, 10, 0, 0, 0,
                            }
                        }
                    },
                    SmartFailurePredictStatus = new List<HardwareComponent>()
                    {
                        new SmartFailurePredictStatus()
                        {
                            InstanceName = "SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0",
                            PredictFailure = "False"
                        },
                        new SmartFailurePredictStatus()
                        {
                            InstanceName = "SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0",
                            PredictFailure = "False"
                        }
                    },
                    SmartFailurePredictThresholds = new List<HardwareComponent>()
                    {
                        new SmartFailurePredictThresholds()
                        {
                            InstanceName = "SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  5, 10, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0,  9,  0, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0, 12,  0, 0, 0, 0, 0, 0, 0, 0, 0,
                            }
                        },
                        new SmartFailurePredictThresholds()
                        {
                            InstanceName = "SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  1, 51, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0,  2,  0, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0,  3, 25, 0, 0, 0, 0, 0, 0, 0, 0,
                            }
                        }
                    },
                    ExpectedSmartData = new List<SMARTData>()
                    {
                        // Raw value calculation:
                        // 1) LSB 200 = 0xC8, MSB 50 = 0x32
                        // 0x32C8 = 13000
                        // 2) LSB 11 = 0x0B, MSB 10 = 0x0A
                        // 0x0A0B = 2571
                        new SMARTDataBuilder()
                            .WithInstanceName("SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0")
                            .WithPredictFailure("False")
                            .WithAttribute(5,  100, 100, 10,     0, SmartDataAttributeStatusEnum.OK_THRESHOLD_NOT_REACHED)
                            .WithAttribute(9,   99,  99,  0, 13000, SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED)
                            .WithAttribute(12,  98,  98,  0,  1274, SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED)
                            .Build(),
                        new SMARTDataBuilder()
                            .WithInstanceName("SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0")
                            .WithPredictFailure("False")
                            .WithAttribute(1, 100, 100, 51,   7, SmartDataAttributeStatusEnum.OK_THRESHOLD_NOT_REACHED)
                            .WithAttribute(2, 252, 252,  0,   0, SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED)
                            .WithAttribute(3,  90,  89, 25, 2571, SmartDataAttributeStatusEnum.OK_THRESHOLD_NOT_REACHED)
                            .Build(),
                    }
                }
            },
            new object[]
            {
                new Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_StructureData()
                {
                    SmartFailurePredictData = new List<HardwareComponent>()
                    {
                        new SmartFailurePredictData()
                        {
                            InstanceName = "SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  5, 0, 0,  60,  40,   0,  0, 0, 0, 0,
                                0, 0,  9, 0, 0,  99,  99, 200, 50, 0, 0, 0,
                                0, 0, 12, 0, 0,  98,  98, 250,  4, 0, 0, 0,
                            }
                        },
                        new SmartFailurePredictData()
                        {
                            InstanceName = "SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  1, 0, 0,  51,  51,   7,  0, 0, 0, 0,
                                0, 0,  2, 0, 0, 252, 252,   0,  0, 0, 0, 0,
                                0, 0,  3, 0, 0,  90,  89,  11, 10, 0, 0, 0,
                            }
                        }
                    },
                    SmartFailurePredictStatus = new List<HardwareComponent>()
                    {
                        new SmartFailurePredictStatus()
                        {
                            InstanceName = "SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0",
                            PredictFailure = "True"
                        },
                        new SmartFailurePredictStatus()
                        {
                            InstanceName = "SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0",
                            PredictFailure = "False"
                        }
                    },
                    SmartFailurePredictThresholds = new List<HardwareComponent>()
                    {
                        new SmartFailurePredictThresholds()
                        {
                            InstanceName = "SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  5, 50, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0,  9,  0, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0, 12,  0, 0, 0, 0, 0, 0, 0, 0, 0,
                            }
                        },
                        new SmartFailurePredictThresholds()
                        {
                            InstanceName = "SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0",
                            VendorSpecific = new byte[]
                            {
                                0, 0,  1, 51, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0,  2,  0, 0, 0, 0, 0, 0, 0, 0, 0,
                                0, 0,  3, 25, 0, 0, 0, 0, 0, 0, 0, 0,
                            }
                        }
                    },
                    ExpectedSmartData = new List<SMARTData>()
                    {
                        // Raw value calculation:
                        // 1) LSB 200 = 0xC8, MSB 50 = 0x32
                        // 0x32C8 = 13000
                        // 2) LSB 11 = 0x0B, MSB 10 = 0x0A
                        // 0x0A0B = 2571
                        new SMARTDataBuilder()
                            .WithInstanceName("SCSI\\Disk&Ven_Samsung&Prod_SSD_850_EVO_mSAT\\4&3359eddd&0&000000_0")
                            .WithPredictFailure("True")
                            .WithAttribute(5,   60,  40, 50,     0, SmartDataAttributeStatusEnum.FAILED_CRITICAL)
                            .WithAttribute(9,   99,  99,  0, 13000, SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED)
                            .WithAttribute(12,  98,  98,  0,  1274, SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED)
                            .Build(),
                        new SMARTDataBuilder()
                            .WithInstanceName("SCSI\\Disk&Ven_&Prod_ST1000LM024_HN-M\\4&3359eddd&0&010000_0")
                            .WithPredictFailure("False")
                            .WithAttribute(1,  51,  51, 51,   7, SmartDataAttributeStatusEnum.FAILED)
                            .WithAttribute(2, 252, 252,  0,   0, SmartDataAttributeStatusEnum.THRESHOLD_NOT_DEFINED)
                            .WithAttribute(3,  90,  89, 25, 2571, SmartDataAttributeStatusEnum.OK_THRESHOLD_NOT_REACHED)
                            .Build(),
                    }
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
