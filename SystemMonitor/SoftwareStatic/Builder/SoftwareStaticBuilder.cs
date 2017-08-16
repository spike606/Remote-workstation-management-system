using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Builder
{
    public class SoftwareStaticBuilder : ISoftwareStaticBuilder
    {
        public SoftwareStaticBuilder(
            ISoftwareStaticProvider softwareStaticProvider,
            IWMIClient wmiClient)
        {
            this.SoftwareStaticProvider = softwareStaticProvider;
        }

        private ISoftwareStaticProvider SoftwareStaticProvider { get; set; }

        public List<SoftwareStaticComponent> GetSoftwareStaticData(SoftwareStaticComponent softwareStaticComponent)
        {
            return softwareStaticComponent.GetStaticDataForSoftwareComponent(this.SoftwareStaticProvider);
        }
    }
}
