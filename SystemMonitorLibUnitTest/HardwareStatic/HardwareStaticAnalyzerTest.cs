using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Analyzer;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Analyzed;
using SystemMonitorLibUnitTest.HardwareStatic.ClassData;
using Xunit;

namespace SystemMonitorLibUnitTest.HardwareStatic
{
    public class HardwareStaticAnalyzerTest
    {
        [Theory]
        [ClassData(typeof(Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_Source))]
        public void Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult(Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_StructureData parameters)
        {
            // Arrange
            IHardwareStaticAnalyzer sut = new HardwareStaticAnalyzer();

            // Act
            var sutResult = sut.GetSmartData(parameters.SmartFailurePredictStatus, parameters.SmartFailurePredictData, parameters.SmartFailurePredictThresholds);

            // Assert
            Assert.Equal(parameters.ExpectedSmartData, sutResult);
        }
    }
}
