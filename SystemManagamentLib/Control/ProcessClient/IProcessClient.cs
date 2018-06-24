using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Control.ProcessClient
{
    public interface IProcessClient
    {
        void StartWindowsOffProcess(uint timeoutInSeconds);

        void StartWindowsRestartProcess(uint timeoutInSeconds);
    }
}
