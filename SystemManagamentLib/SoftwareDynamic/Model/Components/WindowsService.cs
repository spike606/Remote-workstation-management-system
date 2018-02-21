using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareDynamic.Model.Components.Interface;
using SystemMonitor.SoftwareDynamic.Provider;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;
using SystemMonitor.SoftwareStatic.Provider;

namespace SystemMonitor.SoftwareDynamic.Model.Components
{
    public class WindowsService : ISoftwareDynamicComponent<WindowsService>
    {
        public string CanPauseAndContinue { get; set; }

        public string CanShutdown { get; set; }

        public string CanStop { get; set; }

        public string DisplayName { get; set; }

        public string ServiceName { get; set; }

        public string ServiceType { get; set; }

        public string StartType { get; set; }

        public string Status { get; set; }

        public List<WindowsService> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider)
        {
            List<WindowsService> windowsServices = new List<WindowsService>();
            var services = softwareDynamicProvider.GetWindowsServices();
            foreach (var service in services)
            {
                WindowsService windowsService = new WindowsService();
                windowsService.CanPauseAndContinue = service.CanPauseAndContinue.ToString();
                windowsService.CanShutdown = service.CanShutdown.ToString();
                windowsService.CanStop = service.CanStop.ToString();
                windowsService.DisplayName = service.DisplayName;
                windowsService.ServiceName = service.ServiceName;
                windowsService.ServiceType = service.ServiceType.ToString();
                windowsService.StartType = service.StartType.ToString();
                windowsService.Status = service.Status.ToString();
                windowsServices.Add(windowsService);
            }

            return windowsServices;
        }
    }
}
