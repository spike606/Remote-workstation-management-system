using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareStatic.Model;
using Wcf.Contract.Service.Interface;

namespace Wcf.Contract.Service.Implementation
{
    public class WorkstationMonitorService : IWorkstationMonitorService
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }

        public SoftwareDynamicData ReadSoftwareDynamicData()
        {
            var data = new WorkstationMonitor().GetSoftwareDynamicData();
            return data;
        }

        public SoftwareStaticData ReadSoftwareStaticData()
        {
            var data = new WorkstationMonitor().GetSoftwareStaticData();
            return data;
        }
    }
}
