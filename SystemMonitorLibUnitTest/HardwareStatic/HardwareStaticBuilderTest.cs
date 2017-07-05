﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SystemMonitor.HardwareStatic;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.HardwareStatic.WMI;
using SystemMonitorLibUnitTest.HardwareStatic.ClassData;
using Xunit;

namespace SystemMonitorLibUnitTest.HardwareStatic
{
    public class HardwareStaticBuilderTest
    {
        [Theory]
        [ClassData(typeof(Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided_Source))]
        public void Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided(
             ManagementObject processorParameter,
             int propertiesCount)
        {
            // arrange
            Mock<IWMIClient> wMIClientMock = new Mock<IWMIClient>();
            wMIClientMock.Setup(t => t.RetriveListOfObjectsByExecutingWMIQuery(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<ManagementObject> { processorParameter });

            IHardwareStaticBuilder sut = new HardwareStaticBuilder(wMIClientMock.Object);

            // act
            var sutResult = (Processor)sut.GetStaticData(new Processor()).FirstOrDefault();

            // assert
            Assert.IsType<Processor>(sutResult);
            Assert.Equal(propertiesCount, sutResult.GetType().GetProperties().Count());
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_ADDRESS_WIDTH].ToString(), sutResult.AddressWidth.Value);
            Assert.Equal(((ArchitectureEnum)((ushort)processorParameter[ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE])).ToString(), sutResult.Architecture);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_BUS_SPEED].ToString(), sutResult.BusSpeed.Value);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION], sutResult.Caption);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH].ToString(), sutResult.DataWidth.Value);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION], sutResult.Description);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_MANUFACTURER], sutResult.Manufacturer);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED].ToString(), sutResult.MaxClockSpeed.Value);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME], sutResult.Name);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES].ToString(), sutResult.NumberOfCores);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS].ToString(), sutResult.NumberOfLogicalProcessors);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_ID], sutResult.ProcessorID);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_SERIAL_NUMBER], sutResult.SerialNumber);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION], sutResult.SocketDesignation);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS], sutResult.Status);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_STEPPING], sutResult.Stepping);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT].ToString(), sutResult.ThreadCount);
            Assert.Equal(processorParameter[ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID], sutResult.UniqueId);
        }

        [Theory]
        [ClassData(typeof(Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreNull_Source))]
        public void Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreNull(
             ManagementObject processorParameter,
             int propertiesCount)
        {
            // arrange
            Mock<IWMIClient> wMIClientMock = new Mock<IWMIClient>();
            wMIClientMock.Setup(t => t.RetriveListOfObjectsByExecutingWMIQuery(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<ManagementObject> { processorParameter });

            IHardwareStaticBuilder sut = new HardwareStaticBuilder(wMIClientMock.Object);

            // act
            var sutResult = (Processor)sut.GetStaticData(new Processor()).FirstOrDefault();

            // assert
            Assert.IsType<Processor>(sutResult);
            Assert.Equal(propertiesCount, sutResult.GetType().GetProperties().Count());
            Assert.Equal(string.Empty, sutResult.AddressWidth.Value);
            Assert.Equal(string.Empty, sutResult.Architecture);
            Assert.Equal(string.Empty, sutResult.BusSpeed.Value);
            Assert.Equal(string.Empty, sutResult.Caption);
            Assert.Equal(string.Empty, sutResult.DataWidth.Value);
            Assert.Equal(string.Empty, sutResult.Description);
            Assert.Equal(string.Empty, sutResult.Manufacturer);
            Assert.Equal(string.Empty, sutResult.MaxClockSpeed.Value);
            Assert.Equal(string.Empty, sutResult.Name);
            Assert.Equal(string.Empty, sutResult.NumberOfCores);
            Assert.Equal(string.Empty, sutResult.NumberOfLogicalProcessors);
            Assert.Equal(string.Empty, sutResult.ProcessorID);
            Assert.Equal(string.Empty, sutResult.SerialNumber);
            Assert.Equal(string.Empty, sutResult.SocketDesignation);
            Assert.Equal(string.Empty, sutResult.Status);
            Assert.Equal(string.Empty, sutResult.Stepping);
            Assert.Equal(string.Empty, sutResult.ThreadCount);
            Assert.Equal(string.Empty, sutResult.UniqueId);
        }

        [Theory]
        [ClassData(typeof(Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreNull_Source))]
        public void Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreNull(
             ManagementObject memoryParameter,
             int propertiesCount)
        {
            // arrange
            Mock<IWMIClient> wMIClientMock = new Mock<IWMIClient>();
            wMIClientMock.Setup(t => t.RetriveListOfObjectsByExecutingWMIQuery(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<ManagementObject> { memoryParameter });

            IHardwareStaticBuilder sut = new HardwareStaticBuilder(wMIClientMock.Object);

            // act
            var sutResult = (Memory)sut.GetStaticData(new Memory()).FirstOrDefault();

            // assert
            Assert.IsType<Memory>(sutResult);
            Assert.Equal(propertiesCount, sutResult.GetType().GetProperties().Count());
            Assert.Equal(string.Empty, sutResult.BankLabel);
            Assert.Equal(string.Empty, sutResult.Capacity.Value);
            Assert.Equal(string.Empty, sutResult.Caption);
            Assert.Equal(string.Empty, sutResult.ConfiguredClockSpeed.Value);
            Assert.Equal(string.Empty, sutResult.ConfiguredVoltage.Value);
            Assert.Equal(string.Empty, sutResult.DataWidth.Value);
            Assert.Equal(string.Empty, sutResult.Description);
            Assert.Equal(string.Empty, sutResult.DeviceLocator);
            Assert.Equal(string.Empty, sutResult.Manufacturer);
            Assert.Equal(string.Empty, sutResult.MaxVoltage.Value);
            Assert.Equal(string.Empty, sutResult.MemoryType);
            Assert.Equal(string.Empty, sutResult.MinVoltage.Value);
            Assert.Equal(string.Empty, sutResult.Name);
            Assert.Equal(string.Empty, sutResult.PartNumber);
            Assert.Equal(string.Empty, sutResult.Status);
            Assert.Equal(string.Empty, sutResult.SerialNumber);
            Assert.Equal(string.Empty, sutResult.TotalWidth.Value);
        }

        [Theory]
        [ClassData(typeof(Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreProvided_Source))]
        public void Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreProvided(
             ManagementObject memoryParameter,
             int propertiesCount)
        {
            // arrange
            Mock<IWMIClient> wMIClientMock = new Mock<IWMIClient>();
            wMIClientMock.Setup(t => t.RetriveListOfObjectsByExecutingWMIQuery(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<ManagementObject> { memoryParameter });

            IHardwareStaticBuilder sut = new HardwareStaticBuilder(wMIClientMock.Object);

            // act
            var suResult = (Memory)sut.GetStaticData(new Memory()).FirstOrDefault();

            // assert
            Assert.IsType<Memory>(suResult);
            Assert.Equal(propertiesCount, suResult.GetType().GetProperties().Count());
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_BANK_LABEL], suResult.BankLabel);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CAPACITY].ToString(), suResult.Capacity.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION], suResult.Caption);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED].ToString(), suResult.ConfiguredClockSpeed.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE].ToString(), suResult.ConfiguredVoltage.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_DATA_WIDTH].ToString(), suResult.DataWidth.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION], suResult.Description);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR], suResult.DeviceLocator);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_MANUFACTURER], suResult.Manufacturer);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE].ToString(), suResult.MaxVoltage.Value);
            Assert.Equal(((MemoryTypeEnum)((ushort)memoryParameter[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE])).ToString(), suResult.MemoryType);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE].ToString(), suResult.MinVoltage.Value);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME], suResult.Name);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_PART_NUMBER], suResult.PartNumber);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER], suResult.SerialNumber);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS], suResult.Status);
            Assert.Equal(memoryParameter[ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH].ToString(), suResult.TotalWidth.Value);
        }
    }
}
