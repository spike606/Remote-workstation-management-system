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
        IAsyncCommand CreateWindowsProcessDynamicDataCommand(BulkObservableCollection<WindowsProcess> windowsProcess);

        IAsyncCommand CreateHardwareStaticDataCommand(ExtendedObservableCollection<Memory> memory);

        IAsyncCommand CreateProcessorDynamicDataCommand(ExtendedObservableCollection<ProcessorDynamic> processorDynamic);

        IAsyncCommand CreateSoftwareStaticDataCommand(
            ExtendedObservableCollection<CurrentUser> currentUser,
            ExtendedObservableCollection<ClaimDuplicate> currentUserClaims,
            ExtendedObservableCollection<GroupDuplicate> currentUserGroups,
            ExtendedObservableCollection<OS> operatingSystem,
            ExtendedObservableCollection<Bios> bios,
            ExtendedObservableCollection<InstalledProgram> installedProgram,
            ExtendedObservableCollection<MicrosoftWindowsUpdate> microsoftWindowsUpdate,
            ExtendedObservableCollection<StartupCommand> startupCommand,
            ExtendedObservableCollection<LocalUser> localUser);

        ICommand CreateClearDataCommand(Action clearData);
    }
}
