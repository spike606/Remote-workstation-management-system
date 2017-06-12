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
    public class Processor : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394373(v=vs.85).aspx
        public UnitValue AddressWidth { get; private set; }

        public string Architecture { get; private set; }

        public UnitValue DataWidth { get; private set; }

        public UnitValue BusSpeed { get; private set; }

        public string Manufacturer { get; private set; }

        public UnitValue MaxClockSpeed { get; private set; }

        public string NumberOfCores { get; private set; }

        public string NumberOfLogicalProcessors { get; private set; }

        public string ProcessorID { get; private set; }

        public string SerialNumber { get; private set; }

        public string SocketDesignation { get; private set; }

        public string Stepping { get; private set; }

        public string ThreadCount { get; private set; }

        public string UniqueId { get; private set; }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_PROCESSOR);
        }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            Processor processor = new Processor();
            processor.AddressWidth = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.PROCESSOR_ADDRESS_WIDTH]?.ToString() ?? string.Empty);

            if (managementObject[ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE] != null)
            {
                processor.Architecture = ((ArchitectureEnum)((ushort)managementObject[ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE])).ToString();
            }
            else
            {
                processor.Architecture = string.Empty;
            }

            processor.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            processor.DataWidth = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH]?.ToString() ?? string.Empty);
            processor.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            processor.BusSpeed = new UnitValue(Unit.MHZ, managementObject[ConstStringHardwareStatic.PROCESSOR_BUS_SPEED]?.ToString() ?? string.Empty);
            processor.Manufacturer = managementObject[ConstStringHardwareStatic.PROCESSOR_MANUFACTURER]?.ToString() ?? string.Empty;
            processor.MaxClockSpeed = new UnitValue(Unit.MHZ, managementObject[ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED]?.ToString() ?? string.Empty);
            processor.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            processor.NumberOfCores = managementObject[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES]?.ToString() ?? string.Empty;
            processor.NumberOfLogicalProcessors = managementObject[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS]?.ToString() ?? string.Empty;
            processor.ProcessorID = managementObject[ConstStringHardwareStatic.PROCESSOR_ID]?.ToString() ?? string.Empty;
            processor.SerialNumber = managementObject[ConstStringHardwareStatic.PROCESSOR_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            processor.SocketDesignation = managementObject[ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION]?.ToString() ?? string.Empty;
            processor.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            processor.Stepping = managementObject[ConstStringHardwareStatic.PROCESSOR_STEPPING]?.ToString() ?? string.Empty;
            processor.ThreadCount = managementObject[ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT]?.ToString() ?? string.Empty;
            processor.UniqueId = managementObject[ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID]?.ToString() ?? string.Empty;
            return processor;
        }
    }
}
