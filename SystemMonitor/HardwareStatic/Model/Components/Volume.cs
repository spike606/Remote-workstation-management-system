using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Volume
    {
        public UnitValue BlockSize { get; set; }

        public string BootVolume { get; set; }

        public UnitValue Capacity { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string DriveLetter { get; set; }

        public string DriveType { get; set; }

        public string FileSystem { get; set; }

        public UnitValue FreeSpace { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public string Status { get; set; }

        public string SystemVolume { get; set; }
    }
}
