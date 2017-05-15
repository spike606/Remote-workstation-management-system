using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SystemMonitor.HardwareStatic.Model.Components;
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
            Assert.NotEqual(string.Empty, sut.AddressWidth.Value);
            Assert.NotEqual(string.Empty, sut.Architecture);
            Assert.NotEqual(string.Empty, sut.BusSpeed.Value);
            Assert.NotEqual(string.Empty, sut.Caption);
            Assert.NotEqual(string.Empty, sut.DataWidth.Value);
            Assert.NotEqual(string.Empty, sut.Description);
            Assert.Equal(cacheParameter.Count, sut.Cache.Count);
            Assert.NotEqual(string.Empty, sut.Manufacturer);
            Assert.NotEqual(string.Empty, sut.MaxClockSpeed.Value);
            Assert.NotEqual(string.Empty, sut.Name);
            Assert.NotEqual(string.Empty, sut.NumberOfCores);
            Assert.NotEqual(string.Empty, sut.NumberOfLogicalProcessors);
            Assert.NotEqual(string.Empty, sut.ProcessorID);
            //Assert.NotEqual(string.Empty, sut.SerialNumber);
            Assert.NotEqual(string.Empty, sut.SocketDesignation);
            Assert.NotEqual(string.Empty, sut.Stepping);
            //Assert.NotEqual(string.Empty, sut.ThreadCount);
            Assert.NotEqual(string.Empty, sut.UniqueId);
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
    }
}
