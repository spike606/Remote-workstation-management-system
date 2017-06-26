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
    public class SmartFailurePredictTresholds : HardwareComponent
    {
        public byte[] VendorSpecific { get; set; }

        public string InstanceName { get; set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            SmartFailurePredictTresholds smartFailurePredictTresholds = new SmartFailurePredictTresholds();
            smartFailurePredictTresholds.Caption = string.Empty;
            smartFailurePredictTresholds.Description = string.Empty;
            smartFailurePredictTresholds.InstanceName = managementObject[ConstStringHardwareStatic.SMART_INSTANCE_NAME]?.ToString() ?? string.Empty;
            smartFailurePredictTresholds.Name = string.Empty;
            smartFailurePredictTresholds.VendorSpecific = (byte[])managementObject[ConstStringHardwareStatic.SMART_VENDOR_SPECIFIC] ?? new byte[0];
            smartFailurePredictTresholds.Status = string.Empty;
            return smartFailurePredictTresholds;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_WMI, ConstStringHardwareStatic.WMI_QUERY_SMART_TRESHOLDS);
        }
    }
}
