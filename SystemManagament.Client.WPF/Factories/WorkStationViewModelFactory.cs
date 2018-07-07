using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using SystemManagament.Client.WPF.Settings;
using SystemManagament.Client.WPF.Validator;
using SystemManagament.Client.WPF.ViewModel;
using SystemManagament.Client.WPF.ViewModel.Wcf;

namespace SystemManagament.Client.WPF.Factories
{
    public class WorkStationViewModelFactory : IWorkStationViewModelFactory
    {
        public WorkStationViewModel CreateWorkStationViewModel(
            WorkstationSettings workstationSettings)
        {
            var wcfClient = SimpleIoc.Default.GetInstance<IWcfClient>(Guid.NewGuid().ToString());
            var processClient = SimpleIoc.Default.GetInstance<IProcessClient>(Guid.NewGuid().ToString());
            var configProvider = SimpleIoc.Default.GetInstance<IConfigProvider>();
            ICommandFactory commandFactory = new CommandFactory(wcfClient, processClient, configProvider);
            WorkStationViewModel workStationViewModel = new WorkStationViewModel(commandFactory, SimpleIoc.Default.GetInstance<IUintValidator>());

            workStationViewModel.LoadSettings(workstationSettings);

            return workStationViewModel;
        }
    }
}
