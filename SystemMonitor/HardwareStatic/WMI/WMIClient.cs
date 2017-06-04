using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.NLogger;

namespace SystemMonitor.HardwareStatic.WMI
{
    internal class WMIClient : IWMIClient
    {
        public WMIClient(INLogger logger)
        {
            this.Logger = logger;
        }

        public INLogger Logger { get; private set; }

        public List<ManagementObject> RetriveListOfObjectsByExecutingWMIQuery(string wmiNamespace, string wmiQuery)
        {
            List<ManagementObject> managementObjects = new List<ManagementObject>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiNamespace, wmiQuery);

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    managementObjects.Add(queryObj);
                }
            }
            catch (ManagementException exc)
            {
                this.Logger.LogDebug(exc.ToString());
            }

            return managementObjects;
        }
    }
}
