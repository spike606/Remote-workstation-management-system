using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Builder
{
    public class SoftwareStaticBuilder : ISoftwareStaticBuilder
    {
        public SoftwareStaticBuilder(
            ISoftwareStaticProvider softwareStaticProvider,
            IWMIClient wmiClient)
        {
            this.SoftwareStaticProvider = softwareStaticProvider;
        }

        private ISoftwareStaticProvider SoftwareStaticProvider { get; set; }

        public List<T> GetSoftwareStaticData<T>()
            where T : ISoftwareStaticComponent<T>, new()
        {
            T softwareStaticComponent = new T();

            return softwareStaticComponent.GetStaticDataForSoftwareComponent(this.SoftwareStaticProvider);
        }
    }
}
