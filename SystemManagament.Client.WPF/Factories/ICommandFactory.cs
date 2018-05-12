using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Factories
{
    public interface ICommandFactory
    {
        IAsyncCommand CreateWindowsProcessDynamicDataCommand(WpfObservableRangeCollection<WindowsProcess> windowsProcess);

        IAsyncCommand CreateHardwareStaticDataCommand(WpfObservableRangeCollection<Memory> memory);

        IAsyncCommand CreateProcessorDynamicDataCommand(WpfObservableRangeCollection<ProcessorDynamic> processorDynamic);

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

        IAsyncCommand CreateWindowsServiceDynamicDataCommand(WpfObservableRangeCollection<WindowsService> windowsService);

        IAsyncCommand CreateWindowsLogDynamicDataCommand(WpfObservableRangeCollection<WindowsLog> windowsLog);
    }
}
