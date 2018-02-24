using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components.Interface;

namespace SystemManagament.Monitor.SoftwareDynamic.Builder
{
    public interface ISoftwareDynamicBuilder
    {
        List<T> GetSoftwareDynamicData<T>()
            where T : ISoftwareDynamicComponent<T>, new();
    }
}
