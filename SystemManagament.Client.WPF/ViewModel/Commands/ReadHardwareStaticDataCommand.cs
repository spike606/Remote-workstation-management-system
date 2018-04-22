using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Commands
{
    public class ReadHardwareStaticDataCommand : AsyncCommandBase,
        IReadHardwareStaticDataCommand,
        INotifyPropertyChanged
    {
        private IWcfClient wcfClient;

        private NotifyTaskCompletion<WindowsProcess[]> _execution;
        // Raises PropertyChanged
        public NotifyTaskCompletion<WindowsProcess[]> Execution { get; private set; }

        public ReadHardwareStaticDataCommand(IWcfClient wcfClient)
        {
            this.wcfClient = wcfClient;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var task = await this.wcfClient.ReadWindowsProcessDynamicDataAsync().r;
            return task;
        }



        //public void Execute(object parameter)
        //{
        //    var processes = await this.wcfClient.ReadWindowsProcessDynamicDataAsync();
        //}
    }
}
