using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Wcf.Contract.Service.Implementation;
using Wcf.Contract.Service.Interface;

namespace WcfHost
{
    public partial class SystemManagementWindowsService : ServiceBase
    {
        private ServiceHostBase serviceHostBase = null;

        public SystemManagementWindowsService()
        {
            this.InitializeComponent();
            this.ServiceName = "System Management Windows Service";
        }

        public static void Main()
        {
            ServiceBase.Run(new SystemManagementWindowsService());
        }

        protected override void OnStart(string[] args)
        {
            if (this.serviceHostBase != null)
            {
                this.serviceHostBase.Close();
            }

            // Create a ServiceHost for the service type using Windsor Container
            var container = new WindsorContainer();

            container.AddFacility<WcfFacility>().Install(FromAssembly.Named("SystemManagament"));
            container.Register(Component.For<IWorkstationMonitorService>().ImplementedBy<WorkstationMonitorService>());

            var assemblyQualifiedName = typeof(IWorkstationMonitorService).AssemblyQualifiedName;
            this.serviceHostBase = new DefaultServiceHostFactory().CreateServiceHost(assemblyQualifiedName, new Uri[0]);

            // Open the ServiceHostBase to create listeners and start
            // listening for messages.
            this.serviceHostBase.Open();
        }

        protected override void OnStop()
        {
            if (this.serviceHostBase != null)
            {
                this.serviceHostBase.Close();
                this.serviceHostBase = null;
            }
        }
    }
}
