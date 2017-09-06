using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Printer : HardwareStaticComponent, IHardwareStaticComponent<Printer>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394363(v=vs.85).aspx
        public string AveragePagesPerMinute { get; private set; }

        public string Default { get; private set; }

        public string DeviceID { get; private set; }

        public string PortName { get; private set; }

        public string PrintProcessor { get; private set; }

        public List<Printer> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Printer> staticData = new List<Printer>();

            foreach (var managementObject in managementObjectList)
            {
                Printer printer = new Printer();
                printer.AveragePagesPerMinute = managementObject[ConstString.PRINTER_AVG_PAGES_PER_MINUTE]?.ToString() ?? string.Empty;
                printer.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
                printer.Default = managementObject[ConstString.PRINTER_DEFAULT]?.ToString() ?? string.Empty;
                printer.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
                printer.DeviceID = managementObject[ConstString.PRINTER_DEVICE_ID]?.ToString() ?? string.Empty;
                printer.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
                printer.PortName = managementObject[ConstString.PRINTER_PORT_NAME]?.ToString() ?? string.Empty;
                printer.PrintProcessor = managementObject[ConstString.PRINTER_PRINT_PROCESSOR]?.ToString() ?? string.Empty;
                printer.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;

                staticData.Add(printer);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_PRINTER);
        }
    }
}
