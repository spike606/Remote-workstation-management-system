using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class SmartFailurePredictStatus : HardwareStaticComponent, IHardwareStaticComponent<SmartFailurePredictStatus>
    {
        public string PredictFailure { get; set; }

        public string InstanceName { get; set; }

        public List<SmartFailurePredictStatus> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<SmartFailurePredictStatus> staticData = new List<SmartFailurePredictStatus>();

            foreach (var managementObject in managementObjectList)
            {
                SmartFailurePredictStatus smartFailurePredictStatus = new SmartFailurePredictStatus();
                smartFailurePredictStatus.Caption = string.Empty;
                smartFailurePredictStatus.Description = string.Empty;
                smartFailurePredictStatus.InstanceName = managementObject[ConstString.SMART_INSTANCE_NAME].TryGetStringValue();
                smartFailurePredictStatus.Name = string.Empty;
                smartFailurePredictStatus.PredictFailure = managementObject[ConstString.SMART_PREDICT_FAILURE].TryGetStringValue();
                smartFailurePredictStatus.Status = string.Empty;

                staticData.Add(smartFailurePredictStatus);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_WMI, ConstString.WMI_QUERY_SMART_STATUS);
        }
    }
}
