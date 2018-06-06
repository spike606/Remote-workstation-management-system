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
    public class Memory : HardwareStaticComponent, IHardwareStaticComponent<Memory>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394347(v=vs.85).aspx
        [DataMember]
        public string BankLabel { get; private set; }

        [DataMember]
        public UnitULongValue Capacity { get; private set; }

        [DataMember]
        public UnitUIntValue ConfiguredClockSpeed { get; private set; }

        [DataMember]
        public UnitUIntValue ConfiguredVoltage { get; private set; }

        [DataMember]
        public UnitUShortValue DataWidth { get; private set; }

        [DataMember]
        public string DeviceLocator { get; private set; }

        [DataMember]
        public string Manufacturer { get; private set; }

        [DataMember]
        public UnitUIntValue MaxVoltage { get; private set; }

        [DataMember]
        public string MemoryType { get; private set; }

        [DataMember]
        public UnitUIntValue MinVoltage { get; private set; }

        [DataMember]
        public string PartNumber { get; private set; }

        [DataMember]
        public string SerialNumber { get; private set; }

        [DataMember]
        public UnitUShortValue TotalWidth { get; private set; }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_MEMORY);
        }

        public List<Memory> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Memory> staticData = new List<Memory>();

            foreach (var managementObject in managementObjectList)
            {
                Memory memory = new Memory();
                memory.BankLabel = managementObject[ConstString.MEMORY_BANK_LABEL].TryGetStringValue();
                memory.Capacity = managementObject[ConstString.MEMORY_CAPACITY].TryGetUnitULongValue(Unit.B);
                memory.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                memory.ConfiguredClockSpeed = managementObject[ConstString.MEMORY_CONFIGURED_CLOCK_SPEED].TryGetUnitUIntValue(Unit.MHZ);
                memory.ConfiguredVoltage = managementObject[ConstString.MEMORY_CONFIGURED_VOLTAGE].TryGetUnitUIntValue(Unit.MV);
                memory.DataWidth = managementObject[ConstString.MEMORY_DATA_WIDTH].TryGetUnitUShortValue(Unit.BIT);
                memory.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                memory.DeviceLocator = managementObject[ConstString.MEMORY_DEVICE_LOCATOR].TryGetStringValue();
                memory.Manufacturer = managementObject[ConstString.MEMORY_MANUFACTURER].TryGetStringValue();

                memory.MaxVoltage = managementObject[ConstString.MEMORY_MAX_VOLTAGE].TryGetUnitUIntValue(Unit.MV);
                if (managementObject[ConstString.MEMORY_MEMORY_TYPE] != null)
                {
                    memory.MemoryType = ((MemoryTypeEnum)((ushort)managementObject[ConstString.MEMORY_MEMORY_TYPE])).ToString();
                }
                else
                {
                    memory.MemoryType = string.Empty;
                }

                memory.MinVoltage = managementObject[ConstString.MEMORY_MIN_VOLTAGE].TryGetUnitUIntValue(Unit.MV);
                memory.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                memory.PartNumber = managementObject[ConstString.MEMORY_PART_NUMBER].TryGetStringValue();
                memory.SerialNumber = managementObject[ConstString.MEMORY_SERIAL_NUMBER].TryGetStringValue();
                memory.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                memory.TotalWidth = managementObject[ConstString.MEMORY_TOTAL_WIDTH].TryGetUnitUShortValue(Unit.BIT);

                staticData.Add(memory);
            }

            return staticData;
        }
    }
}
