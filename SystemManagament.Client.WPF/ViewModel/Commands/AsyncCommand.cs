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
    public class AsyncCommand<TResult> : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<CancellationToken, Task<TResult>> command;
        private readonly CancelAsyncCommand cancelCommand;
        private NotifyTaskCompletion<TResult> execution;

        public AsyncCommand(Func<CancellationToken, Task<TResult>> command)
        {
            this.command = command;
            this.cancelCommand = new CancelAsyncCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CancelCommand
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
            this.Execution = new NotifyTaskCompletion<TResult>(this.command(this.cancelCommand.Token));
            this.RaiseCanExecuteChanged();
            await this.Execution.TaskCompletion;
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
