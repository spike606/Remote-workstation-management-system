﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public interface IWcfClient
    {
        Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync();

        Task<HardwareStaticData> ReadHardwareStaticDataAsync();

    }
}
