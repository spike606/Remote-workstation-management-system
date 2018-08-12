using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Factories
{
    public interface ITPLFactory
    {
        ITargetBlock<DateTimeOffset> CreateNeverEndingTaskMakingWcfCalls(
            Func<DateTimeOffset, CancellationToken, WorkstationMonitorServiceClient, Task> action,
            CancellationToken cancellationToken,
            uint betweenCallsDelayInSeconds,
            string machineIdentifier,
            WorkstationMonitorServiceClient client);
    }
}
