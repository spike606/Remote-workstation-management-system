using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WcfHost
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            this.InitializeComponent();
            this.process = new ServiceProcessInstaller();
            this.process.Account = ServiceAccount.LocalSystem;
            this.service = new ServiceInstaller();
            this.service.ServiceName = "SystemManagamentService";
            this.Installers.Add(this.process);
            this.Installers.Add(this.service);
        }
    }
}
