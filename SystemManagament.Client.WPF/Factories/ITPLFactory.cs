using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace SystemManagament.Client.WPF.Factories
{
    public interface ITPLFactory
    {
        ITargetBlock<DateTimeOffset> CreateNeverEndingTask(Func<DateTimeOffset, CancellationToken, Task> action, CancellationToken cancellationToken, uint betweenCallsDelayInSeconds);
    }
}
