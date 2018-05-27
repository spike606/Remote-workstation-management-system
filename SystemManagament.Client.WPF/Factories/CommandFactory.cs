﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Comparer;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel;
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
                        (now, ct) => this.wcfClient.ReadWindowsProcessDynamicDataAsync(windowsProcesses, ct),
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
                        (now, ct) => this.wcfClient.ReadWindowsServiceDynamicDataAsync(windowsService, ct),
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
                    var result = await this.wcfClient.ReadWindowsLogDynamicDataAsync()
                        .WithCancellation(cancellationToken)
                        // Following statements will be processed in the same thread, won't use caught context (UI)
                        .ConfigureAwait(false);

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        windowsLog.ReplaceRange(result, new WindowsLogComparer());
                    }

                    return result;
                });
            });
        }

        public IAsyncCommand CreateHardwareDynamicDataCommand(
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
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardVoltage)
        {
            return new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => this.wcfClient.ReadHardwareDynamicDataAsync(
                            hardwareDynamic,
                            dynamicChartViewModelProcessorClock,
                            dynamicChartViewModelProcessorPower,
                            dynamicChartViewModelProcessorTemp,
                            dynamicChartViewModelProcessorLoad,
                            dynamicChartViewModelDiskLoad,
                            dynamicChartViewModelDiskTemp,
                            dynamicChartViewModelMemoryData,
                            dynamicChartViewModelGPULoad,
                            dynamicChartViewModelGPUTemp,
                            dynamicChartViewModelGPUClock,
                            dynamicChartViewModelGPUData,
                            dynamicChartViewModelGPUVoltage,
                            dynamicChartViewModelGPUFan,
                            dynamicChartViewModelMainBoardTemp,
                            dynamicChartViewModelMainBoardFan,
                            dynamicChartViewModelMainBoardVoltage,
                            ct),
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
            WpfObservableRangeCollection<Battery> battery,
            WpfObservableRangeCollection<Storage> storage)
        {
            return new AsyncCommand<HardwareStaticData>(async (cancellationToken) =>
            {
                var result = await this.wcfClient.ReadHardwareStaticDataAsync()
                .WithCancellation(cancellationToken)
                // Following statements will be processed in the same thread, won't use caught context (UI)
                .ConfigureAwait(false);

                if (!cancellationToken.IsCancellationRequested)
                {
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
                    storage.ReplaceRange(result.Storage);
                }

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

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        currentUser.ReplaceRange(result.CurrentUser);
                        currentUserClaims.ReplaceRange(result.CurrentUser.First().Claims);
                        currentUserGroups.ReplaceRange(result.CurrentUser.First().Groups);
                        operatingSystem.ReplaceRange(result.OperatingSystem);
                        bios.ReplaceRange(result.Bios);
                        installedProgram.ReplaceRange(result.InstalledProgram);
                        microsoftWindowsUpdate.ReplaceRange(result.MicrosoftWindowsUpdate);
                        startupCommand.ReplaceRange(result.StartupCommand);
                        localUser.ReplaceRange(result.LocalUser);
                    }

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
