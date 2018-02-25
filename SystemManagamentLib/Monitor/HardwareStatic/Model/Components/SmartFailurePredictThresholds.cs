using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    public class SmartFailurePredictThresholds : HardwareStaticComponent, IHardwareStaticComponent<SmartFailurePredictThresholds>
    {
        public byte[] VendorSpecific { get; set; }

        public string InstanceName { get; set; }

        public List<SmartFailurePredictThresholds> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<SmartFailurePredictThresholds> staticData = new List<SmartFailurePredictThresholds>();

            foreach (var managementObject in managementObjectList)
            {
                SmartFailurePredictThresholds smartFailurePredictThresholds = new SmartFailurePredictThresholds();
                smartFailurePredictThresholds.Caption = string.Empty;
                smartFailurePredictThresholds.Description = string.Empty;
                smartFailurePredictThresholds.InstanceName = managementObject[ConstString.SMART_INSTANCE_NAME].TryGetStringValue();
                smartFailurePredictThresholds.Name = string.Empty;
                smartFailurePredictThresholds.VendorSpecific = (byte[])managementObject[ConstString.SMART_VENDOR_SPECIFIC] ?? new byte[0];
                smartFailurePredictThresholds.Status = string.Empty;

                staticData.Add(smartFailurePredictThresholds);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_WMI, ConstString.WMI_QUERY_SMART_THRESHOLDS);
        }
    }
}
