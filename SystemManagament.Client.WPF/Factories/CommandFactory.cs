using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel.Commands;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly int neverEndingCommandDelayInMiliSeconds = 800;
        private IWcfClient wcfClient;

        public CommandFactory(IWcfClient wcfClient)
        {
            this.wcfClient = wcfClient;
        }

        public ICommand CreateClearDataCommand(Action clearData)
        {
            return new RelayCommand(() => clearData());
        }

        public IAsyncCommand CreateHardwareStaticDataCommand(ExtendedObservableCollection<Memory> memory)
        {
            return new AsyncCommand<HardwareStaticData>(async (cancellationToken) =>
            {
                var result = await this.wcfClient.ReadHardwareStaticDataAsync()
                .WithCancellation(cancellationToken)
                // Following statements will be processed in the same thread, won't use caught context (UI)
                .ConfigureAwait(false);

                memory.RefreshRange(result.Memory);

                return result;
            });
        }

        public IAsyncCommand CreateProcessorDynamicDataCommand(ExtendedObservableCollection<ProcessorDynamic> processorDynamic)
        {
            return new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => this.wcfClient.ReadProcessorDynamicDataAsync(processorDynamic).WithCancellation(ct),
                        cancellationToken);

                    // Start the task. Post the time.
                    var result = neverEndingTask.Post(DateTimeOffset.Now);

                    // if cancel was not requested task is still ongoing
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        await Task.Delay(this.neverEndingCommandDelayInMiliSeconds);
                    }

                    return result;
                });
            });
        }

        public IAsyncCommand CreateWindowsProcessDynamicDataCommand(ExtendedObservableCollection<WindowsProcess> windowsProcesses)
        {
            return new AsyncCommand<WindowsProcess[]>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    var result = await this.wcfClient.ReadWindowsProcessDynamicDataAsync()
                    .WithCancellation(cancellationToken)
                    // Following statements will be processed in the same thread, won't use caught context (UI)
                    .ConfigureAwait(false);

                    windowsProcesses.RefreshRange(result);
                    return result;
                });
            });
        }

        public IAsyncCommand CreateSoftwareStaticDataCommand(
            ExtendedObservableCollection<CurrentUser> currentUser,
            ExtendedObservableCollection<ClaimDuplicate> currentUserClaims,
            ExtendedObservableCollection<GroupDuplicate> currentUserGroups,
            ExtendedObservableCollection<OS> operatingSystem,
            ExtendedObservableCollection<Bios> bios)
        {
            return new AsyncCommand<SoftwareStaticData>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    var result = await this.wcfClient.ReadSoftwareStaticDataAsync()
                    .WithCancellation(cancellationToken)
                    // Following statements will be processed in the same thread, won't use caught context (UI)
                    .ConfigureAwait(false);

                    currentUser.RefreshRange(result.CurrentUser);
                    currentUserClaims.RefreshRange(result.CurrentUser.First().Claims);
                    currentUserGroups.RefreshRange(result.CurrentUser.First().Groups);
                    operatingSystem.RefreshRange(result.OperatingSystem);
                    bios.RefreshRange(result.Bios);

                    return result;
                });
            });
        }
    }
}
