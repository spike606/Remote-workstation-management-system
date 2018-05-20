using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public interface IWcfClient
    {
        Task<HardwareStaticData> ReadHardwareStaticDataAsync();

        Task<HardwareDynamicData> ReadHardwareDynamicDataAsync(
            WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamicObservableCollection,
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModelProcessorClock,
            CancellationToken cancellationToken);

        Task<SoftwareStaticData> ReadSoftwareStaticDataAsync();

        Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync(
            WpfObservableRangeCollection<WindowsProcess> windowsProcessDynamicObservableCollection,
            CancellationToken cancelattionToken);

        Task<WindowsService[]> ReadWindowsServiceDynamicDataAsync(
            WpfObservableRangeCollection<WindowsService> windowsServiceDynamicObservableCollection,
            CancellationToken cancellationToken);

        Task<WindowsLog[]> ReadWindowsLogDynamicDataAsync();
    }
}
