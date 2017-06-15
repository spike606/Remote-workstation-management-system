using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Battery : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394074(v=vs.85).aspx
        public string BatteryStatus { get; private set; }

        public UnitValue DesignCapacity { get; private set; }

        public string DeviceID { get; private set; }

        public UnitValue FullChargeCapacity { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            Battery battery = new Battery();

            if (managementObject[ConstStringHardwareStatic.BATTERY_BATTERY_STATUS] != null)
            {
                battery.BatteryStatus = ((BatteryStatus)((ushort)managementObject[ConstStringHardwareStatic.BATTERY_BATTERY_STATUS])).ToString();
            }
            else
            {
                battery.BatteryStatus = string.Empty;
            }

            battery.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            battery.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            battery.DesignCapacity = new UnitValue(Unit.MWH, managementObject[ConstStringHardwareStatic.BATTERY_DESIGN_CAPACITY]?.ToString() ?? string.Empty);
            battery.DeviceID = managementObject[ConstStringHardwareStatic.BATTERY_DEVICE_ID]?.ToString() ?? string.Empty;
            battery.FullChargeCapacity = new UnitValue(Unit.MWH, managementObject[ConstStringHardwareStatic.BATTERY_FULLY_CHARGE_CAPACITY]?.ToString() ?? string.Empty);
            battery.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            battery.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;

            return battery;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_BATTERY);
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
