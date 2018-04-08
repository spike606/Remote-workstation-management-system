using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.DataBuilder;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareDynamic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;
using SystemManagament.Monitor.SoftwareStatic.Model;
using SystemManagament.Shared;

namespace Wcf.Contract.Service.Interface
{
    [ServiceContract]
    public interface IWorkstationMonitorService
    {
        [OperationContract]
        SoftwareDynamicData ReadSoftwareDynamicData();

        [OperationContract]
        SoftwareStaticData ReadSoftwareStaticData();

        [OperationContract]
        HardwareDynamicData ReadHardwareDynamicData();

        [OperationContract]
        HardwareStaticData ReadHardwareStaticData();

        [OperationContract]
        List<ProcessorDynamic> ReadProcessorDynamicData();

        [OperationContract]
        List<MemoryDynamic> ReadMemoryDynamicData();

        [OperationContract]
        List<DiskDynamic> ReadDiskDynamicData();

        [OperationContract]
        List<MainBoardDynamic> ReadMainBoardDynamicData();

        [OperationContract]
        List<VideoControllerDynamic> ReadVideoControllerDynamicData();

        [OperationContract]
        List<WindowsService> ReadWindowsServiceDynamicData();

        [OperationContract]
        List<WindowsLog> ReadWindowsLogDynamicData();

        [OperationContract]
        List<WindowsProcess> ReadWindowsProcessDynamicData();

        [OperationContract]
        OperationStatus TurnMachineOff();

        [OperationContract]
        OperationStatus RestartMachine();

        [OperationContract]
        OperationStatus ForceLogOutUser();
    }
}
