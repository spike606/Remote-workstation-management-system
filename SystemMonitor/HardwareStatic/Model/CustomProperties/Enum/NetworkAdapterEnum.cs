using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enum
{
    [SuppressMessage("StyleCop.Analyzers", "SA1300:ElementsMustBeginWithAnUppercaseLetter", Justification = "Enum values")]
    internal enum NdisMediumEnum
    {
        _802_3,
        _802_5,
        FDDI,
        WAN,
        LocalTalk,
        DIX,
        RawArcnet,
        _878_2,
        ATM,
        WirelessWAN,
        IRDA,
        BPC,
        ConnectionOrientedWAN,
        IP1394,
        IB,
        Tunnel,
        Native802_11,
        Loopback,
        WiMAX,
        IP
    }

    [SuppressMessage("StyleCop.Analyzers", "SA1300:ElementsMustBeginWithAnUppercaseLetter", Justification = "Enum values")]
    internal enum NdisPhysicalMediumEnum
    {
        Unspecified,
        WirelessLAN,
        CableModem,
        PhoneLine,
        PowerLine,
        DSL,
        FC,
        _1394,
        WirelessWAN,
        Native802_11,
        BlueTooth,
        Infiniband,
        WiMAX,
        UWB,
        _802_3,
        _802_5,
        IRDA,
        WiredWAN,
        WiredConnectionOrientedWAN,
        Other
    }
}
