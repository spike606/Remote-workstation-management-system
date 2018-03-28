using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament;
using SystemManagament.Control;
using SystemManagament.Monitor.DataBuilder;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareStatic.Model;
using Wcf.Contract.Service.Interface;

namespace Wcf.Contract.Service.Implementation
{
    public class WorkstationMonitorService : IWorkstationMonitorService
    {
        public WorkstationMonitorService(
            ISystemMonitorDataBuilder systemMonitorDataBuilder,
            IControlManager controlManager)
        {
            this.SystemMonitorDataBuilder = systemMonitorDataBuilder;
            this.ControlManager = controlManager;
        }

        public ISystemMonitorDataBuilder SystemMonitorDataBuilder { get; set; }

        public IControlManager ControlManager { get; set; }

        public SoftwareDynamicData ReadSoftwareDynamicData()
        {
            var data = this.SystemMonitorDataBuilder.GetSoftwareDynamicData();
            return data;
        }

        public SoftwareStaticData ReadSoftwareStaticData()
        {
            var data = this.SystemMonitorDataBuilder.GetSoftwareStaticData();
            return data;
        }

        public HardwareDynamicData ReadHardwareDynamicData()
        {
            var data = this.SystemMonitorDataBuilder.GetHardwareDynamicData();
            return data;
        }

        public HardwareStaticData ReadHardwareStaticData()
        {
            var data = this.SystemMonitorDataBuilder.GetHardwareStaticData();
            return data;
        }
    }
}
