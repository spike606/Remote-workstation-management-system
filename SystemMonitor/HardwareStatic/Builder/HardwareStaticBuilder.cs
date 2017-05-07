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
    internal class HardwareStaticBuilder : IHardwareStaticBuilder
    {
        public HardwareStaticBuilder(IWMIClient wmiClient, IWMIDataExtractor wmiDataExtractor)
        {
            this.WMIClient = wmiClient;
            this.WMIDataExtractor = wmiDataExtractor;
        }

        private IWMIClient WMIClient { get; set; }

        private IWMIDataExtractor WMIDataExtractor { get; set; }

        public Processor GetProcessorStaticData()
        {
            ManagementObject managementObject = this.WMIClient.RetriveObjectByExecutingWMIQuery(ConstStringHardwareStatic.WMI_QUERY_PROCESSOR);
            return this.WMIDataExtractor.ExtractDataProcessor(managementObject);
        }
    }
}
