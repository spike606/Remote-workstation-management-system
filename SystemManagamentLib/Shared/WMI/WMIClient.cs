using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Logger;

namespace SystemManagament.Shared.WMI
{
    public class WMIClient : IWMIClient
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
            catch (ManagementException ex)
            {
                this.Logger.LogError(ex.Message, ex);
            }

            return managementObjects;
        }
    }
}
