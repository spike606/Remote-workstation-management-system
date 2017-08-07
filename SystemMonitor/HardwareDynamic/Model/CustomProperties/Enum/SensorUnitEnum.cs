using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemMonitor.HardwareDynamic.Model.CustomProperties.Enum
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
        GigaByte
    }
}
