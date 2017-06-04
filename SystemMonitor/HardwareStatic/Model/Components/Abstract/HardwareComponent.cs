using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components.Abstract
{
    public abstract class HardwareComponent
    {
        public string Caption { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string Status { get; protected set; }

        public abstract List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient);

        public abstract HardwareComponent ExtractData(ManagementObject managementObject);
    }
}
