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

        public List<Memory> GetMemoryStaticData()
        {
            List<ManagementObject> managementObjectWin32_PhysicalMemory = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_QUERY_MEMORY);

            List<Memory> memoryStaticData = new List<Memory>();

            foreach (var memoryObject in managementObjectWin32_PhysicalMemory)
            {
                memoryStaticData.Add(this.WMIDataExtractor.ExtractDataMemory(memoryObject));
            }

            return memoryStaticData;
        }

        public Processor GetProcessorStaticData()
        {
            ManagementObject managementObjectWin32_Processor = this.WMIClient.RetriveObjectByExecutingWMIQuery(ConstStringHardwareStatic.WMI_QUERY_PROCESSOR);
            ManagementObject managementObjectWin32_CacheMemory = this.WMIClient.RetriveObjectByExecutingWMIQuery(ConstStringHardwareStatic.WMI_QUERY_CACHE_MEMORY);

            return this.WMIDataExtractor.ExtractDataProcessor(managementObjectWin32_Processor, managementObjectWin32_CacheMemory);
        }
    }
}
