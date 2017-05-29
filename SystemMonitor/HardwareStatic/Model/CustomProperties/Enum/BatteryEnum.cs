using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enum
{
    internal enum BatteryStatus
    {
        Other = 1,
        Unknown,
        FullyCharged,
        Low,
        Critical,
        Charging,
        ChargingAndHigh,
        ChargingAndLow,
        ChargingAndCritical,
        Undefined,
        PartiallyCharged
    }
}
