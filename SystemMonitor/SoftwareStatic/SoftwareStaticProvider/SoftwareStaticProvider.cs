using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;

namespace SystemMonitor.SoftwareStatic.SoftwareStaticProvider
{
    public class SoftwareStaticProvider : ISoftwareStaticProvider
    {
        public SoftwareStaticProvider(IWMIClient wmiClient)
        {
            this.WMIClient = wmiClient;
        }

        private IWMIClient WMIClient { get; set; }

        public ServiceController[] GetAllWindowsServices()
        {
            return ServiceController.GetServices();
        }

        public List<T> GetSoftwareStaticDataFromWMI<T>()
            where T : IWMISoftwareStaticComponent<T>, new()
        {
            List<T> softwareStaticDataList = new List<T>();
            var softwareStaticData = new T();
            List<ManagementObject> managementObjectList = softwareStaticData.GetManagementObjectsForSoftwareComponent(this.WMIClient);

            foreach (var managementObject in managementObjectList)
            {
                softwareStaticDataList.Add(softwareStaticData.ExtractData(managementObject));
            }

            return softwareStaticDataList;
        }
    }
}
