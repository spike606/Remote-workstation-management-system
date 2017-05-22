using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enum
{
    public enum DriveTypeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394173(v=vs.85).aspx
        Unknown,
        NoRootDirectory,
        RemovableDisk,
        LocalDisk,
        NetworkDrive,
        CompactDisc,
        RAMDisk
    }
}
