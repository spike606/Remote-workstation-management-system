using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.WMI
{
    internal class WMIClient
    {
        // TODO: IoC, nlog
        internal ManagementObject RetriveObjectByExecutingWMIQuery(string wmiQuery)
        {
            ManagementObject managementObject = null;
            try
            {
                managementObject = new ManagementObjectSearcher(wmiQuery).Get().Cast<ManagementObject>().First();
            }
            catch (ManagementException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            return managementObject;
        }
    }
}
