using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;

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

        public List<SoftwareStaticComponent> GetSoftwareStaticDataFromWMI(IWMISoftwareStaticComponent wmiComponent)
        {
            List<ManagementObject> managementObjectList = wmiComponent.GetManagementObjectsForSoftwareComponent(this.WMIClient);
            List<SoftwareStaticComponent> staticData = new List<SoftwareStaticComponent>();

            foreach (var managementObject in managementObjectList)
            {
                staticData.Add(wmiComponent.ExtractData(managementObject));
            }

            return staticData;
        }
    }
}
