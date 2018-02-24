using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;

namespace SystemManagament.Monitor.SoftwareDynamic.Model
{
    public class SoftwareDynamicData
    {
        public List<WindowsService> WindowsService { get; set; }

        public List<WindowsLog> WindowsLog { get; set; }

        public List<WindowsProcess> WindowsProcess { get; set; }
    }
}
