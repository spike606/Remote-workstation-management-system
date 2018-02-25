using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemManagament.Monitor.SoftwareStatic.Model.Components;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Provider
{
    public interface ISoftwareStaticProvider
    {
        List<T> GetSoftwareStaticDataFromWMI<T>()
            where T : IWMISoftwareStaticComponent<T>, new();

        CurrentUser GetCurrentUser();

        List<InstalledProgram> GetInstalledPrograms();
    }
}
