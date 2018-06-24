using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Shared;

namespace SystemManagament.Control
{
    public interface IControlManager
    {
        OperationStatus TurnMachineOff(uint timeoutInSeconds);

        OperationStatus RestartMachine(uint timeoutInSeconds);

        OperationStatus ForceLogOutUser();
    }
}
