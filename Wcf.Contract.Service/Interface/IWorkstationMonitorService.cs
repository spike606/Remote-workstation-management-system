using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareStatic.Model;

namespace Wcf.Contract.Service.Interface
{
    [ServiceContract]
    public interface IWorkstationMonitorService
    {
        [OperationContract]
        double Add(double n1, double n2);

        [OperationContract]
        double Subtract(double n1, double n2);

        [OperationContract]
        double Multiply(double n1, double n2);

        [OperationContract]
        double Divide(double n1, double n2);

        [OperationContract]
        SoftwareDynamicData ReadSoftwareDynamicData();

        [OperationContract]
        SoftwareStaticData ReadSoftwareStaticData();
    }
}
