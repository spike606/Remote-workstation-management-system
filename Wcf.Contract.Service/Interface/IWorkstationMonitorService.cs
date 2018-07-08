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
        [OperationContract(IsOneWay = false)]
        SoftwareDynamicData ReadSoftwareDynamicData();

        [OperationContract(IsOneWay = false)]
        SoftwareStaticData ReadSoftwareStaticData();

        [OperationContract(IsOneWay = false)]
        HardwareDynamicData ReadHardwareDynamicData();

        [OperationContract(IsOneWay = false)]
        HardwareStaticData ReadHardwareStaticData();

        [OperationContract(IsOneWay = false)]
        List<ProcessorDynamic> ReadProcessorDynamicData();

        [OperationContract(IsOneWay = false)]
        List<MemoryDynamic> ReadMemoryDynamicData();

        [OperationContract(IsOneWay = false)]
        List<DiskDynamic> ReadDiskDynamicData();

        [OperationContract(IsOneWay = false)]
        List<MainBoardDynamic> ReadMainBoardDynamicData();

        [OperationContract(IsOneWay = false)]
        List<VideoControllerDynamic> ReadVideoControllerDynamicData();

        [OperationContract(IsOneWay = false)]
        List<WindowsService> ReadWindowsServiceDynamicData();

        [OperationContract(IsOneWay = false)]
        List<WindowsLog> ReadWindowsLogDynamicData();

        [OperationContract(IsOneWay = false)]
        List<WindowsProcess> ReadWindowsProcessDynamicData();

        [OperationContract(IsOneWay = false)]
        OperationStatus TurnMachineOff(uint timeoutInSeconds);

        [OperationContract(IsOneWay = false)]
        OperationStatus RestartMachine(uint timeoutInSeconds);

        [OperationContract(IsOneWay = false)]
        OperationStatus ForceLogOutUser();
    }
}
