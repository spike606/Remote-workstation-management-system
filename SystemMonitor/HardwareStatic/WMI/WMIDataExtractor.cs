using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;

namespace SystemMonitor.HardwareStatic.WMI
{
    internal class WMIDataExtractor
    {
        internal Processor ExtractDataProcessor(ManagementObject managementObject)
        {
            Processor proc = new Processor();
            proc.Name = (string)managementObject[ConstStringHardwareStatic.PROCESSOR_NAME];
            return proc;
        }
    }
}
