using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums
{
    public enum SmartDataAttributeStatusEnum
    {
        [EnumDescription("OK - THRESHOLD VALUED NOT REACHED, SEE RAW VALUE FOR MORE SPECIFIC INFO")]
        OK_THRESHOLD_NOT_REACHED,
        [EnumDescription("FAILED - THRESHOLD VALUE REACHED")]
        FAILED,
        [EnumDescription("FAILED - THRESHOLD VALUE REACHED FOR CRITICAL ATTRIBUTE!")]
        FAILED_CRITICAL,
        [EnumDescription("THRESHOLD NOT DEFINED, SEE RAW VALUE FOR MORE SPECIFIC INFO")]
        THRESHOLD_NOT_DEFINED
    }

    public enum RawIdealEnum
    {
        [EnumDescription("Lower raw value is better")]
        LOW,
        [EnumDescription("Higher raw value is better")]
        HIGH,
        [EnumDescription("Not applicable")]
        NONE
    }
}
