using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel
{
    public interface IProcessClient
    {
        void StartPowershellProcess(string powerShellRemoteSessionUserName);
    }
}
