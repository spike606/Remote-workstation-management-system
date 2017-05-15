using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enum
{
    internal enum MemoryTypeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394080(v=vs.85).aspx
        Unknown,
        Other,
        DRAM,
        SynchronousDRAM,
        CacheDRAM,
        EDO,
        EDRAM,
        VRAM,
        SRAM,
        RAM,
        ROM,
        Flash,
        EEPROM,
        FEPROM,
        EPROM,
        CDRAM,
        THREE_DRAM,
        SDRAM,
        SGRAM,
        RDRAM,
        DDR,
        DDR2,
        DDR2FBDIMM,
        DDR3 = 24,
        FBD2
    }
}
