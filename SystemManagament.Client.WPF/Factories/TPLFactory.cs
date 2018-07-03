using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using SystemManagament.Client.WPF.Extensions;

namespace SystemManagament.Client.WPF.Factories
{
    public class TPLFactory : ITPLFactory
    {
        public ITargetBlock<DateTimeOffset> CreateNeverEndingTask(
            Func<DateTimeOffset, CancellationToken, Task> action,
            CancellationToken cancellationToken,
            uint betweenCallsDelayInSeconds)
        {
            // Validate parameters.
            if (action == null)
            {
                throw new ArgumentNullException("Action can't be null");
            }

            // Declare the block variable, it needs to be captured.
            ActionBlock<DateTimeOffset> block = null;

            // Create the block, it will call itself, so
            // declaration and assignment are separated
            // Async so we can wait easily when the
            // delay comes.
            block = new ActionBlock<DateTimeOffset>(
                async now =>
                {
                    // Perform the action. Wait on the result.
                    await action(now, cancellationToken).
                        // Doing this here because synchronization context more than
                        // likely *doesn't* need to be captured for the continuation
                        // here.  As a matter of fact, that would be downright
                        // dangerous.
                        ConfigureAwait(false);

                    // Wait.
                    await Task.Delay(TimeSpan.FromSeconds(betweenCallsDelayInSeconds), cancellationToken).
                        // Same as above.
                        ConfigureAwait(false);

                    // Post the action back to the block.
                    block.Post(DateTimeOffset.Now);
                }, new ExecutionDataflowBlockOptions { CancellationToken = cancellationToken });

            return block;
        }
    }
}
