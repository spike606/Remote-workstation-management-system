using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Factories
{
    public interface ICommandFactory
    {
        IAsyncCommand CreateWindowsProcessDynamicDataCommand(ExtendedObservableCollection<WindowsProcess> windowsProcess);

        IAsyncCommand CreateHardwareStaticDataCommand(ExtendedObservableCollection<Memory> memory);

        IAsyncCommand CreateProcessorDynamicDataCommand(ExtendedObservableCollection<ProcessorDynamic> processorDynamic);

        IAsyncCommand CreateSoftwareStaticDataCommand(
            ExtendedObservableCollection<CurrentUser> currentUser,
            ExtendedObservableCollection<ClaimDuplicate> currentUserClaims,
            ExtendedObservableCollection<GroupDuplicate> currentUserGroups,
            ExtendedObservableCollection<OS> operatingSystem,
            ExtendedObservableCollection<Bios> bios);

        ICommand CreateClearDataCommand(Action clearData);
    }
}
