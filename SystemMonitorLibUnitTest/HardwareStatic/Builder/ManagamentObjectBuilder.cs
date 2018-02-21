using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitorLibUnitTest.HardwareStatic.Builder
{
    public class ManagamentObjectBuilder
    {
        private ManagementObject managementObject;
        private ManagementClass managementClass;
        private ManagementPath managementPath;

        public ManagamentObjectBuilder()
        {
            this.managementPath = new ManagementPath();
        }

        public static implicit operator ManagementObject(ManagamentObjectBuilder managamentObjectBuilder)
        {
            return managamentObjectBuilder.Build();
        }

        public ManagamentObjectBuilder WithPathClassName(string className)
        {
            this.managementPath.ClassName = className;
            return this;
        }

        public ManagamentObjectBuilder WithPathNamespace(string pathNamespace)
        {
            this.managementPath.NamespacePath = pathNamespace;
            return this;
        }

        public ManagamentObjectBuilder PrepareManagamentObject()
        {
            this.managementClass = new ManagementClass(this.managementPath);
            this.managementObject = this.managementClass.CreateInstance();
            return this;
        }

        public ManagamentObjectBuilder WithProperty(string propertyName, object propertyValue)
        {
            this.managementObject[propertyName] = propertyValue;
            return this;
        }

        public ManagementObject Build()
        {
            return this.managementObject;
        }
    }
}
