using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class VideoController : HardwareStaticComponent, IHardwareStaticComponent<VideoController>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394512(v=vs.85).aspx
        [DataMember]
        public string AdapterCompatibility { get; private set; }

        [DataMember]
        public string AdapterDACType { get; private set; }

        [DataMember]
        public UnitValue AdapterRAM { get; private set; }

        [DataMember]
        public UnitValue CurrentBitsPerPixel { get; private set; }

        [DataMember]
        public UnitValue CurrentHorizontalResolution { get; private set; }

        [DataMember]
        public string CurrentNumberOfColors { get; private set; }

        [DataMember]
        public UnitValue CurrentRefreshRate { get; private set; }

        [DataMember]
        public UnitValue CurrentVerticalResolution { get; private set; }

        [DataMember]
        public string DeviceID { get; private set; }

        [DataMember]
        public string DriverVersion { get; private set; }

        [DataMember]
        public string VideoModeDescription { get; private set; }

        [DataMember]
        public string VideoProcessor { get; private set; }

        public List<VideoController> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<VideoController> staticData = new List<VideoController>();

            foreach (var managementObject in managementObjectList)
            {
                VideoController videoController = new VideoController();
                videoController.AdapterCompatibility = managementObject[ConstString.VIDEO_CONTROLLER_ADAPTER_COMPATIBILITY].TryGetStringValue();
                videoController.AdapterDACType = managementObject[ConstString.VIDEO_CONTROLLER_ADAPTER_DAC_TYPE].TryGetStringValue();
                videoController.AdapterRAM = managementObject[ConstString.VIDEO_CONTROLLER_ADAPTER_RAM].TryGetUnitValue(Unit.B);
                videoController.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                videoController.CurrentBitsPerPixel = managementObject[ConstString.VIDEO_CONTROLLER_CURRENT_BITS_PER_PIXEL].TryGetUnitValue(Unit.BIT);
                videoController.CurrentHorizontalResolution = managementObject[ConstString.VIDEO_CONTROLLER_CURRENT_HORIZONTAL_RESOLUTION].TryGetUnitValue(Unit.PX);
                videoController.CurrentNumberOfColors = managementObject[ConstString.VIDEO_CONTROLLER_CURRENT_NUMBER_OF_COLORS].TryGetStringValue();
                videoController.CurrentRefreshRate = managementObject[ConstString.VIDEO_CONTROLLER_CURRENT_REFRESH_RATE].TryGetUnitValue(Unit.HZ);
                videoController.CurrentVerticalResolution = managementObject[ConstString.VIDEO_CONTROLLER_CURRENT_VERTICAL_RESOLUTION].TryGetUnitValue(Unit.PX);
                videoController.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                videoController.DeviceID = managementObject[ConstString.VIDEO_CONTROLLER_DEVICE_ID].TryGetStringValue();
                videoController.DriverVersion = managementObject[ConstString.VIDEO_CONTROLLER_DRIVER_VERSION].TryGetStringValue();
                videoController.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                videoController.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                videoController.VideoModeDescription = managementObject[ConstString.VIDEO_CONTROLLER_VIDEO_MODE_DESCRIPTION].TryGetStringValue();
                videoController.VideoProcessor = managementObject[ConstString.VIDEO_CONTROLLER_VIDEO_PROCESSOR].TryGetStringValue();

                staticData.Add(videoController);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_VIDEO_CONTROLLER);
        }
    }
}
