using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class ProcessorCache : HardwareStaticComponent, IHardwareStaticComponent<ProcessorCache>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394080(v=vs.85).aspx
        public UnitValue Speed { get; private set; }

        public UnitValue Size { get; private set; }

        public string Level { get; private set; }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_CACHE_MEMORY);
        }

        public List<ProcessorCache> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<ProcessorCache> staticData = new List<ProcessorCache>();

            foreach (var managementObject in managementObjectList)
            {
                ProcessorCache processorCache = new ProcessorCache();
                processorCache.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
                processorCache.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
                processorCache.Level = ((CacheLevelEnum)((ushort)managementObject[ConstString.PROCESSOR_CACHE_LEVEL])).ToString();
                processorCache.Size = new UnitValue(Unit.KB, managementObject[ConstString.PROCESSOR_CACHE_SIZE]?.ToString() ?? string.Empty);
                processorCache.Speed = new UnitValue(Unit.MHZ, managementObject[ConstString.PROCESSOR_CACHE_SPEED]?.ToString() ?? string.Empty);
                processorCache.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;
                processorCache.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;

                staticData.Add(processorCache);
            }

            return staticData;
        }
    }
}
