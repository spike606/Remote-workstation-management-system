using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Builder
{
    internal class HardwareStaticBuilder
    {
        // IoC
        internal Processor GetProcessorStaticData()
        {
            Processor processor = new Processor();
            WMIDataExtractor extractor = new WMIDataExtractor();
            WMIClient client = new WMIClient();
            ManagementObject obj = client.RetriveObjectByExecutingWMIQuery(ConstStringHardwareStatic.WMI_QUERY_PROCESSOR);
            processor = extractor.ExtractDataProcessor(obj);
            return processor;
        }
    }
}
