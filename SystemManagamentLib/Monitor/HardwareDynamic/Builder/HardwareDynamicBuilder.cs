using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareDynamic.OHMProvider;

namespace SystemManagament.Monitor.HardwareDynamic.Builder
{
    public class HardwareDynamicBuilder : IHardwareDynamicBuilder
    {
        public HardwareDynamicBuilder(IOHMProvider ohmProvider)
        {
            this.OhmMProvider = ohmProvider;
        }

        private IOHMProvider OhmMProvider { get; set; }

        public List<T> GetHardwareDynamicData<T>()
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new()
        {
            T hardwareDynamicComponent = new T();
            return hardwareDynamicComponent.GetDynamicDataForHardwareComponent<T>(this.OhmMProvider);
        }
    }
}
