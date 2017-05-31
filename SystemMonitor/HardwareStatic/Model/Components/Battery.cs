using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Battery : IHardwareComponent
    {
        public string BatteryStatus { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public UnitValue DesignCapacity { get; set; }

        public string DeviceID { get; set; }

        public UnitValue FullChargeCapacity { get; set; }

        public string Name { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
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

            battery.Caption = managementObject[ConstStringHardwareStatic.BATTERY_CAPTION]?.ToString() ?? string.Empty;
            battery.Description = managementObject[ConstStringHardwareStatic.BATTERY_DESCRIPTION]?.ToString() ?? string.Empty;
            battery.DesignCapacity = new UnitValue(Unit.MWH, managementObject[ConstStringHardwareStatic.BATTERY_DESIGN_CAPACITY]?.ToString() ?? string.Empty);
            battery.DeviceID = managementObject[ConstStringHardwareStatic.BATTERY_DEVICE_ID]?.ToString() ?? string.Empty;
            battery.FullChargeCapacity = new UnitValue(Unit.MWH, managementObject[ConstStringHardwareStatic.BATTERY_FULLY_CHARGE_CAPACITY]?.ToString() ?? string.Empty);
            battery.Name = managementObject[ConstStringHardwareStatic.BATTERY_NAME]?.ToString() ?? string.Empty;

            return battery;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_BATTERY);
        }

        /*
         * DYNAMIC DATA
         */

        //public UnitValue DesignVoltage { get; set; }

        //public UnitValue EstimatedChargeRemaining { get; set; } //lenovo y580 - shows battery charge status in %, not remaining charge?!

        //public UnitValue EstimatedRunTime { get; set; } //lenovo y580 - when charging shows very large irrational number?!

        //public UnitValue TimeOnBattery { get; set; }

        //public UnitValue TimeToFullCharge { get; set; }
    }
}
