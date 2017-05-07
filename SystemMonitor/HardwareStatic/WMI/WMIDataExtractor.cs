using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;

namespace SystemMonitor.HardwareStatic.WMI
{
    internal class WMIDataExtractor : IWMIDataExtractor
    {
        public Processor ExtractDataProcessor(ManagementObject managementObject)
        {
            Processor processor = new Processor();
            processor.Name = (string)managementObject[ConstStringHardwareStatic.PROCESSOR_NAME];
            return processor;
        }
    }
}
