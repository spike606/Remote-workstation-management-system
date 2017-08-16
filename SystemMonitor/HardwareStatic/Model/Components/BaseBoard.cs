﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class BaseBoard : HardwareStaticComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394072(v=vs.85).aspx
        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public string PartNumber { get; private set; }

        public string Product { get; private set; }

        public string SerialNumber { get; private set; }

        public string Version { get; private set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            BaseBoard baseBoard = new BaseBoard();
            baseBoard.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            baseBoard.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            baseBoard.Manufacturer = managementObject[ConstString.BASE_BOARD_MANUFACTURER]?.ToString() ?? string.Empty;
            baseBoard.Model = managementObject[ConstString.BASE_BOARD_MODEL]?.ToString() ?? string.Empty;
            baseBoard.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            baseBoard.PartNumber = managementObject[ConstString.BASE_BOARD_PART_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Product = managementObject[ConstString.BASE_BOARD_PRODUCT]?.ToString() ?? string.Empty;
            baseBoard.SerialNumber = managementObject[ConstString.BASE_BOARD_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;
            baseBoard.Version = managementObject[ConstString.BASE_BOARD_VERSION]?.ToString() ?? string.Empty;

            return baseBoard;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_BASE_BOARD);
        }
    }
}
