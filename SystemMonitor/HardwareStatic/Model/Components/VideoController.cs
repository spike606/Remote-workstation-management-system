using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class VideoController
    {
        public string AdapterCompatibility { get; set; }

        public string AdapterDACType { get; set; }

        public UnitValue AdapterRAM { get; set; }

        public string Caption { get; set; }

        public UnitValue CurrentBitsPerPixel { get; set; }

        public UnitValue CurrentHorizontalResolution { get; set; }

        public string CurrentNumberOfColors { get; set; }

        public UnitValue CurrentRefreshRate { get; set; }

        public UnitValue CurrentVerticalResolution { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string DriverVersion { get; set; }

        public string Name { get; set; }

        public string VideoModeDescription { get; set; }

        public string VideoProcessor { get; set; }
    }
}
