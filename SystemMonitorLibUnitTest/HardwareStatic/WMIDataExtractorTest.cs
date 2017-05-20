using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SystemMonitor.HardwareStatic;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;
using SystemMonitorLibUnitTest.HardwareStatic.ClassData;
using Xunit;

namespace SystemMonitorLibUnitTest.HardwareStatic
{
    public class WMIDataExtractorTest
    {
        [Theory]
        [ClassData(typeof(Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided_Source))]
        public void Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided(
             ManagementObject processorParameter,
             List<ManagementObject> cacheParameter,
             int propertiesCount)
        {
            // arrange
            IWMIDataExtractor extractor = new WMIDataExtractor();

            // act
            var sut = extractor.ExtractDataProcessor(processorParameter, cacheParameter);

            // assert
            Assert.IsType<Processor>(sut);
            Assert.Equal(propertiesCount, sut.GetType().GetProperties().Count());
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_ADDRESS_WIDTH].ToString(), sut.AddressWidth.Value);
            Assert.Equal(((ArchitectureEnum)((ushort)processorParameter[ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE])).ToString(), sut.Architecture);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_BUS_SPEED].ToString(), sut.BusSpeed.Value);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_CAPTION], sut.Caption);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH].ToString(), sut.DataWidth.Value);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_DESCRIPTION], sut.Description);
            Assert.Equal(cacheParameter.Count, sut.Cache.Count);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_MANUFACTURER], sut.Manufacturer);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED].ToString(), sut.MaxClockSpeed.Value);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_NAME], sut.Name);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES].ToString(), sut.NumberOfCores);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS].ToString(), sut.NumberOfLogicalProcessors);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_ID], sut.ProcessorID);
            //Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_SERIAL_NUMBER], sut.SerialNumber);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION], sut.SocketDesignation);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_STEPPING], sut.Stepping);
            //Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT].ToString(), sut.ThreadCount);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID], sut.UniqueId);
        }

        [Theory]
        [ClassData(typeof(Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreNull_Source))]
        public void Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreNull(
             ManagementObject processorParameter,
             List<ManagementObject> cacheParameter,
             int propertiesCount)
        {
            // arrange
            IWMIDataExtractor extractor = new WMIDataExtractor();

            // act
            var sut = extractor.ExtractDataProcessor(processorParameter, cacheParameter);

            // assert
            Assert.IsType<Processor>(sut);
            Assert.Equal(propertiesCount, sut.GetType().GetProperties().Count());
            Assert.Equal(string.Empty, sut.AddressWidth.Value);
            Assert.Equal(string.Empty, sut.Architecture);
            Assert.Equal(string.Empty, sut.BusSpeed.Value);
            Assert.Equal(string.Empty, sut.Caption);
            Assert.Equal(string.Empty, sut.DataWidth.Value);
            Assert.Equal(string.Empty, sut.Description);
            Assert.Equal(cacheParameter.Count, sut.Cache.Count);
            Assert.Equal(string.Empty, sut.Manufacturer);
            Assert.Equal(string.Empty, sut.MaxClockSpeed.Value);
            Assert.Equal(string.Empty, sut.Name);
            Assert.Equal(string.Empty, sut.NumberOfCores);
            Assert.Equal(string.Empty, sut.NumberOfLogicalProcessors);
            Assert.Equal(string.Empty, sut.ProcessorID);
            //Assert.Equal(string.Empty, sut.SerialNumber);
            Assert.Equal(string.Empty, sut.SocketDesignation);
            Assert.Equal(string.Empty, sut.Stepping);
            //Assert.Equal(string.Empty, sut.ThreadCount);
            Assert.Equal(string.Empty, sut.UniqueId);
        }

        [Theory]
        [ClassData(typeof(Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreNull_Source))]
        public void Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreNull(
             ManagementObject memoryParameter,
             int propertiesCount)
        {
            // arrange
            IWMIDataExtractor extractor = new WMIDataExtractor();

            // act
            var sut = extractor.ExtractDataMemory(memoryParameter);

            // assert
            Assert.IsType<Memory>(sut);
            Assert.Equal(propertiesCount, sut.GetType().GetProperties().Count());
            Assert.Equal(string.Empty, sut.BankLabel);
            Assert.Equal(string.Empty, sut.Capacity.Value);
            Assert.Equal(string.Empty, sut.Caption);
            Assert.Equal(string.Empty, sut.ConfiguredClockSpeed.Value);
            Assert.Equal(string.Empty, sut.ConfiguredVoltage.Value);
            Assert.Equal(string.Empty, sut.DataWidth.Value);
            Assert.Equal(string.Empty, sut.Description);
            Assert.Equal(string.Empty, sut.DeviceLocator);
            Assert.Equal(string.Empty, sut.Manufacturer);
            Assert.Equal(string.Empty, sut.MaxVoltage.Value);
            Assert.Equal(string.Empty, sut.MemoryType);
            Assert.Equal(string.Empty, sut.MinVoltage.Value);
            Assert.Equal(string.Empty, sut.Name);
            Assert.Equal(string.Empty, sut.PartNumber);
            Assert.Equal(string.Empty, sut.SerialNumber);
            Assert.Equal(string.Empty, sut.TotalWidth.Value);
        }

        [Theory]
        [ClassData(typeof(Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreProvided_Source))]
        public void Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreProvided(
             ManagementObject memoryParameter,
             int propertiesCount)
        {
            // arrange
            IWMIDataExtractor extractor = new WMIDataExtractor();

            // act
            var sut = extractor.ExtractDataMemory(memoryParameter);

            // assert
            Assert.IsType<Memory>(sut);
            Assert.Equal(propertiesCount, sut.GetType().GetProperties().Count());
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_BANK_LABEL], sut.BankLabel);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CAPACITY].ToString(), sut.Capacity.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CAPTION], sut.Caption);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED].ToString(), sut.ConfiguredClockSpeed.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE].ToString(), sut.ConfiguredVoltage.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_DATA_WIDTH].ToString(), sut.DataWidth.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_DESCRIPTION], sut.Description);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR], sut.DeviceLocator);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_MANUFACTURER], sut.Manufacturer);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE].ToString(), sut.MaxVoltage.Value);
            Assert.Equal(((MemoryTypeEnum)((ushort)memoryParameter[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE])).ToString(), sut.MemoryType);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE].ToString(), sut.MinVoltage.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_NAME], sut.Name);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_PART_NUMBER], sut.PartNumber);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER], sut.SerialNumber);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH].ToString(), sut.TotalWidth.Value);
        }
    }
}
