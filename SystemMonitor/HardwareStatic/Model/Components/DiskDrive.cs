using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class DiskDrive
    {
        public UnitValue BytesPerSector { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string FirmwareRevision { get; set; }

        public string InterfaceType { get; set; }

        public string MediaType { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public string Partitions { get; set; }

        public string SerialNumber { get; set; }

        public string Signature { get; set; }

        public UnitValue Size { get; set; }

        public string TotalCylinders { get; set; }

        public string TotalHeads { get; set; }

        public string TotalSectors { get; set; }

        public string TotalTracks { get; set; }

        public string TracksPerCylinder { get; set; }
    }
}
