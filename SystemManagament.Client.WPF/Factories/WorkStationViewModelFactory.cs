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
            string machineName,
            WorkstationSettings workstationSettings)
        {
            WorkStationViewModel workStationViewModel = new WorkStationViewModel(
                SimpleIoc.Default.GetInstance<ICommandFactory>(), SimpleIoc.Default.GetInstance<IUintValidator>());

            workStationViewModel.MachineName = machineName;
            workStationViewModel.LoadSettings(workstationSettings);

            return workStationViewModel;
        }
    }
}
