using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Memory : IHardwareComponent
    {
        public string BankLabel { get; set; }

        public UnitValue Capacity { get; set; }

        public string Caption { get; set; }

        public UnitValue ConfiguredClockSpeed { get; set; }

        public UnitValue ConfiguredVoltage { get; set; }

        public UnitValue DataWidth { get; set; }

        public string Description { get; set; }

        public string DeviceLocator { get; set; }

        public string Manufacturer { get; set; }

        public UnitValue MaxVoltage { get; set; }

        public string MemoryType { get; set; }

        public UnitValue MinVoltage { get; set; }

        public string Name { get; set; }

        public string PartNumber { get; set; }

        public string SerialNumber { get; set; }

        public UnitValue TotalWidth { get; set; }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_MEMORY);
        }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            Memory memory = new Memory();
            memory.BankLabel = managementObject[ConstStringHardwareStatic.MEMORY_BANK_LABEL]?.ToString() ?? string.Empty;
            memory.Capacity = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.MEMORY_CAPACITY]?.ToString() ?? string.Empty);
            memory.Caption = managementObject[ConstStringHardwareStatic.MEMORY_CAPTION]?.ToString() ?? string.Empty;
            //memory.ConfiguredClockSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED]?.ToString() ?? string.Empty);
            //memory.ConfiguredVoltage = new UnitValue(Unit.MV, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE]?.ToString() ?? string.Empty);
            memory.DataWidth = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.MEMORY_DATA_WIDTH]?.ToString() ?? string.Empty);
            memory.Description = managementObject[ConstStringHardwareStatic.MEMORY_DESCRIPTION]?.ToString() ?? string.Empty;
            memory.DeviceLocator = managementObject[ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR]?.ToString() ?? string.Empty;
            memory.Manufacturer = managementObject[ConstStringHardwareStatic.MEMORY_MANUFACTURER]?.ToString() ?? string.Empty;
            //memory.MaxVoltage = new UnitValue(Unit.MV, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE]?.ToString() ?? string.Empty);

            if (managementObject[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE] != null)
            {
                memory.MemoryType = ((MemoryTypeEnum)((ushort)managementObject[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE])).ToString();
            }
            else
            {
                memory.MemoryType = string.Empty;
            }

            //memory.MinVoltage = new UnitValue(Unit.MV, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE]?.ToString() ?? string.Empty);
            memory.Name = managementObject[ConstStringHardwareStatic.MEMORY_NAME]?.ToString() ?? string.Empty;
            memory.PartNumber = managementObject[ConstStringHardwareStatic.MEMORY_PART_NUMBER]?.ToString() ?? string.Empty;
            memory.SerialNumber = managementObject[ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            memory.TotalWidth = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH]?.ToString() ?? string.Empty);

            return memory;
        }
    }
}
