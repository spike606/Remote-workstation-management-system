using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareDynamic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;
using SystemManagament.Monitor.SoftwareStatic.Model;

namespace SystemManagament.Monitor.DataBuilder
{
    public interface ISystemMonitorDataBuilder
    {
        HardwareStaticData GetHardwareStaticData();

        HardwareDynamicData GetHardwareDynamicData();

        SoftwareStaticData GetSoftwareStaticData();

        SoftwareDynamicData GetSoftwareDynamicData();

        List<ProcessorDynamic> GetProcessorDynamicData();

        List<MemoryDynamic> GetMemoryDynamicData();

        List<DiskDynamic> GetDiskDynamicData();

        List<MainBoardDynamic> GetMainBoardDynamicData();

        List<VideoControllerDynamic> GetVideoControllerDynamicData();

        List<WindowsService> GetWindowsServiceDynamicData();

        List<WindowsLog> GetWindowsLogDynamicData();

        List<WindowsProcess> GetWindowsProcessDynamicData();
    }
}
