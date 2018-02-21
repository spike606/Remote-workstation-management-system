using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components.Abstract
{
    public abstract class HardwareStaticComponent
    {
        public string Caption { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public string Status { get; protected set; }
    }
}
