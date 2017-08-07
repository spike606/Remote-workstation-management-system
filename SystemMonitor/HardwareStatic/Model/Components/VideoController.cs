using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class VideoController : HardwareStaticComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394512(v=vs.85).aspx
        public string AdapterCompatibility { get; private set; }

        public string AdapterDACType { get; private set; }

        public UnitValue AdapterRAM { get; private set; }

        public UnitValue CurrentBitsPerPixel { get; private set; }

        public UnitValue CurrentHorizontalResolution { get; private set; }

        public string CurrentNumberOfColors { get; private set; }

        public UnitValue CurrentRefreshRate { get; private set; }

        public UnitValue CurrentVerticalResolution { get; private set; }

        public string DeviceID { get; private set; }

        public string DriverVersion { get; private set; }

        public string VideoModeDescription { get; private set; }

        public string VideoProcessor { get; private set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            VideoController videoController = new VideoController();
            videoController.AdapterCompatibility = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_ADAPTER_COMPATIBILITY]?.ToString() ?? string.Empty;
            videoController.AdapterDACType = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_ADAPTER_DAC_TYPE]?.ToString() ?? string.Empty;
            videoController.AdapterRAM = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_ADAPTER_RAM]?.ToString() ?? string.Empty);
            videoController.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            videoController.CurrentBitsPerPixel = new UnitValue(Unit.BIT, managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_BITS_PER_PIXEL]?.ToString() ?? string.Empty);
            videoController.CurrentHorizontalResolution = new UnitValue(Unit.PX, managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_HORIZONTAL_RESOLUTION]?.ToString() ?? string.Empty);
            videoController.CurrentNumberOfColors = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_NUMBER_OF_COLORS]?.ToString() ?? string.Empty;
            videoController.CurrentRefreshRate = new UnitValue(Unit.HZ, managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_REFRESH_RATE]?.ToString() ?? string.Empty);
            videoController.CurrentVerticalResolution = new UnitValue(Unit.PX, managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_VERTICAL_RESOLUTION]?.ToString() ?? string.Empty);
            videoController.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            videoController.DeviceID = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_DEVICE_ID]?.ToString() ?? string.Empty;
            videoController.DriverVersion = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_DRIVER_VERSION]?.ToString() ?? string.Empty;
            videoController.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            videoController.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            videoController.VideoModeDescription = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_VIDEO_MODE_DESCRIPTION]?.ToString() ?? string.Empty;
            videoController.VideoProcessor = managementObject[ConstStringHardwareStatic.VIDEO_CONTROLLER_VIDEO_PROCESSOR]?.ToString() ?? string.Empty;

            return videoController;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_VIDEO_CONTROLLER);
        }
    }
}
