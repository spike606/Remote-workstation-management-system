using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class NetworkAdapter
    {
        public UnitValue ActiveMaximumTransmissionUnit { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string ComponentID { get; set; }

        public string ConnectorPresent { get; set; }

        public string DeviceID { get; set; }

        public string DeviceName { get; set; }

        public string DriverDate { get; set; }

        public string DriverDescription { get; set; }

        public string DriverName { get; set; }

        public string DriverProvider { get; set; }

        public string DriverVersionString { get; set; }

        public string InterfaceDescription { get; set; }

        public string InterfaceName { get; set; }

        public string Name { get; set; }

        public string NdisMedium { get; set; }

        public string NdisPhysicalMedium { get; set; }

        public string PermanentAddress { get; set; }

        public string Virtual { get; set; }
    }
}
