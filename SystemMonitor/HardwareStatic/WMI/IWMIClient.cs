using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.WMI
{
    public interface IWMIClient
    {
        List<ManagementObject> RetriveListOfObjectsByExecutingWMIQuery(string wmiQuery);

        ManagementObject RetriveObjectByExecutingWMIQuery(string wmiQuery);
    }
}
