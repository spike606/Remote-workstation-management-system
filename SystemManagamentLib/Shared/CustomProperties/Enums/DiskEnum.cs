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
    internal enum BusTypeEnum
    {
        Unknown,
        SCSI,
        ATAPI,
        ATA,
        [EnumDescription("IEEE 1394")]
        IEEE1394,
        SSA,
        [EnumDescription("Fibre Channel")]
        FibreChannel,
        USB,
        RAID,
        iSCSI,
        [EnumDescription("Serial Attached SCSI (SAS)")]
        SAS,
        [EnumDescription("Serial ATA (SATA)")]
        SATA,
        [EnumDescription("Secure Digital (SD)")]
        SD,
        [EnumDescription("Multimedia Card (MMC)")]
        MMC,
        [EnumDescription("Virtual - This value is reserved for system use.")]
        Virtual,
        [EnumDescription("File-Backed Virtual")]
        FileBackedVirtual,
        [EnumDescription("Storage spaces")]
        StorageSpaces,
        NVMe
    }
}
