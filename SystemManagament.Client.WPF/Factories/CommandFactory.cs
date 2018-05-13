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
            return new AsyncCommand<WindowsLog[]>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    var result = await this.wcfClient.ReadWindowsLogDynamicDataAsync(windowsLog)
                        .WithCancellation(cancellationToken)
                        // Following statements will be processed in the same thread, won't use caught context (UI)
                        .ConfigureAwait(false);

                    return result;
                });
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

        public IAsyncCommand CreateHardwareStaticDataCommand(
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
            WpfObservableRangeCollection<Battery> battery)
        {
            return new AsyncCommand<HardwareStaticData>(async (cancellationToken) =>
            {
                var result = await this.wcfClient.ReadHardwareStaticDataAsync()
                .WithCancellation(cancellationToken)
                // Following statements will be processed in the same thread, won't use caught context (UI)
                .ConfigureAwait(false);

                processorStatic.ReplaceRange(result.Processor);
                processorCache.ReplaceRange(result.ProcessorCache);
                memoryItems.ReplaceRange(result.Memory);
                baseBoard.ReplaceRange(result.BaseBoard);
                videoController.ReplaceRange(result.VideoController);
                networkAdapter.ReplaceRange(result.NetworkAdapter);
                pnPEntity.ReplaceRange(result.PnPEntity);
                cDROMDrive.ReplaceRange(result.CDROMDrive);
                fan.ReplaceRange(result.Fan);
                printer.ReplaceRange(result.Printer);
                battery.ReplaceRange(result.Battery);

                return result;
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
                    .ConfigureAwait(false);

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

        public ICommand CreateClearDataCommand(Action clearData)
        {
            return new RelayCommand(() => clearData());
        }
    }
}
