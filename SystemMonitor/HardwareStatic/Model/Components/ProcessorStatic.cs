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
    public class ProcessorStatic : HardwareStaticComponent, IHardwareStaticComponent<ProcessorStatic>
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

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_PROCESSOR);
        }

        public List<ProcessorStatic> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<ProcessorStatic> staticData = new List<ProcessorStatic>();

            foreach (var managementObject in managementObjectList)
            {
                ProcessorStatic processor = new ProcessorStatic();
                processor.AddressWidth = managementObject[ConstString.PROCESSOR_ADDRESS_WIDTH].TryGetUnitValue(Unit.BIT);

                if (managementObject[ConstString.PROCESSOR_ARCHITECTURE] != null)
                {
                    processor.Architecture = ((ArchitectureEnum)((ushort)managementObject[ConstString.PROCESSOR_ARCHITECTURE])).ToString();
                }
                else
                {
                    processor.Architecture = string.Empty;
                }

                processor.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                processor.DataWidth = managementObject[ConstString.PROCESSOR_DATA_WIDTH].TryGetUnitValue(Unit.BIT);
                processor.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                processor.BusSpeed = managementObject[ConstString.PROCESSOR_BUS_SPEED].TryGetUnitValue(Unit.MHZ);
                processor.Manufacturer = managementObject[ConstString.PROCESSOR_MANUFACTURER].TryGetStringValue();
                processor.MaxClockSpeed = managementObject[ConstString.PROCESSOR_MAX_CLOCK_SPEED].TryGetUnitValue(Unit.MHZ);
                processor.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                processor.NumberOfCores = managementObject[ConstString.PROCESSOR_NUMBER_OF_CORES].TryGetStringValue();
                processor.NumberOfLogicalProcessors = managementObject[ConstString.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS].TryGetStringValue();
                processor.ProcessorID = managementObject[ConstString.PROCESSOR_ID].TryGetStringValue();
                processor.SerialNumber = managementObject[ConstString.PROCESSOR_SERIAL_NUMBER].TryGetStringValue();
                processor.SocketDesignation = managementObject[ConstString.PROCESSOR_SOCKET_DESIGNATION].TryGetStringValue();
                processor.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                processor.Stepping = managementObject[ConstString.PROCESSOR_STEPPING].TryGetStringValue();
                processor.ThreadCount = managementObject[ConstString.PROCESSOR_THREAD_COUNT].TryGetStringValue();
                processor.UniqueId = managementObject[ConstString.PROCESSOR_UNIQUE_ID].TryGetStringValue();

                staticData.Add(processor);
            }

            return staticData;
        }
    }
}
