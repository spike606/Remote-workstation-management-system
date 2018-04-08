using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WcfHost
{
    public static class WcfHostWindowsService
    {
        public static void Main()
        {
            ServiceBase.Run(new SystemManagamentService());
        }
    }
}
