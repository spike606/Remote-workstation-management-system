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
    public class Disk : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830493(v=vs.85).aspx
        public UnitValue AllocatedSize { get; private set; }

        public string BootFromDisk { get; private set; }

        public string BusType { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            throw new NotImplementedException();
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            throw new NotImplementedException();
        }
    }
}
