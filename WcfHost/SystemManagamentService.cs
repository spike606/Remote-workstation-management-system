using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfHost.Services;

namespace WcfHost
{
    public partial class SystemManagamentService : ServiceBase
    {
        private ServiceHost serviceHost = null;

        public SystemManagamentService()
        {
            this.InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (this.serviceHost != null)
            {
                this.serviceHost.Close();
            }

            // Create a ServiceHost for the service type and
            // provide the base address.
            this.serviceHost = new ServiceHost(typeof(WorkstationMonitorService));

            // Open the ServiceHostBase to create listeners and start
            // listening for messages.
            this.serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (this.serviceHost != null)
            {
                this.serviceHost.Close();
                this.serviceHost = null;
            }
        }
    }
}
