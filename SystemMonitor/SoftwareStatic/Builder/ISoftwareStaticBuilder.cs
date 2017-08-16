using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;

namespace SystemMonitor.SoftwareStatic.Builder
{
    public interface ISoftwareStaticBuilder
    {
        List<SoftwareStaticComponent> GetSoftwareStaticData(SoftwareStaticComponent softwareStaticComponent);
    }
}
