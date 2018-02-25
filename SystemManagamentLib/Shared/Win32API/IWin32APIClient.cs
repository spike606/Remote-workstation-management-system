using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Shared.Win32API
{
    public interface IWin32APIClient
    {
        string GetProcessUser(Process process);

        OperationStatus LogOutUser();
    }
}
