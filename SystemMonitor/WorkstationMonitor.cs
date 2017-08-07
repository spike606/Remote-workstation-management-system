using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SystemMonitor.DataBuilder;
using SystemMonitor.HardwareDynamic.Builder;
using SystemMonitor.HardwareDynamic.Model;
using SystemMonitor.HardwareDynamic.OHMProvider;
using SystemMonitor.HardwareStatic.Analyzer;
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

        public HardwareDynamicData GetHardwareDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetHardwareDynamicData();
        }

        private void InitializeIoCContainer()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<INLogger>().ImplementedBy<NLogger>().LifeStyle.Singleton);
            container.Register(Component.For<ISystemMonitorDataBuilder>().ImplementedBy<SystemMonitorDataBuilder>().LifeStyle.Singleton);
            container.Register(Component.For<IHardwareStaticBuilder>().ImplementedBy<HardwareStaticBuilder>().LifeStyle.Singleton);
            container.Register(Component.For<IHardwareStaticAnalyzer>().ImplementedBy<HardwareStaticAnalyzer>().LifeStyle.Singleton);
            container.Register(Component.For<IWMIClient>().ImplementedBy<WMIClient>().LifeStyle.Singleton);
            container.Register(Component.For<IOHMProvider>().ImplementedBy<OHMProvider>().LifeStyle.Singleton);
            container.Register(Component.For<IHardwareDynamicBuilder>().ImplementedBy<HardwareDynamicBuilder>().LifeStyle.Singleton);

            this.SystemMonitorDataBuilder = container.Resolve<ISystemMonitorDataBuilder>();
        }
    }
}
