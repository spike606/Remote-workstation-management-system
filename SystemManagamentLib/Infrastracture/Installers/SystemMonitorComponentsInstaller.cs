using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SystemManagament.Infrastracture.Installers
{
    public class SystemMonitorComponentsInstaller : IWindsorInstaller
    {
        private const string Namespace = "SystemManagament";

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
