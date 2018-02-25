using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Control.ProcessClient
{
    public class ProcessClient : IProcessClient
    {
        private const string SHUTDOWN_FILE_NAME = "shutdown";
        private const string SHUTDOWN_TURN_OFF = "/s ";
        private const string SHUTDOWN_RESTART = "/r ";
        private const string SHUTDOWN_RUNNING_APPS_FORCE_CLOSE = "/f ";
        private const string SHUTDOWN_TIMEOUT = "/t ";
        private const string TIMEOUT_IN_SECONDS = "120 ";
        private const string SHUTDOWN_USE_COMMENT = "/c ";
        private const string SHUTDOWN_TURN_OFF_MESSAGE = "\"Your machine will turn off in 120 seconds, please save your work - ADMINISTRATOR\"";
        private const string SHUTDOWN_RESTART_MESSAGE = "\"Your machine will restart in 120 seconds, please save your work - ADMINISTRATOR\"";

        public void StartWindowsOffProcess()
        {
            string processArgs = SHUTDOWN_TURN_OFF +
                SHUTDOWN_RUNNING_APPS_FORCE_CLOSE +
                SHUTDOWN_TIMEOUT +
                TIMEOUT_IN_SECONDS +
                SHUTDOWN_USE_COMMENT +
                SHUTDOWN_TURN_OFF_MESSAGE;

            this.StartShutdownProcess(processArgs);
        }

        public void StartWindowsRestartProcess()
        {
            string processArgs = SHUTDOWN_RESTART +
                SHUTDOWN_RUNNING_APPS_FORCE_CLOSE +
                SHUTDOWN_TIMEOUT +
                TIMEOUT_IN_SECONDS +
                SHUTDOWN_USE_COMMENT +
                SHUTDOWN_RESTART_MESSAGE;

            this.StartShutdownProcess(processArgs);
        }

        private void StartShutdownProcess(string shutdownProcessArgs)
        {
            var psi = new ProcessStartInfo(SHUTDOWN_FILE_NAME, shutdownProcessArgs)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }
    }
}
