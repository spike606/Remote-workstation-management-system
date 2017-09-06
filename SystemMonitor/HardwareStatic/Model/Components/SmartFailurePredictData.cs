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
    public class SmartFailurePredictData : HardwareStaticComponent, IHardwareStaticComponent<SmartFailurePredictData>
    {
        public byte[] VendorSpecific { get; set; }

        public string InstanceName { get; set; }

        public List<SmartFailurePredictData> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<SmartFailurePredictData> staticData = new List<SmartFailurePredictData>();

            foreach (var managementObject in managementObjectList)
            {
                SmartFailurePredictData smartFailurePredictData = new SmartFailurePredictData();
                smartFailurePredictData.Caption = string.Empty;
                smartFailurePredictData.Description = string.Empty;
                smartFailurePredictData.InstanceName = managementObject[ConstString.SMART_INSTANCE_NAME]?.ToString() ?? string.Empty;
                smartFailurePredictData.Name = string.Empty;
                smartFailurePredictData.VendorSpecific = (byte[])managementObject[ConstString.SMART_VENDOR_SPECIFIC] ?? new byte[0];
                smartFailurePredictData.Status = string.Empty;

                staticData.Add(smartFailurePredictData);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_WMI, ConstString.WMI_QUERY_SMART_DATA);
        }
    }
}
