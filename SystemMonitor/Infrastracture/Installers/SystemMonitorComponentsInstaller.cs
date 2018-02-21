using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SystemMonitor.DataBuilder;
using SystemMonitor.HardwareDynamic.Builder;
using SystemMonitor.HardwareDynamic.OHMProvider;
using SystemMonitor.HardwareStatic.Analyzer;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.Logger;
using SystemMonitor.Shared.Win32API;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareDynamic.Builder;
using SystemMonitor.SoftwareDynamic.Provider;
using SystemMonitor.SoftwareStatic.Builder;
using SystemMonitor.SoftwareStatic.Provider;

namespace SystemMonitor.Infrastracture.Installers
{
    public class SystemMonitorComponentsInstaller : IWindsorInstaller
    {
        private const string Namespace = "SystemMonitor";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<ReferenceClass>()
                .Where(type => type.Namespace.StartsWith(Namespace))
                .WithService.DefaultInterfaces()
                .LifestyleSingleton());
        }
    }
}
