using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;

namespace SystemManagament.Client.WPF.ViewModel.Commands
{
    public class AsyncCommandParameterized<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<CancellationToken, object, Task<TResult>> commandWithParameter;
        private readonly CancelAsyncCommand cancelCommand;
        private NotifyTaskCompletion<TResult> execution;
        private object commandParameter;

        public AsyncCommandParameterized(Func<CancellationToken, object, Task<TResult>> commandWithParameter, object parameter)
        {
            this.commandWithParameter = commandWithParameter;
            this.cancelCommand = new CancelAsyncCommand();
            this.commandParameter = parameter;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override ICommand CancelCommand
        {
            get { return this.cancelCommand; }
        }

        // Raises PropertyChanged
        public NotifyTaskCompletion<TResult> Execution
        {
            get
            {
                return this.execution;
            }

            private set
            {
                this.execution = value;
                this.OnPropertyChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return this.Execution == null || this.Execution.IsCompleted;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            this.cancelCommand.NotifyCommandStarting();
            this.Execution = new NotifyTaskCompletion<TResult>(this.commandWithParameter(this.cancelCommand.Token, this.commandParameter));
            this.RaiseCanExecuteChanged();

            // Wait for task completion only if it was not faulted while calling
            if (!this.Execution.IsFaulted)
            {
                await this.Execution.TaskCompletion;
            }

            this.cancelCommand.NotifyCommandFinished();
            this.RaiseCanExecuteChanged();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
