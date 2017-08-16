using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Memory : HardwareStaticComponent
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
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_MEMORY);
        }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            Memory memory = new Memory();
            memory.BankLabel = managementObject[ConstString.MEMORY_BANK_LABEL]?.ToString() ?? string.Empty;
            memory.Capacity = new UnitValue(Unit.B, managementObject[ConstString.MEMORY_CAPACITY]?.ToString() ?? string.Empty);
            memory.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            memory.ConfiguredClockSpeed = new UnitValue(Unit.MHZ, managementObject[ConstString.MEMORY_CONFIGURED_CLOCK_SPEED]?.ToString() ?? string.Empty);
            memory.ConfiguredVoltage = new UnitValue(Unit.MV, managementObject[ConstString.MEMORY_CONFIGURED_VOLTAGE]?.ToString() ?? string.Empty);
            memory.DataWidth = new UnitValue(Unit.BIT, managementObject[ConstString.MEMORY_DATA_WIDTH]?.ToString() ?? string.Empty);
            memory.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            memory.DeviceLocator = managementObject[ConstString.MEMORY_DEVICE_LOCATOR]?.ToString() ?? string.Empty;
            memory.Manufacturer = managementObject[ConstString.MEMORY_MANUFACTURER]?.ToString() ?? string.Empty;

            memory.MaxVoltage = new UnitValue(Unit.MV, managementObject[ConstString.MEMORY_MAX_VOLTAGE]?.ToString() ?? string.Empty);
            if (managementObject[ConstString.MEMORY_MEMORY_TYPE] != null)
            {
                memory.MemoryType = ((MemoryTypeEnum)((ushort)managementObject[ConstString.MEMORY_MEMORY_TYPE])).ToString();
            }
            else
            {
                memory.MemoryType = string.Empty;
            }

            memory.MinVoltage = new UnitValue(Unit.MV, managementObject[ConstString.MEMORY_MIN_VOLTAGE]?.ToString() ?? string.Empty);
            memory.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            memory.PartNumber = managementObject[ConstString.MEMORY_PART_NUMBER]?.ToString() ?? string.Empty;
            memory.SerialNumber = managementObject[ConstString.MEMORY_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            memory.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;
            memory.TotalWidth = new UnitValue(Unit.BIT, managementObject[ConstString.MEMORY_TOTAL_WIDTH]?.ToString() ?? string.Empty);

            return memory;
        }
    }
}
