using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Comparer;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.Settings;
using SystemManagament.Client.WPF.ViewModel;
using SystemManagament.Client.WPF.ViewModel.Commands;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Helpers;
using SystemManagament.Client.WPF.ViewModel.Messages;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly int neverEndingCommandDelayInMiliSeconds = 300;
        private readonly IWcfClient wcfClient;
        private readonly IProcessClient processClient;
        private readonly IConfigProvider configProvider;
        private string connectionError = "Can't connect to remote machine.";
        private string endpointNotFoundError = "Can't connect to remote machine. The remote endpoint could not be found. The endpoint may not be found or reachable because the remote endpoint is down, the remote endpoint is unreachable, or because the remote network is unreachable. ";
        private string timeoutError = "Cant't connect remote machine. Timeout was reached.";

        public CommandFactory(IWcfClient wcfClient, IProcessClient processClient, IConfigProvider configProvider)
        {
            this.wcfClient = wcfClient;
            this.processClient = processClient;
            this.configProvider = configProvider;
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
                        cancellationToken,
                        this.configProvider.DelayBetweenCalls_WindowsProcess);

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
                        cancellationToken,
                        this.configProvider.DelayBetweenCalls_WindowsService);

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
                WorkstationMonitorServiceClient workstationMonitorServiceClient = null;
                WindowsLog[] result = null;

                try
                {
                    workstationMonitorServiceClient = await this.wcfClient.GetNewWorkstationMonitorServiceClient();

                    result = await this.wcfClient.ReadWindowsLogDynamicDataAsync(workstationMonitorServiceClient)
                        .WithCancellation(cancellationToken)
                        // Following statements will be processed in the same thread, won't use caught context (UI)
                        .ConfigureAwait(false);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        workstationMonitorServiceClient.Abort();
                    }
                    else
                    {
                        workstationMonitorServiceClient.Close();
                    }

                    if (result != null && !cancellationToken.IsCancellationRequested)
                    {
                        windowsLog.ReplaceRange(result, new WindowsLogComparer());
                    }
                }
                catch (InvalidOperationException ex)
                {
                    this.SendErrorMessage(ex.Message);

                    // Rethrow exception in order to set correct Task state (Faulted)
                    throw;
                }
                catch (EndpointNotFoundException)
                {
                    this.SendErrorMessageEndpointNotFound();
                    this.SendCancelCommandMessage();
                    workstationMonitorServiceClient.Abort();

                    throw;
                }
                catch (TimeoutException)
                {
                    this.SendErrorMessageTimeout();
                    this.SendCancelCommandMessage();
                    workstationMonitorServiceClient.Abort();

                    throw;
                }
                catch (CommunicationException ex)
                {
                    this.SendErrorMessage(ex.Message);
                    this.SendCancelCommandMessage();
                    workstationMonitorServiceClient.Abort();

                    throw;
                }
                return result;
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
                        cancellationToken,
                        this.configProvider.DelayBetweenCalls_HardwareDynamic);

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
                WorkstationMonitorServiceClient workstationMonitorServiceClient = null;
                HardwareStaticData result = null;
                try
                {
                    workstationMonitorServiceClient = await this.wcfClient.GetNewWorkstationMonitorServiceClient();

                    result = await Task.Run<HardwareStaticData>(() => workstationMonitorServiceClient.ReadHardwareStaticDataAsync())
                        .WithCancellation(cancellationToken)
                        // Following statements will be processed in the same thread, won't use caught context (UI)
                        .ConfigureAwait(false);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        workstationMonitorServiceClient.Abort();
                    }
                    else
                    {
                        workstationMonitorServiceClient.Close();
                    }

                    if (result != null && !cancellationToken.IsCancellationRequested)
                    {
                        processorStatic.ReplaceRange(result.Processor, new ProcessorStaticComparer());
                        processorCache.ReplaceRange(result.ProcessorCache, new ProcessorCacheStaticComparer());
                        memoryItems.ReplaceRange(result.Memory, new MemoryStaticComparer());
                        baseBoard.ReplaceRange(result.BaseBoard, new BaseBoardStaticComparer());
                        videoController.ReplaceRange(result.VideoController, new VideoControllerStaticComparer());
                        networkAdapter.ReplaceRange(result.NetworkAdapter, new NetworkAdapterStaticComparer());
                        pnPEntity.ReplaceRange(result.PnPEntity, new PnPEntityStaticComparer());
                        cDROMDrive.ReplaceRange(result.CDROMDrive, new CDROMDriveStaticComparer());
                        fan.ReplaceRange(result.Fan, new FanStaticComparer());
                        printer.ReplaceRange(result.Printer, new PrinterStaticComparer());
                        battery.ReplaceRange(result.Battery, new BatteryStaticComparer());
                        storage.ReplaceRange(result.Storage);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    this.SendErrorMessage(ex.Message);

                    // Rethrow exception in order to set correct Task state (Faulted)
                    throw;
                }
                catch (EndpointNotFoundException)
                {
                    this.SendErrorMessageEndpointNotFound();
                    this.SendCancelCommandMessage();
                    workstationMonitorServiceClient.Abort();

                    throw;
                }
                catch (TimeoutException)
                {
                    this.SendErrorMessageTimeout();
                    this.SendCancelCommandMessage();
                    workstationMonitorServiceClient.Abort();

                    throw;
                }
                catch (CommunicationException ex)
                {
                    this.SendErrorMessage(ex.Message);
                    this.SendCancelCommandMessage();
                    workstationMonitorServiceClient.Abort();

                    throw;
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
                    WorkstationMonitorServiceClient workstationMonitorServiceClient = null;
                    SoftwareStaticData result = null;

                    try
                    {
                        workstationMonitorServiceClient = await this.wcfClient.GetNewWorkstationMonitorServiceClient();

                        result = await this.wcfClient.ReadSoftwareStaticDataAsync(workstationMonitorServiceClient)
                            .WithCancellation(cancellationToken)
                            // Following statements will be processed in the same thread, won't use caught context (UI)
                            .ConfigureAwait(false);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            workstationMonitorServiceClient.Abort();
                        }
                        else
                        {
                            workstationMonitorServiceClient.Close();
                        }

                        if (result != null && !cancellationToken.IsCancellationRequested)
                        {
                            currentUser.ReplaceRange(result.CurrentUser, new CurrentUserStaticComparer());
                            currentUserClaims.ReplaceRange(result.CurrentUser.First().Claims, new ClaimDuplicateComparer());
                            currentUserGroups.ReplaceRange(result.CurrentUser.First().Groups, new GroupDuplicateComparer());
                            operatingSystem.ReplaceRange(result.OperatingSystem, new OSComparer());
                            bios.ReplaceRange(result.Bios, new BiosComparer());
                            installedProgram.ReplaceRange(result.InstalledProgram, new InstalledProgramComparer());
                            microsoftWindowsUpdate.ReplaceRange(result.MicrosoftWindowsUpdate, new MicrosoftWindowsUpdateComparer());
                            startupCommand.ReplaceRange(result.StartupCommand, new StartupCommandComparer());
                            localUser.ReplaceRange(result.LocalUser, new LocalUserComparer());
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        this.SendErrorMessage(ex.Message);

                        // Rethrow exception in order to set correct Task state (Faulted)
                        throw;
                    }
                    catch (EndpointNotFoundException)
                    {
                        this.SendErrorMessageEndpointNotFound();
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }
                    catch (TimeoutException)
                    {
                        this.SendErrorMessageTimeout();
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }
                    catch (CommunicationException ex)
                    {
                        this.SendErrorMessage(ex.Message);
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }

                    return result;
                });
            });
        }

        public ICommand CreateClearDataCommand(Action clearData)
        {
            return new RelayCommand(() => clearData());
        }

        public IAsyncCommand CreateTurnMachineOffCommand(UIntParameter timeoutInSeconds)
        {
            return new AsyncCommandParameterized<OperationStatus>(
                async (cancellationToken, timeout) =>
                {
                    WorkstationMonitorServiceClient workstationMonitorServiceClient = null;
                    OperationStatus result = null;

                    try
                    {
                        workstationMonitorServiceClient = await this.wcfClient.GetNewWorkstationMonitorServiceClient();

                        result = await this.wcfClient.TurnMachineOffAsync(workstationMonitorServiceClient, ((UIntParameter)timeout).Parameter)
                            .WithCancellation(cancellationToken)
                            // Following statements will be processed in the same thread, won't use caught context (UI)
                            .ConfigureAwait(false);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            workstationMonitorServiceClient.Abort();
                        }
                        else
                        {
                            workstationMonitorServiceClient.Close();
                        }

                        if (result != null && !cancellationToken.IsCancellationRequested)
                        {
                            this.ShowMessageBox(result);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        this.SendErrorMessage(ex.Message);

                        // Rethrow exception in order to set correct Task state (Faulted)
                        throw;
                    }
                    catch (EndpointNotFoundException)
                    {
                        this.SendErrorMessageEndpointNotFound();
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }
                    catch (TimeoutException)
                    {
                        this.SendErrorMessageTimeout();
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }
                    catch (CommunicationException ex)
                    {
                        this.SendErrorMessage(ex.Message);
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }

                    return result;
                },
                timeoutInSeconds);
        }

        public IAsyncCommand CreateRestartMachineOffCommand(UIntParameter timeoutInSeconds)
        {
            return new AsyncCommandParameterized<OperationStatus>(
                async (cancellationToken, timeout) =>
                {
                    WorkstationMonitorServiceClient workstationMonitorServiceClient = null;
                    OperationStatus result = null;

                    try
                    {
                        workstationMonitorServiceClient = await this.wcfClient.GetNewWorkstationMonitorServiceClient();

                        result = await this.wcfClient.RestartMachineAsync(workstationMonitorServiceClient, ((UIntParameter)timeout).Parameter)
                            .WithCancellation(cancellationToken)
                            // Following statements will be processed in the same thread, won't use caught context (UI)
                            .ConfigureAwait(false);

                        if (cancellationToken.IsCancellationRequested)
                        {
                            workstationMonitorServiceClient.Abort();
                        }
                        else
                        {
                            workstationMonitorServiceClient.Close();
                        }

                        if (result != null && !cancellationToken.IsCancellationRequested)
                        {
                            this.ShowMessageBox(result);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        this.SendErrorMessage(ex.Message);

                        // Rethrow exception in order to set correct Task state (Faulted)
                        throw;
                    }
                    catch (EndpointNotFoundException)
                    {
                        this.SendErrorMessageEndpointNotFound();
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }
                    catch (TimeoutException)
                    {
                        this.SendErrorMessageTimeout();
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }
                    catch (CommunicationException ex)
                    {
                        this.SendErrorMessage(ex.Message);
                        this.SendCancelCommandMessage();
                        workstationMonitorServiceClient.Abort();

                        throw;
                    }

                    return result;
                },
                timeoutInSeconds);
        }

        public ICommand CreatePowershellWindowCommand()
        {
            return new RelayCommand<string>((computerName) => this.processClient.StartPowershellProcess(computerName));
        }

        public void LoadSettings(WorkstationSettings workstationSettings)
        {
            this.wcfClient.UriAddress = workstationSettings.Uri;
            this.wcfClient.MachineIdentifier = workstationSettings.MachineIdentifier;
            this.wcfClient.ClientCertificateSubjectName = workstationSettings.ClientCertificateSubjectName;
            this.wcfClient.MachineCertificateSubjectName = workstationSettings.NewMachineCertificateSubjectName;
        }

        private void ShowMessageBox(OperationStatus status)
        {
            if (status.IsSucceded)
            {
                MessageBox.Show(
                  status.Message,
                  "Control request result.",
                  MessageBoxButton.OK,
                  MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(
                  status.Message,
                  "Control request result.",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
        }

        private void SendErrorMessageTimeout()
        {
            Messenger.Default.Send(new ErrorMessage()
            {
                Message = this.timeoutError
            });
        }

        private void SendErrorMessageEndpointNotFound()
        {
            Messenger.Default.Send(new ErrorMessage()
            {
                Message = this.endpointNotFoundError
            });
        }

        private void SendErrorMessage(string message)
        {
            Messenger.Default.Send(new ErrorMessage()
            {
                Message = this.connectionError + message
            });
        }

        private void SendCancelCommandMessage()
        {
            Messenger.Default.Send(new CancelCommandMessage()
            {
                RecipientIdentifier = this.wcfClient.MachineIdentifier,
            });
        }
    }
}
