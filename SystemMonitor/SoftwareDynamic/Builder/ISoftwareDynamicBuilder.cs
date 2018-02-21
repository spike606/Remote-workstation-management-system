using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareDynamic.Model.Components.Interface;

namespace SystemMonitor.SoftwareDynamic.Builder
{
    public interface ISoftwareDynamicBuilder
    {
        List<T> GetSoftwareDynamicData<T>()
            where T : ISoftwareDynamicComponent<T>, new();
    }
}
