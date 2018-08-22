using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public interface IWcfClient
    {
        string UriAddress { get; set; }

        string MachineIdentifier { get; set; }

        string ClientCertificateSubjectName { get; set; }

        string MachineCertificateSubjectName { get; set; }

        Task<HardwareStaticData> ReadHardwareStaticDataAsync(WorkstationMonitorServiceClient workstationMonitorServiceClient);

        Task<HardwareDynamicData> ReadHardwareDynamicDataAsync(
            WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamicObservableCollection,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorClock,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorPower,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorTemp,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorLoad,
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModelStorageLoad,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelStorageTemp,
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModelMemoryData,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPULoad,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUTemp,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUClock,
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModelGPUData,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUVoltage,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUFan,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardTemp,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardFan,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardVoltage,
            bool logsEnabled,
            string logsDirectoryPath,
            WorkstationMonitorServiceClient workstationMonitorServiceClient,
            CancellationToken cancellationToken);

        Task<SoftwareStaticData> ReadSoftwareStaticDataAsync(WorkstationMonitorServiceClient workstationMonitorServiceClient);

        Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync(
            WpfObservableRangeCollection<WindowsProcess> windowsProcessDynamicObservableCollection,
            WorkstationMonitorServiceClient workstationMonitorServiceClient,
            CancellationToken cancelattionToken);

        Task<WindowsService[]> ReadWindowsServiceDynamicDataAsync(
            WpfObservableRangeCollection<WindowsService> windowsServiceDynamicObservableCollection,
            WorkstationMonitorServiceClient workstationMonitorServiceClient,
            CancellationToken cancellationToken);

        Task<WindowsLog[]> ReadWindowsLogDynamicDataAsync(WorkstationMonitorServiceClient workstationMonitorServiceClient);

        Task<OperationStatus> TurnMachineOffAsync(WorkstationMonitorServiceClient workstationMonitorServiceClient, uint timeoutInSeconds);

        Task<OperationStatus> RestartMachineAsync(WorkstationMonitorServiceClient workstationMonitorServiceClient, uint timeoutInSeconds);

        Task<WorkstationMonitorServiceClient> GetNewWorkstationMonitorServiceClient();
    }
}
