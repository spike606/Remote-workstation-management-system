using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SystemManagament.Client.WPF.ViewModel.Commands
{
    public class CancelAsyncCommand : ICommand
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private bool commandExecuting;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CancellationToken Token
        {
            get { return this.cts.Token; }
        }

        public void NotifyCommandStarting()
        {
            this.commandExecuting = true;
            if (!this.cts.IsCancellationRequested)
            {
                return;
            }

            this.cts = new CancellationTokenSource();
            this.RaiseCanExecuteChanged();
        }

        public void NotifyCommandFinished()
        {
            this.commandExecuting = false;
            this.RaiseCanExecuteChanged();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return this.commandExecuting && !this.cts.IsCancellationRequested;
        }

        void ICommand.Execute(object parameter)
        {
            this.cts.Cancel();
            this.RaiseCanExecuteChanged();
        }

        private void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
