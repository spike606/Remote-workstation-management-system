using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enums
{
    internal enum MemoryTypeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394347(v=vs.85).aspx
        Unknown,
        Other,
        DRAM,
        [EnumDescription("Synchronous DRAM")]
        SynchronousDRAM,
        [EnumDescription("Cache DRAM")]
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
        [EnumDescription("3DRAM")]
        THREE_DRAM,
        SDRAM,
        SGRAM,
        RDRAM,
        DDR,
        DDR2,
        [EnumDescription("DDR2 FB-DIMM")]
        DDR2FBDIMM,
        DDR3 = 24,
        FBD2
    }
}
