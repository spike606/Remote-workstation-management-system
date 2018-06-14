using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Shared.CustomProperties.Enums
{
    // Based on documentation: https://msdn.microsoft.com/en-us/library/aa394507(v=vs.85).aspx
    public enum SIDTypeEnum
    {
        User = 1,
        Group,
        Domain,
        Alias,
        WellKnownGroup,
        DeletedAccount,
        Invalid,
        Unknown,
        Computer
    }
}
