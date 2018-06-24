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
        private const string testRemotePowershellConnection = "Test - WsMan COMPUTER";
        private const string dir = "dir";
        private const string startRemoteSessions = "Enter-PSSession -ComputerName {0} -Credential {1}";

        public void StartPowershellProcess(string powerShellRemoteSessionUserName)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "powershell.exe";
            psi.Arguments = "PowerShell -NoExit -Command \"" + dir + "\"";
            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
        }
    }
}
