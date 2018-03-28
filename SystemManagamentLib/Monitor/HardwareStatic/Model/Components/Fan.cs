using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class Fan : HardwareStaticComponent, IHardwareStaticComponent<Fan>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394146(v=vs.85).aspx
        public List<Fan> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Fan> staticData = new List<Fan>();

            foreach (var managementObject in managementObjectList)
            {
                Fan fan = new Fan();
                fan.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                fan.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                fan.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();

                staticData.Add(fan);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_FAN);
        }
    }
}
