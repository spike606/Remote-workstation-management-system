using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class BaseBoard : IHardwareComponent
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public string PartNumber { get; set; }

        public string Product { get; set; }

        public string SerialNumber { get; set; }

        public string Version { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            BaseBoard baseBoard = new BaseBoard();
            baseBoard.Caption = managementObject[ConstStringHardwareStatic.BASE_BOARD_CAPTION]?.ToString() ?? string.Empty;
            baseBoard.Description = managementObject[ConstStringHardwareStatic.BASE_BOARD_DESCRIPTION]?.ToString() ?? string.Empty;
            baseBoard.Manufacturer = managementObject[ConstStringHardwareStatic.BASE_BOARD_MANUFACTURER]?.ToString() ?? string.Empty;
            baseBoard.Model = managementObject[ConstStringHardwareStatic.BASE_BOARD_MODEL]?.ToString() ?? string.Empty;
            baseBoard.Name = managementObject[ConstStringHardwareStatic.BASE_BOARD_NAME]?.ToString() ?? string.Empty;
            baseBoard.PartNumber = managementObject[ConstStringHardwareStatic.BASE_BOARD_PART_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Product = managementObject[ConstStringHardwareStatic.BASE_BOARD_PRODUCT]?.ToString() ?? string.Empty;
            baseBoard.SerialNumber = managementObject[ConstStringHardwareStatic.BASE_BOARD_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Version = managementObject[ConstStringHardwareStatic.BASE_BOARD_VERSION]?.ToString() ?? string.Empty;

            return baseBoard;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_BASE_BOARD);
        }
    }
}
