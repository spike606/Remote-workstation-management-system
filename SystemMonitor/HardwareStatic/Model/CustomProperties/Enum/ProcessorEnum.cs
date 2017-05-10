using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enum
{
    [SuppressMessage("StyleCop.Analyzers", "SA1300:ElementsMustBeginWithAnUppercaseLetter", Justification = "Enum values")]
    internal enum ArchitectureEnum
    {
        x86,
        MIPS,
        Alpha,
        PowerPC,
        ARM = 5,
        ia64,
        x64 = 9
    }
}
