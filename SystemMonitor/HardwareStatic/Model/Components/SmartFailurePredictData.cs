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
    public class SmartFailurePredictData : HardwareComponent
    {
        public byte[] VendorSpecific { get; set; }

        public string InstanceName { get; set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            SmartFailurePredictData smartFailurePredictData = new SmartFailurePredictData();
            smartFailurePredictData.Caption = string.Empty;
            smartFailurePredictData.Description = string.Empty;
            smartFailurePredictData.InstanceName = managementObject[ConstStringHardwareStatic.SMART_INSTANCE_NAME]?.ToString() ?? string.Empty;
            smartFailurePredictData.Name = string.Empty;
            smartFailurePredictData.VendorSpecific = (byte[])managementObject[ConstStringHardwareStatic.SMART_VENDOR_SPECIFIC] ?? new byte[0];
            smartFailurePredictData.Status = string.Empty;
            return smartFailurePredictData;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_WMI, ConstStringHardwareStatic.WMI_QUERY_SMART_DATA);
        }
    }
}
