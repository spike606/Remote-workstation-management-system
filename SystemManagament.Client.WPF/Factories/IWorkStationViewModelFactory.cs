using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.Settings;
using SystemManagament.Client.WPF.ViewModel;

namespace SystemManagament.Client.WPF.Factories
{
    public interface IWorkStationViewModelFactory
    {
        WorkStationViewModel CreateWorkStationViewModel(WorkstationSettings workstationSettings);
    }
}
