using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums
{
    [SuppressMessage("StyleCop.Analyzers", "SA1300:ElementsMustBeginWithAnUppercaseLetter", Justification = "Enum values")]
    internal enum NdisMediumEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/hh968170(v=vs.85).aspx
        [EnumDescription("802.3")]
        _802_3,
        [EnumDescription("802.5")]
        _802_5,
        FDDI,
        WAN,
        LocalTalk,
        DIX,
        [EnumDescription("Raw Arcnet")]
        RawArcnet,
        [EnumDescription("878.2")]
        _878_2,
        ATM,
        [EnumDescription("Wireless WAN")]
        WirelessWAN,
        IRDA,
        BPC,
        [EnumDescription("Connection Oriented WAN")]
        ConnectionOrientedWAN,
        [EnumDescription("IP 1394")]
        IP1394,
        IB,
        Tunnel,
        [EnumDescription("Native 802.11")]
        Native802_11,
        Loopback,
        WiMAX,
        IP
    }

    [SuppressMessage("StyleCop.Analyzers", "SA1300:ElementsMustBeginWithAnUppercaseLetter", Justification = "Enum values")]
    internal enum NdisPhysicalMediumEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/hh968170(v=vs.85).aspx
        Unspecified,
        [EnumDescription("Wireless LAN")]
        WirelessLAN,
        [EnumDescription("Cable Modem")]
        CableModem,
        [EnumDescription("Phone Line")]
        PhoneLine,
        [EnumDescription("Power Line")]
        PowerLine,
        DSL,
        FC,
        [EnumDescription("1394")]
        _1394,
        [EnumDescription("Wireless WAN")]
        WirelessWAN,
        [EnumDescription("Native 802.11")]
        Native802_11,
        BlueTooth,
        Infiniband,
        WiMAX,
        UWB,
        [EnumDescription("802.3")]
        _802_3,
        [EnumDescription("802.5")]
        _802_5,
        IRDA,
        [EnumDescription("Wired WAN")]
        WiredWAN,
        [EnumDescription("Wired Connection Oriented WAN")]
        WiredConnectionOrientedWAN,
        Other
    }
}
