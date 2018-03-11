using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Contract.Service.Implementation;

namespace Wcf.Host.Debug
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                svcHost = new ServiceHost(typeof(WorkstationMonitorService));
                svcHost.Open();
                Console.WriteLine("\n\nService is running.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service can not be started \n\nError Message: [{ex.Message}]");
            }
            finally
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}
