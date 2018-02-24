using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemManagament.Monitor.HardwareDynamic.Model.CustomProperties.Enum
{
    public enum SensorUnit
    {
        MHZ = 0,
        [EnumDescription("Celsius degrees")]
        Celcius,
        [EnumDescription("%")]
        Percentage,
        [EnumDescription("W")]
        Watt,
        [EnumDescription("GB")]
        GigaByte,
        RPM,
        [EnumDescription("V")]
        Volt
    }
}
