using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic
{
    internal class ConstStringHardwareStatic
    {
        internal const string WMI_QUERY_PROCESSOR = "select * from Win32_Processor";
        internal const string PROCESSOR_NAME = "name";
    }
}
