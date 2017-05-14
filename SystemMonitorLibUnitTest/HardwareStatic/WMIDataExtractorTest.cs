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
        //[Theory]
        //[ClassData(typeof(Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided_Source))]
        //public void Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided(
        //     ManagementObject processorParameter,
        //     ManagementObject cacheParameter)
        //{
        //    // arrange
        //    IWMIDataExtractor extractor = new WMIDataExtractor();

        //    // act
        //    var result = extractor.ExtractDataProcessor(processorParameter, cacheParameter);

        //    // assert
        //    Assert.IsType<Processor>(result);
        //}

        [Fact]
        public void Should_ExtractProcessorDataCorrectly_When_SomePropertiesAreNotProvided()
        {
            // arrange
            IWMIDataExtractor extractor = new WMIDataExtractor();
            Mock<ManagementObject> mockItem = new Mock<ManagementObject>();
            Mock<PropertyDataCollection> mockAttributes = new Mock<PropertyDataCollection>();
            Mock<PropertyData> propertyData = new Mock<PropertyData>();

            //propertyData.SetupGet(x => x.Name).Returns("name");
            //propertyData.SetupGet(x => x.Value).Returns("Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz");
            //mockItem.SetPropertyValue("name", "Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz");
            //mockItem.SetupGet(x => x["name"]).Returns("Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz");
            //              .Returns((PropertyData)propertyData.Object.Value);
            //mockItem.SetupGet(x => x.Properties).Returns(mockAttributes);

            //// act
            //var result = extractor.ExtractDataProcessor(mockItem.Object, mockItem.Object);

            //// assert
            //Assert.IsType<Processor>(result);
            //Assert.Equal("Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz", result.Name);
        }
    }
}
