using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareStatic.Model;

namespace Wcf.Contract.Service.Interface
{
    [ServiceContract]
    public interface IWorkstationMonitorService
    {
        [OperationContract]
        SoftwareDynamicData ReadSoftwareDynamicData();

        [OperationContract]
        SoftwareStaticData ReadSoftwareStaticData();

        [OperationContract]
        HardwareDynamicData ReadHardwareDynamicData();

        [OperationContract]
        HardwareStaticData ReadHardwareStaticData();
    }
}
