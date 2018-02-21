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

                battery.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                battery.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                battery.DesignCapacity = managementObject[ConstString.BATTERY_DESIGN_CAPACITY].TryGetUnitValue(Unit.MWH);
                battery.DeviceID = managementObject[ConstString.BATTERY_DEVICE_ID].TryGetStringValue();
                battery.FullChargeCapacity = managementObject[ConstString.BATTERY_FULLY_CHARGE_CAPACITY].TryGetUnitValue(Unit.MWH);
                battery.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                battery.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();

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
