﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Comparer;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel.Helpers;
using SystemManagament.Client.WPF.ViewModel.Messages;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Reviewed.")]
    public class WcfClient : IWcfClient
    {
        private readonly TimeSpan timeoutTimeSpan = new TimeSpan(0, 1, 0);
        private readonly long maxBufferPoolSize = 500000000;
        private readonly int maxBufferSize = 200000000;
        private readonly long maxReceivedMessageSize = 200000000;
        private readonly bool reliableSessionEnabled = true;
        private readonly bool reliableSessionOrdered = false;
        private IDynamicDataHelper dynamicDataHelper;
        private string connectionError = "Can't connect to remote machine.";
        private string endpointNotFoundError = "Can't connect to remote machine. The remote endpoint could not be found. The endpoint may not be found or reachable because the remote endpoint is down, the remote endpoint is unreachable, or because the remote network is unreachable. ";
        private string timeoutError = "Cant't connect remote machine. Timeout was reached.";

        public WcfClient(IDynamicDataHelper dynamicDataHelper)
        {
            this.dynamicDataHelper = dynamicDataHelper;
        }

        public string UriAddress { get; set; }

        public string MachineIdentifier { get; set; }

        public string ClientCertificateSubjectName { get; set; }

        public string MachineCertificateSubjectName { get; set; }

        public async Task<HardwareStaticData> ReadHardwareStaticDataAsync(WorkstationMonitorServiceClient client)
        {
            return await client.ReadHardwareStaticDataAsync();
        }

        public async Task<HardwareDynamicData> ReadHardwareDynamicDataAsync(
            WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamicObservableCollection,
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
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModelMainBoardVoltage,
            CancellationToken cancellationToken)
        {
            HardwareDynamicData result = null;
            WorkstationMonitorServiceClient client = null;

            try
            {
                client = await this.GetNewWorkstationMonitorServiceClient();

                result = await client.ReadHardwareDynamicDataAsync();
                client.Close();

                if (result != null && !cancellationToken.IsCancellationRequested)
                {
                    foreach (var processor in result.Processor)
                    {
                        foreach (var load in processor.Load)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelProcessorLoad, load, processor.Name);
                        }

                        foreach (var clock in processor.Clock)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelProcessorClock, clock, processor.Name);
                        }

                        foreach (var power in processor.Power)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelProcessorPower, power, processor.Name);
                        }

                        foreach (var temperature in processor.Temperature)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelProcessorTemp, temperature, processor.Name);
                        }
                    }

                    foreach (var disk in result.Disk)
                    {
                        foreach (var load in disk.Load)
                        {
                            this.dynamicDataHelper.DrawDynamicPieChartForHardwareSensor(dynamicChartViewModelDiskLoad, load, disk.Name);
                        }

                        foreach (var temperature in disk.Temperature)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelDiskTemp, temperature, disk.Name);
                        }
                    }

                    foreach (var memory in result.Memory)
                    {
                        foreach (var data in memory.Data)
                        {
                            this.dynamicDataHelper.DrawDynamicPieChartForHardwareSensor(dynamicChartViewModelMemoryData, data, memory.Name);
                        }
                    }

                    foreach (var gpu in result.VideoController)
                    {
                        foreach (var load in gpu.Load)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelGPULoad, load, gpu.Name);
                        }

                        foreach (var temperature in gpu.Temperature)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelGPUTemp, temperature, gpu.Name);
                        }

                        foreach (var clock in gpu.Clock)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelGPUClock, clock, gpu.Name);
                        }

                        foreach (var data in gpu.Data)
                        {
                            this.dynamicDataHelper.DrawDynamicPieChartForHardwareSensor(dynamicChartViewModelGPUData, data, gpu.Name);
                        }

                        foreach (var voltage in gpu.Voltage)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelGPUVoltage, voltage, gpu.Name);
                        }

                        foreach (var fan in gpu.Fan)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelGPUFan, fan, gpu.Name);
                        }
                    }

                    foreach (var mainBoard in result.MainBoard)
                    {
                        foreach (var temperature in mainBoard.Temperature)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelMainBoardTemp, temperature, mainBoard.Name);
                        }

                        foreach (var fan in mainBoard.Fan)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelMainBoardFan, fan, mainBoard.Name);
                        }

                        foreach (var voltage in mainBoard.Voltage)
                        {
                            this.dynamicDataHelper.DrawDynamicLineChartForHardwareSensor(dynamicChartViewModelMainBoardVoltage, voltage, mainBoard.Name);
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                this.SendErrorMessage(ex.Message);
                this.SendCancelCommandMessage();
            }
            catch (EndpointNotFoundException)
            {
                this.SendErrorMessageEndpointNotFound();
                this.SendCancelCommandMessage();
                client.Abort();
            }
            catch (TimeoutException)
            {
                this.SendErrorMessageTimeout();
                this.SendCancelCommandMessage();
                client.Abort();
            }
            catch (CommunicationException ex)
            {
                this.SendErrorMessage(ex.Message);
                this.SendCancelCommandMessage();
                client.Abort();
            }

            return result;
        }

        public async Task<SoftwareStaticData> ReadSoftwareStaticDataAsync(WorkstationMonitorServiceClient client)
        {
            return await client.ReadSoftwareStaticDataAsync();
        }

        public async Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync(
            WpfObservableRangeCollection<WindowsProcess> windowsProcessDynamicObservableCollection,
            CancellationToken cancellationToken)
        {
            WindowsProcess[] result = null;
            WorkstationMonitorServiceClient client = null;

            try
            {
                //client = await this.GetNewWorkstationMonitorServiceClient();

                result = await client.ReadWindowsProcessDynamicDataAsync();
                client.Close();

                if (result != null && !cancellationToken.IsCancellationRequested)
                {
                    windowsProcessDynamicObservableCollection.ReplaceRange(result);
                }
            }
            catch (InvalidOperationException ex)
            {
                this.SendErrorMessage(ex.Message);
                this.SendCancelCommandMessage();
            }
            catch (EndpointNotFoundException)
            {
                this.SendErrorMessageEndpointNotFound();
                this.SendCancelCommandMessage();
                client.Abort();
            }
            catch (TimeoutException)
            {
                this.SendErrorMessageTimeout();
                this.SendCancelCommandMessage();
                client.Abort();
            }
            catch (CommunicationException ex)
            {
                this.SendErrorMessage(ex.Message);
                this.SendCancelCommandMessage();
                client.Abort();
            }

            return result;
        }

        public async Task<WindowsService[]> ReadWindowsServiceDynamicDataAsync(
            WpfObservableRangeCollection<WindowsService> windowsServiceDynamicObservableCollection,
            CancellationToken cancellationToken)
        {
            WindowsService[] result = null;
            WorkstationMonitorServiceClient client = null;

            try
            {
                //client = await this.GetNewWorkstationMonitorServiceClient();

                result = await client.ReadWindowsServiceDynamicDataAsync();
                client.Close();

                if (result != null && !cancellationToken.IsCancellationRequested)
                {
                    windowsServiceDynamicObservableCollection.ReplaceRange(result, new WindowsServiceComparer());
                }
            }
            catch (InvalidOperationException ex)
            {
                this.SendErrorMessage(ex.Message);
                this.SendCancelCommandMessage();
            }
            catch (EndpointNotFoundException)
            {
                this.SendErrorMessageEndpointNotFound();
                this.SendCancelCommandMessage();
                client.Abort();
            }
            catch (TimeoutException)
            {
                this.SendErrorMessageTimeout();
                this.SendCancelCommandMessage();
                client.Abort();
            }
            catch (CommunicationException ex)
            {
                this.SendErrorMessage(ex.Message);
                this.SendCancelCommandMessage();
                client.Abort();
            }

            return result;
        }

        public async Task<WindowsLog[]> ReadWindowsLogDynamicDataAsync(WorkstationMonitorServiceClient workstationMonitorServiceClient)
        {
            return await workstationMonitorServiceClient.ReadWindowsLogDynamicDataAsync();
        }

        public async Task<OperationStatus> TurnMachineOffAsync(
            WorkstationMonitorServiceClient workstationMonitorServiceClient,
            uint timeoutInSeconds)
        {
            return await workstationMonitorServiceClient.TurnMachineOffAsync(timeoutInSeconds);
        }

        public async Task<OperationStatus> RestartMachineAsync(
            WorkstationMonitorServiceClient workstationMonitorServiceClient,
            uint timeoutInSeconds)
        {
            return await workstationMonitorServiceClient.RestartMachineAsync(timeoutInSeconds);
        }

        public Task<WorkstationMonitorServiceClient> GetNewWorkstationMonitorServiceClient()
        {
            NetTcpBinding netTcpBinding = new NetTcpBinding
            {
                CloseTimeout = this.timeoutTimeSpan,
                OpenTimeout = this.timeoutTimeSpan,
                SendTimeout = this.timeoutTimeSpan,

                MaxBufferPoolSize = this.maxBufferPoolSize,
                MaxBufferSize = this.maxBufferSize,
                MaxReceivedMessageSize = this.maxReceivedMessageSize
            };

            netTcpBinding.ReliableSession.Enabled = this.reliableSessionEnabled;
            netTcpBinding.ReliableSession.Ordered = this.reliableSessionOrdered;

            netTcpBinding.Security.Mode = SecurityMode.Transport;
            netTcpBinding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;
            netTcpBinding.Security.Transport.ClientCredentialType =
               TcpClientCredentialType.Certificate;

            X509Certificate2 serverCertificate = this.GetCertificate(this.MachineCertificateSubjectName);
            X509Certificate2 clientCertificate = this.GetCertificate(this.ClientCertificateSubjectName);

            // TODO: Refactor in order to validate certificate existance first and not to use exceptions in this case
            if (serverCertificate == null)
            {
                throw new InvalidOperationException($"Certificate with subject name: {this.MachineCertificateSubjectName} not found.");
            }

            if (clientCertificate == null)
            {
                throw new InvalidOperationException($"Certificate with subject name: {this.ClientCertificateSubjectName} not found.");
            }

            EndpointAddress endpointAddress = new EndpointAddress(
                new Uri(this.UriAddress),
                EndpointIdentity.CreateX509CertificateIdentity(serverCertificate));

            WorkstationMonitorServiceClient workstationMonitorServiceClient = new WorkstationMonitorServiceClient(netTcpBinding, endpointAddress);

            // Specify a default certificate for the service.
            workstationMonitorServiceClient.ClientCredentials.ServiceCertificate.SetDefaultCertificate(
                StoreLocation.LocalMachine,
                StoreName.TrustedPeople,
                X509FindType.FindBySubjectDistinguishedName,
                this.MachineCertificateSubjectName);

            workstationMonitorServiceClient.ClientCredentials.ServiceCertificate
                .Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;

            // Specify a certificate to use for authenticating the client.
            workstationMonitorServiceClient.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.TrustedPeople,
                X509FindType.FindBySubjectDistinguishedName,
                this.ClientCertificateSubjectName);

            return Task.FromResult<WorkstationMonitorServiceClient>(workstationMonitorServiceClient);
        }

        private X509Certificate2 GetCertificate(string certificateSubjectName)
        {
            X509Store certStore = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);
            certStore.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certCollection = certStore.Certificates.Find(
                X509FindType.FindBySubjectDistinguishedName, certificateSubjectName, false);
            certStore.Close();

            if (certCollection.Count == 0)
            {
                return null;
            }

            return certCollection[0];
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
                RecipientIdentifier = this.MachineIdentifier,
            });
        }
    }
}
