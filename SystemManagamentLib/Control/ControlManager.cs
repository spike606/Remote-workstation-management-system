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
        private const string TimeoutValidationErrorMessage = "Specified timeout must be between 10 seconds and 24 hours.";
        private const string OperationSucessMessage = "Operation triggered sucessfully.";
        private const int TimeoutMin = 10;
        private const int TimeoutMax = 86400;

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

        public OperationStatus TurnMachineOff(uint timeoutInSeconds)
        {
            if (!this.ValidateTimeoutParameter(timeoutInSeconds))
            {
                return new OperationStatus(false, TimeoutValidationErrorMessage);
            }

            try
            {
                this.ProcessClient.StartWindowsOffProcess(timeoutInSeconds);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);

                return new OperationStatus(false, ex.Message);
            }

            return new OperationStatus(true, OperationSucessMessage);
        }

        public OperationStatus RestartMachine(uint timeoutInSeconds)
        {
            if (!this.ValidateTimeoutParameter(timeoutInSeconds))
            {
                return new OperationStatus(false, TimeoutValidationErrorMessage);
            }

            try
            {
                this.ProcessClient.StartWindowsRestartProcess(timeoutInSeconds);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);

                return new OperationStatus(false, ex.Message);
            }

            return new OperationStatus(true, OperationSucessMessage);
        }

        public OperationStatus ForceLogOutUser()
        {
            return this.Win32APIClient.LogOutUser();
        }

        private bool ValidateTimeoutParameter(uint timeoutInSeconds)
        {
            if (timeoutInSeconds < TimeoutMin || timeoutInSeconds > TimeoutMax)
            {
                return false;
            }

            return true;
        }
    }
}
