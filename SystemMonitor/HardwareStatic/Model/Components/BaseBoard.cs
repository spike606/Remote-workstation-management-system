using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class BaseBoard : HardwareComponent
    {
        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public string PartNumber { get; private set; }

        public string Product { get; private set; }

        public string SerialNumber { get; private set; }

        public string Version { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            BaseBoard baseBoard = new BaseBoard();
            baseBoard.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            baseBoard.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            baseBoard.Manufacturer = managementObject[ConstStringHardwareStatic.BASE_BOARD_MANUFACTURER]?.ToString() ?? string.Empty;
            baseBoard.Model = managementObject[ConstStringHardwareStatic.BASE_BOARD_MODEL]?.ToString() ?? string.Empty;
            baseBoard.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            baseBoard.PartNumber = managementObject[ConstStringHardwareStatic.BASE_BOARD_PART_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Product = managementObject[ConstStringHardwareStatic.BASE_BOARD_PRODUCT]?.ToString() ?? string.Empty;
            baseBoard.SerialNumber = managementObject[ConstStringHardwareStatic.BASE_BOARD_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            baseBoard.Version = managementObject[ConstStringHardwareStatic.BASE_BOARD_VERSION]?.ToString() ?? string.Empty;

            return baseBoard;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_BASE_BOARD);
        }
    }
}
