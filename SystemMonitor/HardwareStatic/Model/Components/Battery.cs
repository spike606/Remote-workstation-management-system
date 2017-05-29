using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Battery
    {
        public string BatteryStatus { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public UnitValue DesignCapacity { get; set; }

        public string DeviceID { get; set; }

        public UnitValue FullChargeCapacity { get; set; }

        public string Name { get; set; }

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
