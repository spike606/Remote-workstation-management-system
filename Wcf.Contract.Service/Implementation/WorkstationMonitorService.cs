using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament;
using SystemManagament.Control;
using SystemManagament.Monitor.DataBuilder;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareDynamic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;
using SystemManagament.Monitor.SoftwareStatic.Model;
using SystemManagament.Shared;
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
            return this.SystemMonitorDataBuilder.GetSoftwareDynamicData();
        }

        public SoftwareStaticData ReadSoftwareStaticData()
        {
            return this.SystemMonitorDataBuilder.GetSoftwareStaticData();
        }

        public HardwareDynamicData ReadHardwareDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetHardwareDynamicData();
        }

        public HardwareStaticData ReadHardwareStaticData()
        {
            return this.SystemMonitorDataBuilder.GetHardwareStaticData();
        }

        public List<ProcessorDynamic> ReadProcessorDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetProcessorDynamicData();
        }

        public List<MemoryDynamic> ReadMemoryDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetMemoryDynamicData();
        }

        public List<DiskDynamic> ReadDiskDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetDiskDynamicData();
        }

        public List<MainBoardDynamic> ReadMainBoardDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetMainBoardDynamicData();
        }

        public List<VideoControllerDynamic> ReadVideoControllerDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetVideoControllerDynamicData();
        }

        public List<WindowsService> ReadWindowsServiceDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetWindowsServiceDynamicData();
        }

        public List<WindowsLog> ReadWindowsLogDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetWindowsLogDynamicData();
        }

        public List<WindowsProcess> ReadWindowsProcessDynamicData()
        {
            return this.SystemMonitorDataBuilder.GetWindowsProcessDynamicData();
        }

        public OperationStatus TurnMachineOff(uint timeoutInSeconds)
        {
            return this.ControlManager.TurnMachineOff(timeoutInSeconds);
        }

        public OperationStatus RestartMachine(uint timeoutInSeconds)
        {
            return this.ControlManager.RestartMachine(timeoutInSeconds);
        }

        public OperationStatus ForceLogOutUser()
        {
            return this.ControlManager.ForceLogOutUser();
        }
    }
}
