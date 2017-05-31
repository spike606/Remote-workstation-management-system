using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SystemMonitor.DataBuilder;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.WMI;
using SystemMonitor.NLogger;

namespace HardwareMonitor
{
    public class WorkstationMonitor
    {
        public WorkstationMonitor()
        {
            this.InitializeIoCContainer();
        }

        private ISystemMonitorDataBuilder SystemMonitorDataBuilder { get; set; }

        public HardwareStaticData GetHardwareStaticData()
        {
            return this.SystemMonitorDataBuilder.GetHardwareStaticData();
        }

        private void InitializeIoCContainer()
        {
            var container = new WindsorContainer();
            container.Register(Castle.MicroKernel.Registration.Component.For<INLogger>().ImplementedBy<NLogger>().LifeStyle.Singleton);
            container.Register(Castle.MicroKernel.Registration.Component.For<ISystemMonitorDataBuilder>().ImplementedBy<SystemMonitorDataBuilder>().LifeStyle.Singleton);
            container.Register(Castle.MicroKernel.Registration.Component.For<IHardwareStaticBuilder>().ImplementedBy<HardwareStaticBuilder>().LifeStyle.Singleton);
            container.Register(Castle.MicroKernel.Registration.Component.For<IWMIClient>().ImplementedBy<WMIClient>().LifeStyle.Singleton);
            container.Register(Castle.MicroKernel.Registration.Component.For<IWMIDataExtractor>().ImplementedBy<WMIDataExtractor>().LifeStyle.Singleton);

            this.SystemMonitorDataBuilder = container.Resolve<ISystemMonitorDataBuilder>();
        }
    }
}
