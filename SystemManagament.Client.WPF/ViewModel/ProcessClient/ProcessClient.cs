using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel
{
    public class ProcessClient : IProcessClient
    {
        private const string StartRemoteSessionTemplate = "Enter-PSSession -ComputerName {0} -UseSSL -Credential('RemoteMachineUser')";

        public void StartPowershellProcess(string powerShellRemoteSessionComputerName)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell.exe";
            psi.Arguments = string.Format("PowerShell -NoExit -Command \"" + StartRemoteSessionTemplate + "\"", powerShellRemoteSessionComputerName);

            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
        }
    }
}
