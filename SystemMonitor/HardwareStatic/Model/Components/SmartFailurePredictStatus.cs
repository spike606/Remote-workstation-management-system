using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class SmartFailurePredictStatus : HardwareComponent
    {
        public string PredictFailure { get; set; }

        public string InstanceName { get; set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            SmartFailurePredictStatus smartFailurePredictStatus = new SmartFailurePredictStatus();
            smartFailurePredictStatus.Caption = string.Empty;
            smartFailurePredictStatus.Description = string.Empty;
            smartFailurePredictStatus.InstanceName = managementObject[ConstStringHardwareStatic.SMART_INSTANCE_NAME]?.ToString() ?? string.Empty;
            smartFailurePredictStatus.Name = string.Empty;
            smartFailurePredictStatus.PredictFailure = managementObject[ConstStringHardwareStatic.SMART_PREDICT_FAILURE]?.ToString() ?? string.Empty;
            smartFailurePredictStatus.Status = string.Empty;
            return smartFailurePredictStatus;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_WMI, ConstStringHardwareStatic.WMI_QUERY_SMART_STATUS);
        }
    }
}
