using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    public class Memory : HardwareStaticComponent, IHardwareStaticComponent<Memory>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394347(v=vs.85).aspx
        public string BankLabel { get; private set; }

        public UnitValue Capacity { get; private set; }

        public UnitValue ConfiguredClockSpeed { get; private set; }

        public UnitValue ConfiguredVoltage { get; private set; }

        public UnitValue DataWidth { get; private set; }

        public string DeviceLocator { get; private set; }

        public string Manufacturer { get; private set; }

        public UnitValue MaxVoltage { get; private set; }

        public string MemoryType { get; private set; }

        public UnitValue MinVoltage { get; private set; }

        public string PartNumber { get; private set; }

        public string SerialNumber { get; private set; }

        public UnitValue TotalWidth { get; private set; }

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
                memory.Capacity = managementObject[ConstString.MEMORY_CAPACITY].TryGetUnitValue(Unit.B);
                memory.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                memory.ConfiguredClockSpeed = managementObject[ConstString.MEMORY_CONFIGURED_CLOCK_SPEED].TryGetUnitValue(Unit.MHZ);
                memory.ConfiguredVoltage = managementObject[ConstString.MEMORY_CONFIGURED_VOLTAGE].TryGetUnitValue(Unit.MV);
                memory.DataWidth = managementObject[ConstString.MEMORY_DATA_WIDTH].TryGetUnitValue(Unit.MV);
                memory.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                memory.DeviceLocator = managementObject[ConstString.MEMORY_DEVICE_LOCATOR].TryGetStringValue();
                memory.Manufacturer = managementObject[ConstString.MEMORY_MANUFACTURER].TryGetStringValue();

                memory.MaxVoltage = managementObject[ConstString.MEMORY_MAX_VOLTAGE].TryGetUnitValue(Unit.MV);
                if (managementObject[ConstString.MEMORY_MEMORY_TYPE] != null)
                {
                    memory.MemoryType = ((MemoryTypeEnum)((ushort)managementObject[ConstString.MEMORY_MEMORY_TYPE])).ToString();
                }
                else
                {
                    memory.MemoryType = string.Empty;
                }

                memory.MinVoltage = managementObject[ConstString.MEMORY_MIN_VOLTAGE].TryGetUnitValue(Unit.MV);
                memory.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                memory.PartNumber = managementObject[ConstString.MEMORY_PART_NUMBER].TryGetStringValue();
                memory.SerialNumber = managementObject[ConstString.MEMORY_SERIAL_NUMBER].TryGetStringValue();
                memory.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                memory.TotalWidth = managementObject[ConstString.MEMORY_TOTAL_WIDTH].TryGetUnitValue(Unit.MV);

                staticData.Add(memory);
            }

            return staticData;
        }
    }
}
