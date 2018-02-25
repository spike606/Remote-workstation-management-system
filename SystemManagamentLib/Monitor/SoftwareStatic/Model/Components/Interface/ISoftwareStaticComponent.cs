using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareStatic.Provider;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface
{
    public interface ISoftwareStaticComponent<T>
    {
        List<T> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider);
    }
}
