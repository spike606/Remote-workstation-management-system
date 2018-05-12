using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public interface IWcfClient
    {
        Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync(WpfObservableRangeCollection<WindowsProcess> windowsProcessDynamicObservableCollection);

        Task<HardwareStaticData> ReadHardwareStaticDataAsync();

        Task<ProcessorDynamic[]> ReadProcessorDynamicDataAsync(ObservableRangeCollection<ProcessorDynamic> extendedObservableCollection);

        Task<SoftwareStaticData> ReadSoftwareStaticDataAsync();

        Task<WindowsService[]> ReadWindowsServiceDynamicDataAsync(WpfObservableRangeCollection<WindowsService> windowsServiceDynamicObservableCollection);

        Task<WindowsLog[]> ReadWindowsLogDynamicDataAsync(WpfObservableRangeCollection<WindowsLog> windowsLogDynamicObservableCollection);
    }
}
