using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class ProcessorCache : HardwareComponent
    {
        public UnitValue Speed { get; private set; }

        public UnitValue Size { get; private set; }

        public string Level { get; private set; }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_CACHE_MEMORY);
        }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            ProcessorCache processorCache = new ProcessorCache();
            processorCache.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            processorCache.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            processorCache.Level = ((CacheLevelEnum)((ushort)managementObject[ConstStringHardwareStatic.PROCESSOR_CACHE_LEVEL])).ToString();
            processorCache.Size = new UnitValue(Unit.KB, managementObject[ConstStringHardwareStatic.PROCESSOR_CACHE_SIZE]?.ToString() ?? string.Empty);
            processorCache.Speed = new UnitValue(Unit.MHZ, managementObject[ConstStringHardwareStatic.PROCESSOR_CACHE_SPEED]?.ToString() ?? string.Empty);
            processorCache.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            processorCache.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            return processorCache;
        }
    }
}
