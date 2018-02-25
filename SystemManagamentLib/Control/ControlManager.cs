using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Control.ProcessClient;
using SystemManagament.Logger;
using SystemManagament.Shared;
using SystemManagament.Shared.Win32API;

namespace SystemManagament.Control
{
    public class ControlManager : IControlManager
    {
        public ControlManager(
            INLogger logger,
            IProcessClient processClient,
            IWin32APIClient win32APIClient)
        {
            this.Logger = logger;
            this.ProcessClient = processClient;
            this.Win32APIClient = win32APIClient;
        }

        private INLogger Logger { get; set; }

        private IProcessClient ProcessClient { get; set; }

        private IWin32APIClient Win32APIClient { get; set; }

        public OperationStatus TurnMachineOff()
        {
            try
            {
                this.ProcessClient.StartWindowsOffProcess();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);

                return new OperationStatus(false, ex.Message);
            }

            return new OperationStatus(true, string.Empty);
        }

        public OperationStatus RestartMachine()
        {
            try
            {
                this.ProcessClient.StartWindowsRestartProcess();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);

                return new OperationStatus(false, ex.Message);
            }

            return new OperationStatus(true, string.Empty);
        }

        public OperationStatus ForceLogOutUser()
        {
            return this.Win32APIClient.LogOutUser();
        }
    }
}
