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
    public class Memory : HardwareComponent
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

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_MEMORY);
        }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            Memory memory = new Memory();
            memory.BankLabel = managementObject[ConstStringHardwareStatic.MEMORY_BANK_LABEL]?.ToString() ?? string.Empty;
            memory.Capacity = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.MEMORY_CAPACITY]?.ToString() ?? string.Empty);
            memory.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            memory.ConfiguredClockSpeed = new UnitValue(Unit.MHZ, managementObject[ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED]?.ToString() ?? string.Empty);
            memory.ConfiguredVoltage = new UnitValue(Unit.MV, managementObject[ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE]?.ToString() ?? string.Empty);
            memory.DataWidth = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.MEMORY_DATA_WIDTH]?.ToString() ?? string.Empty);
            memory.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            memory.DeviceLocator = managementObject[ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR]?.ToString() ?? string.Empty;
            memory.Manufacturer = managementObject[ConstStringHardwareStatic.MEMORY_MANUFACTURER]?.ToString() ?? string.Empty;

            memory.MaxVoltage = new UnitValue(Unit.MV, managementObject[ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE]?.ToString() ?? string.Empty);
            if (managementObject[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE] != null)
            {
                memory.MemoryType = ((MemoryTypeEnum)((ushort)managementObject[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE])).ToString();
            }
            else
            {
                memory.MemoryType = string.Empty;
            }

            memory.MinVoltage = new UnitValue(Unit.MV, managementObject[ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE]?.ToString() ?? string.Empty);
            memory.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            memory.PartNumber = managementObject[ConstStringHardwareStatic.MEMORY_PART_NUMBER]?.ToString() ?? string.Empty;
            memory.SerialNumber = managementObject[ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            memory.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            memory.TotalWidth = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH]?.ToString() ?? string.Empty);

            return memory;
        }
    }
}
