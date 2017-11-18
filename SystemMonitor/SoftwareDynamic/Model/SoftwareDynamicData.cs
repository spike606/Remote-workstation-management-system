using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareDynamic.Model.Components;

namespace SystemMonitor.SoftwareDynamic.Model
{
    public class SoftwareDynamicData
    {
        public List<WindowsService> WindowsService { get; set; }

        public List<WindowsLog> WindowsLog { get; set; }
    }
}
