using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Interface;

namespace SystemManagament.Monitor.HardwareDynamic.Builder
{
    public interface IHardwareDynamicBuilder
    {
        List<T> GetHardwareDynamicData<T>()
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new();
    }
}
