using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Helpers
{
    public interface IDynamicChartHelper
    {
        void DrawDynamicChartForSensor(
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModel,
            Sensor sensor);
    }
}
