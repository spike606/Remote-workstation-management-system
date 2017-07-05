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
    public class Case_AllProvidedVendorSpecificParametersAreOk_WhenCallGetSmartData_ShouldReturnCorrectResult_StructureData
    {
        public List<HardwareComponent> SmartFailurePredictData { get; set; }

        public List<HardwareComponent> SmartFailurePredictStatus { get; set; }

        public List<HardwareComponent> SmartFailurePredictThresholds { get; set; }

        public List<SMARTData> ExpectedSmartData { get; set; }
    }
}
