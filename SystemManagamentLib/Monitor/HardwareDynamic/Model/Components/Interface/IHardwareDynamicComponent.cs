using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareDynamic.OHMProvider;

namespace SystemManagament.Monitor.HardwareDynamic.Model.Components.Interface
{
    public interface IHardwareDynamicComponent
    {
        List<T> GetDynamicDataForHardwareComponent<T>(IOHMProvider ohmProvider)
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new();
    }
}
