using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enums
{
    internal enum DriveTypeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394173(v=vs.85).aspx
        Unknown,
        [EnumDescription("No Root Directory")]
        NoRootDirectory,
        [EnumDescription("Removable Disk")]
        RemovableDisk,
        [EnumDescription("Local Disk")]
        LocalDisk,
        [EnumDescription("Network Drive")]
        NetworkDrive,
        [EnumDescription("Compact Disc")]
        CompactDisc,
        RAMDisk
    }
}
