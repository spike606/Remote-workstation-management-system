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
        // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394373(v=vs.85).aspx
        x86,
        MIPS,
        Alpha,
        PowerPC,
        ARM = 5,
        ia64,
        x64 = 9
    }

    internal enum CacheLevelEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394080(v=vs.85).aspx
        Other = 1,
        Unknown,
        L1, // Primary
        L2, // Secondary
        L3, // Tertiary
        NotApplicable
    }
}
