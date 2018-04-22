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
        public CancellationToken Token { get { return cts.Token; } }
        public void NotifyCommandStarting()
        {
            commandExecuting = true;
            if (!cts.IsCancellationRequested)
                return;
            cts = new CancellationTokenSource();
            RaiseCanExecuteChanged();
        }
        public void NotifyCommandFinished()
        {
            commandExecuting = false;
            RaiseCanExecuteChanged();
        }
        bool ICommand.CanExecute(object parameter)
        {
            return commandExecuting && !cts.IsCancellationRequested;
        }
        void ICommand.Execute(object parameter)
        {
            cts.Cancel();
            RaiseCanExecuteChanged();
        }

        private void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
