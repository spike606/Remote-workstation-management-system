using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel.Commands;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly int neverEndingCommandDelayInMiliSeconds = 200;
        private IWcfClient wcfClient;

        public CommandFactory(IWcfClient wcfClient)
        {
            this.wcfClient = wcfClient;
        }

        public ICommand CreateClearDataCommand(Action clearData)
        {
            return new RelayCommand(() => clearData());
        }

        public IAsyncCommand CreateHardwareStaticDataCommand(WpfObservableRangeCollection<Memory> memory)
        {
            return new AsyncCommand<HardwareStaticData>(async (cancellationToken) =>
            {
                var result = await this.wcfClient.ReadHardwareStaticDataAsync()
                .WithCancellation(cancellationToken)
                // Following statements will be processed in the same thread, won't use caught context (UI)
                .ConfigureAwait(false);

                memory.ReplaceRange(result.Memory);

                return result;
            });
        }

        public IAsyncCommand CreateProcessorDynamicDataCommand(WpfObservableRangeCollection<ProcessorDynamic> processorDynamic)
        {
            return new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(() =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => this.wcfClient.ReadProcessorDynamicDataAsync(processorDynamic).WithCancellation(ct),
                        cancellationToken);

                    // Start the task. Post the time.
                    var result = neverEndingTask.Post(DateTimeOffset.Now);

                    // if cancel was not requested task is still ongoing
                    //while (!cancellationToken.IsCancellationRequested)
                    //{
                    //    await Task.Delay(this.neverEndingCommandDelayInMiliSeconds);
                    //}
                    return result;
                });
            });
        }

        public IAsyncCommand CreateWindowsProcessDynamicDataCommand(WpfObservableRangeCollection<WindowsProcess> windowsProcesses)
        {
            return new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => this.wcfClient.ReadWindowsProcessDynamicDataAsync(windowsProcesses).WithCancellation(ct),
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

        public IAsyncCommand CreateSoftwareStaticDataCommand(
            WpfObservableRangeCollection<CurrentUser> currentUser,
            WpfObservableRangeCollection<ClaimDuplicate> currentUserClaims,
            WpfObservableRangeCollection<GroupDuplicate> currentUserGroups,
            WpfObservableRangeCollection<OS> operatingSystem,
            WpfObservableRangeCollection<Bios> bios,
            WpfObservableRangeCollection<InstalledProgram> installedProgram,
            WpfObservableRangeCollection<MicrosoftWindowsUpdate> microsoftWindowsUpdate,
            WpfObservableRangeCollection<StartupCommand> startupCommand,
            WpfObservableRangeCollection<LocalUser> localUser)
        {
            return new AsyncCommand<SoftwareStaticData>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    var result = await this.wcfClient.ReadSoftwareStaticDataAsync()
                    .WithCancellation(cancellationToken)
                    // Following statements will be processed in the same thread, won't use caught context (UI)
                    .ConfigureAwait(true);

                    currentUser.ReplaceRange(result.CurrentUser);
                    currentUserClaims.ReplaceRange(result.CurrentUser.First().Claims);
                    currentUserGroups.ReplaceRange(result.CurrentUser.First().Groups);
                    operatingSystem.ReplaceRange(result.OperatingSystem);
                    bios.ReplaceRange(result.Bios);
                    installedProgram.ReplaceRange(result.InstalledProgram);
                    microsoftWindowsUpdate.ReplaceRange(result.MicrosoftWindowsUpdate);
                    startupCommand.ReplaceRange(result.StartupCommand);
                    localUser.ReplaceRange(result.LocalUser);

                    return result;
                });
            });
        }

        public IAsyncCommand CreateWindowsServiceDynamicDataCommand(WpfObservableRangeCollection<WindowsService> windowsService)
        {
            return new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => this.wcfClient.ReadWindowsServiceDynamicDataAsync(windowsService).WithCancellation(ct),
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

        public IAsyncCommand CreateWindowsLogDynamicDataCommand(WpfObservableRangeCollection<WindowsLog> windowsLog)
        {
            return new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => this.wcfClient.ReadWindowsLogDynamicDataAsync(windowsLog).WithCancellation(ct),
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
    }
}
