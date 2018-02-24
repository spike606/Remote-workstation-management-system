using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareDynamic.Provider;

namespace SystemManagament.Monitor.SoftwareDynamic.Model.Components.Interface
{
    public interface ISoftwareDynamicComponent<T>
    {
        List<T> GetDynamicDataForSoftwareComponent(ISoftwareDynamicProvider softwareDynamicProvider);
    }
}
