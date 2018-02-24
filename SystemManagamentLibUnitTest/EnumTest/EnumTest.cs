using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using Xunit;

namespace SystemMonitorLibUnitTest.EnumTest
{
    public class EnumTest
    {
        [Theory]
        [InlineData(BusTypeEnum.FibreChannel, "Fibre Channel")]
        [InlineData(BusTypeEnum.FileBackedVirtual, "File-Backed Virtual")]
        [InlineData(BusTypeEnum.IEEE1394, "IEEE 1394")]
        [InlineData(BusTypeEnum.MMC, "Multimedia Card (MMC)")]
        [InlineData(BusTypeEnum.SAS, "Serial Attached SCSI (SAS)")]
        [InlineData(BusTypeEnum.SATA, "Serial ATA (SATA)")]
        [InlineData(BusTypeEnum.StorageSpaces, "Storage spaces")]
        [InlineData(BusTypeEnum.Virtual, "Virtual - This value is reserved for system use.")]
        [InlineData(BusTypeEnum.SD, "Secure Digital (SD)")]
        internal void Should_ReturnEnumDescriptionAttributeValue_When_CallingGetEnumDescriptionOnBusTypeEnumObject(BusTypeEnum enumToTest, string expectedValue)
        {
            // Arrange

            // Act
            var sut = enumToTest.GetEnumDescription();

            // ASsert
            Assert.Equal(expectedValue, sut);
        }

        [Theory]
        [InlineData(BusTypeEnum.ATA, "ATA")]
        [InlineData(BusTypeEnum.ATAPI, "ATAPI")]
        [InlineData(BusTypeEnum.iSCSI, "iSCSI")]
        [InlineData(BusTypeEnum.NVMe, "NVMe")]
        [InlineData(BusTypeEnum.RAID, "RAID")]
        [InlineData(BusTypeEnum.SCSI, "SCSI")]
        [InlineData(BusTypeEnum.SSA, "SSA")]
        [InlineData(BusTypeEnum.Unknown, "Unknown")]
        [InlineData(BusTypeEnum.USB, "USB")]
        internal void Should_ReturnStringValue_When_CallingGetEnumDescriptionOnBusTypeEnumObject(BusTypeEnum enumToTest, string expectedValue)
        {
            // Arrange

            // Act
            var sut = enumToTest.GetEnumDescription();

            // ASsert
            Assert.Equal(expectedValue, sut);
        }
    }
}
