using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SystemMonitor.DataBuilder;
using SystemMonitor.HardwareDynamic.Builder;
using SystemMonitor.HardwareDynamic.Model;
using SystemMonitor.HardwareDynamic.OHMProvider;
using SystemMonitor.HardwareStatic.Analyzer;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.Logger;
using SystemMonitor.Shared.Win32API;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareDynamic.Builder;
using SystemMonitor.SoftwareDynamic.Model;
using SystemMonitor.SoftwareDynamic.Provider;
using SystemMonitor.SoftwareStatic.Builder;
using SystemMonitor.SoftwareStatic.Model;
using SystemMonitor.SoftwareStatic.Provider;

namespace SystemMonitor
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

        public SoftwareStaticData GetSoftwareStaticData()
        {
            return this.SystemMonitorDataBuilder.GetSoftwareStaticData();
        }

        public SoftwareDynamicData GetSoftwareDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetSoftwareDynamicData();
        }

        private void InitializeIoCContainer()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            this.SystemMonitorDataBuilder = container.Resolve<ISystemMonitorDataBuilder>();
        }
    }
}
