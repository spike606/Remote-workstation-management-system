using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Printer : IHardwareComponent
    {
        public string AveragePagesPerMinute { get; set; }

        public string Caption { get; set; }

        public string Default { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string Name { get; set; }

        public string PortName { get; set; }

        public string PrintProcessor { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            Printer printer = new Printer();
            printer.AveragePagesPerMinute = managementObject[ConstStringHardwareStatic.PRINTER_AVG_PAGES_PER_MINUTE]?.ToString() ?? string.Empty;
            printer.Caption = managementObject[ConstStringHardwareStatic.PRINTER_CAPTION]?.ToString() ?? string.Empty;
            printer.Default = managementObject[ConstStringHardwareStatic.PRINTER_DEFAULT]?.ToString() ?? string.Empty;
            printer.Description = managementObject[ConstStringHardwareStatic.PRINTER_DESCRIPTION]?.ToString() ?? string.Empty;
            printer.DeviceID = managementObject[ConstStringHardwareStatic.PRINTER_DEVICE_ID]?.ToString() ?? string.Empty;
            printer.Name = managementObject[ConstStringHardwareStatic.PRINTER_NAME]?.ToString() ?? string.Empty;
            printer.PortName = managementObject[ConstStringHardwareStatic.PRINTER_PORT_NAME]?.ToString() ?? string.Empty;
            printer.PrintProcessor = managementObject[ConstStringHardwareStatic.PRINTER_PRINT_PROCESSOR]?.ToString() ?? string.Empty;

            return printer;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_PRINTER);
        }
    }
}
