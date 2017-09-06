using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Battery : HardwareStaticComponent, IHardwareStaticComponent<Battery>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394074(v=vs.85).aspx
        public string BatteryStatus { get; private set; }

        public UnitValue DesignCapacity { get; private set; }

        public string DeviceID { get; private set; }

        public UnitValue FullChargeCapacity { get; private set; }

        public List<Battery> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Battery> staticData = new List<Battery>();

            foreach (var managementObject in managementObjectList)
            {
                Battery battery = new Battery();

                if (managementObject[ConstString.BATTERY_BATTERY_STATUS] != null)
                {
                    battery.BatteryStatus = ((BatteryStatus)((ushort)managementObject[ConstString.BATTERY_BATTERY_STATUS])).ToString();
                }
                else
                {
                    battery.BatteryStatus = string.Empty;
                }

                battery.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
                battery.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
                battery.DesignCapacity = new UnitValue(Unit.MWH, managementObject[ConstString.BATTERY_DESIGN_CAPACITY]?.ToString() ?? string.Empty);
                battery.DeviceID = managementObject[ConstString.BATTERY_DEVICE_ID]?.ToString() ?? string.Empty;
                battery.FullChargeCapacity = new UnitValue(Unit.MWH, managementObject[ConstString.BATTERY_FULLY_CHARGE_CAPACITY]?.ToString() ?? string.Empty);
                battery.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
                battery.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;

                staticData.Add(battery);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_BATTERY);
        }

        /*
         * DYNAMIC DATA
         */

        //public UnitValue DesignVoltage { get; private set; }

        //public UnitValue EstimatedChargeRemaining { get; private set; } //lenovo y580 - shows battery charge status in %, not remaining charge?!

        //public UnitValue EstimatedRunTime { get; private set; } //lenovo y580 - when charging shows very large irrational number?!

        //public UnitValue TimeOnBattery { get; private set; }

        //public UnitValue TimeToFullCharge { get; private set; }
    }
}
