using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Helpers;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Factories
{
    public interface ICommandFactory
    {
        IAsyncCommand CreateWindowsProcessDynamicDataCommand(WpfObservableRangeCollection<WindowsProcess> windowsProcess);

        IAsyncCommand CreateWindowsLogDynamicDataCommand(WpfObservableRangeCollection<WindowsLog> windowsLog);

        IAsyncCommand CreateWindowsServiceDynamicDataCommand(WpfObservableRangeCollection<WindowsService> windowsService);

        IAsyncCommand CreateHardwareStaticDataCommand(
            WpfObservableRangeCollection<ProcessorStatic> processorStatic,
            WpfObservableRangeCollection<ProcessorCache> processorCache,
            WpfObservableRangeCollection<Memory> memoryItems,
            WpfObservableRangeCollection<BaseBoard> baseBoard,
            WpfObservableRangeCollection<VideoController> videoController,
            WpfObservableRangeCollection<NetworkAdapter> networkAdapter,
            WpfObservableRangeCollection<PnPEntity> pnPEntity,
            WpfObservableRangeCollection<CDROMDrive> cDROMDrive,
            WpfObservableRangeCollection<Fan> fan,
            WpfObservableRangeCollection<Printer> printer,
            WpfObservableRangeCollection<Battery> battery,
            WpfObservableRangeCollection<Storage> storage);

        IAsyncCommand CreateSoftwareStaticDataCommand(
            WpfObservableRangeCollection<CurrentUser> currentUser,
            WpfObservableRangeCollection<ClaimDuplicate> currentUserClaims,
            WpfObservableRangeCollection<GroupDuplicate> currentUserGroups,
            WpfObservableRangeCollection<OS> operatingSystem,
            WpfObservableRangeCollection<Bios> bios,
            WpfObservableRangeCollection<InstalledProgram> installedProgram,
            WpfObservableRangeCollection<MicrosoftWindowsUpdate> microsoftWindowsUpdate,
            WpfObservableRangeCollection<StartupCommand> startupCommand,
            WpfObservableRangeCollection<LocalUser> localUser);

        ICommand CreateClearDataCommand(Action clearData);

        IAsyncCommand CreateHardwareDynamicDataCommand(
            WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamic,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorClock,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorPower,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorTemp,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelProcessorLoad,
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModelDiskLoad,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelDiskTemp,
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModelMemoryData,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPULoad,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUTemp,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUClock,
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModelGPUData,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUVoltage,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelGPUFan,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardTemp,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardFan,
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardVoltage);

        IAsyncCommand CreateTurnMachineOffCommand(UIntParameter timeoutInSeconds);

        IAsyncCommand CreateRestartMachineOffCommand(UIntParameter timeoutInSeconds);

        ICommand CreatePowershellWindowCommand();
    }
}
