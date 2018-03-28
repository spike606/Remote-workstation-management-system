using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class ProcessorCache : HardwareStaticComponent, IHardwareStaticComponent<ProcessorCache>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394080(v=vs.85).aspx
        [DataMember]
        public UnitValue Speed { get; private set; }

        [DataMember]
        public UnitValue Size { get; private set; }

        [DataMember]
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
                processorCache.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                processorCache.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                processorCache.Level = ((CacheLevelEnum)((ushort)managementObject[ConstString.PROCESSOR_CACHE_LEVEL])).ToString();
                processorCache.Size = managementObject[ConstString.PROCESSOR_CACHE_SIZE].TryGetUnitValue(Unit.KB);
                processorCache.Speed = managementObject[ConstString.PROCESSOR_CACHE_SPEED].TryGetUnitValue(Unit.MHZ);
                processorCache.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                processorCache.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();

                staticData.Add(processorCache);
            }

            return staticData;
        }
    }
}
