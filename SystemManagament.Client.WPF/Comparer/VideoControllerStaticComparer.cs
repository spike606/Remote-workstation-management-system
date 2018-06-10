using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class VideoControllerStaticComparer : IEqualityComparer<VideoController>
    {
        public bool Equals(VideoController x, VideoController y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status
                && x.AdapterCompatibility == y.AdapterCompatibility
                && x.AdapterDACType == y.AdapterDACType
                && x.AdapterRAM.Value == y.AdapterRAM.Value
                && x.CurrentBitsPerPixel.Value == y.CurrentBitsPerPixel.Value
                && x.CurrentHorizontalResolution.Value == y.CurrentHorizontalResolution.Value
                && x.CurrentNumberOfColors == y.CurrentNumberOfColors
                && x.CurrentRefreshRate.Value == y.CurrentRefreshRate.Value
                && x.CurrentVerticalResolution.Value == y.CurrentVerticalResolution.Value
                && x.DeviceID == y.DeviceID
                && x.DriverVersion == y.DriverVersion
                && x.VideoModeDescription == y.VideoModeDescription
                && x.VideoProcessor == y.VideoProcessor;
        }

        public int GetHashCode(VideoController obj)
        {
            return obj.GetHashCode();
        }
    }
}
