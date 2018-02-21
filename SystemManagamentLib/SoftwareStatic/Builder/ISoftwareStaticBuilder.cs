using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;

namespace SystemMonitor.SoftwareStatic.Builder
{
    public interface ISoftwareStaticBuilder
    {
        List<T> GetSoftwareStaticData<T>()
            where T : ISoftwareStaticComponent<T>, new();
    }
}
