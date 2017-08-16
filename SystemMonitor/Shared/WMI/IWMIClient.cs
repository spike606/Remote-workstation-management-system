using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Shared.WMI
{
    public interface IWMIClient
    {
        List<ManagementObject> RetriveListOfObjectsByExecutingWMIQuery(string wmiNamespace, string wmiQuery);
    }
}
