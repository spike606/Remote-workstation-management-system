using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;

namespace SystemMonitor.SoftwareStatic.Provider
{
    public interface ISoftwareStaticProvider
    {
        List<T> GetSoftwareStaticDataFromWMI<T>()
            where T : IWMISoftwareStaticComponent<T>, new();

        CurrentUser GetCurrentUser();

        List<InstalledProgram> GetInstalledPrograms();
    }
}
