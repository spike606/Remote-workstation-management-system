using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareDynamic.Model.Components.Interface;
using SystemMonitor.SoftwareDynamic.Provider;

namespace SystemMonitor.SoftwareDynamic.Builder
{
    public class SoftwareDynamicBuilder : ISoftwareDynamicBuilder
    {
        public SoftwareDynamicBuilder(
            ISoftwareDynamicProvider softwareDynamicProvider)
        {
            this.SoftwareDynamicProvider = softwareDynamicProvider;
        }

        private ISoftwareDynamicProvider SoftwareDynamicProvider { get; set; }

        public List<T> GetSoftwareDynamicData<T>()
            where T : ISoftwareDynamicComponent<T>, new()
        {
            T softwareDynamicComponent = new T();

            return softwareDynamicComponent.GetDynamicDataForSoftwareComponent(this.SoftwareDynamicProvider);
        }
    }
}
