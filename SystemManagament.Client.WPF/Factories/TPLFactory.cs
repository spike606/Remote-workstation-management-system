using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.ViewModel.Messages;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Factories
{
    public class TPLFactory : ITPLFactory
    {
        private readonly IMessageSender messageSender;

        public TPLFactory(IMessageSender messageSender)
        {
            this.messageSender = messageSender;
        }

        public ITargetBlock<DateTimeOffset> CreateNeverEndingTaskMakingWcfCalls(
            Func<DateTimeOffset, CancellationToken, WorkstationMonitorServiceClient, Task> action,
            CancellationToken cancellationToken,
            uint betweenCallsDelayInSeconds,
            string machineIdentifier,
            WorkstationMonitorServiceClient client)
        {
            ActionBlock<DateTimeOffset> block = null;

            block = new ActionBlock<DateTimeOffset>(
                async now =>
                {
                    try
                    {
                        await action(now, cancellationToken, client)
                            .ConfigureAwait(false);

                        await Task.Delay(TimeSpan.FromSeconds(betweenCallsDelayInSeconds), cancellationToken)
                            .ConfigureAwait(false);

                        // Post the action back to the block.
                        block.Post(DateTimeOffset.Now);
                    }
                    catch (InvalidOperationException ex)
                    {
                        this.messageSender.SendErrorMessage(ex.Message);
                    }
                    catch (EndpointNotFoundException)
                    {
                        this.messageSender.SendErrorMessageEndpointNotFound();
                        this.messageSender.SendCancelCommandMessage(machineIdentifier);
                        client.Abort();
                    }
                    catch (TimeoutException)
                    {
                        this.messageSender.SendErrorMessageTimeout();
                        this.messageSender.SendCancelCommandMessage(machineIdentifier);
                        client.Abort();
                    }
                    catch (CommunicationException ex)
                    {
                        this.messageSender.SendErrorMessage(ex.Message);
                        this.messageSender.SendCancelCommandMessage(machineIdentifier);
                        client.Abort();
                    }
                    catch (TaskCanceledException ex)
                    {
                        client.Abort();
                    }
                }, new ExecutionDataflowBlockOptions { CancellationToken = cancellationToken });

            return block;
        }
    }
}
