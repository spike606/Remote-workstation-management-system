using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SystemManagament.Control;
using SystemManagament.Monitor.DataBuilder;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareStatic.Model;
using SystemManagament.Shared;

namespace SystemManagament
{
    public class WorkstationMonitor
    {
        public WorkstationMonitor()
        {
            this.InitializeIoCContainer();
        }

        private ISystemMonitorDataBuilder SystemMonitorDataBuilder { get; set; }

        private IControlManager ControlManager { get; set; }

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

        public OperationStatus TurnMachineOff()
        {
            return this.ControlManager.TurnMachineOff();
        }

        public OperationStatus RestartMachine()
        {
            return this.ControlManager.RestartMachine();
        }

        public OperationStatus LogOutUser()
        {
            return this.ControlManager.ForceLogOutUser();
        }

        private void InitializeIoCContainer()
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            this.SystemMonitorDataBuilder = container.Resolve<ISystemMonitorDataBuilder>();
            this.ControlManager = container.Resolve<IControlManager>();
        }
    }
}
