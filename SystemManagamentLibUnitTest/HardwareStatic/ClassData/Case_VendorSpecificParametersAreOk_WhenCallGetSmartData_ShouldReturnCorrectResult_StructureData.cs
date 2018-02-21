using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Analyzed;

namespace SystemMonitorLibUnitTest.HardwareStatic.ClassData
{
    public class Case_VendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_StructureData
    {
        public List<SmartFailurePredictData> SmartFailurePredictData { get; set; }

        public List<SmartFailurePredictStatus> SmartFailurePredictStatus { get; set; }

        public List<SmartFailurePredictThresholds> SmartFailurePredictThresholds { get; set; }

        public List<SMARTData> ExpectedSmartData { get; set; }
    }
}
