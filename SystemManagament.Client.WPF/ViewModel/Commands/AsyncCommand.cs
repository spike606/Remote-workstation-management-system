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
        private NotifyTaskCompletion<TResult> execution;
        private readonly CancelAsyncCommand cancelCommand;
        public AsyncCommand(Func<CancellationToken, Task<TResult>> command)
        {
            this.command = command;
            this.cancelCommand = new CancelAsyncCommand();
        }
        public override bool CanExecute(object parameter)
        {
            return Execution == null || Execution.IsCompleted;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            this.cancelCommand.NotifyCommandStarting();
            Execution = new NotifyTaskCompletion<TResult>(this.command(this.cancelCommand.Token));
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            this.cancelCommand.NotifyCommandFinished();
            RaiseCanExecuteChanged();

        }
        public ICommand CancelCommand
        {
            get { return cancelCommand; }
        }

        // Raises PropertyChanged
        public NotifyTaskCompletion<TResult> Execution
        {
            get { return execution; }
            private set
            {
                execution = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
