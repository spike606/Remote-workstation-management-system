using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;

namespace SystemManagament.Monitor.HardwareStatic.Builder
{
    public interface IHardwareStaticBuilder
    {
        List<T> GetHardwareStaticData<T>()
            where T : HardwareStaticComponent, IHardwareStaticComponent<T>, new();
    }
}
