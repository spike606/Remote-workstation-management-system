using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Wcf.Contract.Service.Implementation;
using Wcf.Contract.Service.Interface;

namespace Wcf.Host.Debug
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                var container = new WindsorContainer();

                container.AddFacility<WcfFacility>().Install(FromAssembly.Named("SystemManagament"));
                container.Register(Component.For<IWorkstationMonitorService>().ImplementedBy<WorkstationMonitorService>());

                var assemblyQualifiedName = typeof(IWorkstationMonitorService).AssemblyQualifiedName;
                //var factory = new DefaultServiceHostFactory(container.Kernel);
                var serviceHost = new DefaultServiceHostFactory().CreateServiceHost(assemblyQualifiedName, new Uri[0]);
                //var serviceHost = new DefaultServiceHostFactory()
                //    .CreateServiceHost(assemblyQualifiedName, new[] { new Uri("net.tcp://localhost:8000/") });
                serviceHost.Open();

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
