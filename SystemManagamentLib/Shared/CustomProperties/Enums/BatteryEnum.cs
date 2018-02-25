using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums
{
    internal enum BatteryStatus
    {
        Other = 1,
        Unknown,
        [EnumDescription("Fully Charged")]
        FullyCharged,
        Low,
        Critical,
        Charging,
        [EnumDescription("Charging And High")]
        ChargingAndHigh,
        [EnumDescription("Charging And Low")]
        ChargingAndLow,
        [EnumDescription("Charging And Critical")]
        ChargingAndCritical,
        Undefined,
        [EnumDescription("Partially Charged")]
        PartiallyCharged
    }
}
