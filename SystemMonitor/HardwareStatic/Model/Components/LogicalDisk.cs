using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class LogicalDisk
    {
        public UnitValue BlockSize { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string FileSystem { get; set; }

        public UnitValue FreeSpace { get; set; }

        public string Name { get; set; }

        public string ProviderName { get; set; }

        public UnitValue Size { get; set; }

        public string VolumeName { get; set; }

        public string VolumeSerialNumber { get; set; }
    }
}
