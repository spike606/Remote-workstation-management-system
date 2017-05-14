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

        public ManagamentObjectBuilder()
        {
            ManagementClass managementClass = new ManagementClass("root\\CIMV2");
            ManagementObject managementObject = managementClass.CreateInstance();
        }

        public ManagementObject Build()
        {
            //PutOptions options = new PutOptions();
            //options.Type = PutType.CreateOnly;
            //this.managementObject.Put(options);
            return this.managementObject;
        }

        public ManagamentObjectBuilder WithProperty(string propertyName, object propertyValue)
        {
            this.managementObject[propertyName] = propertyValue;
            return this;
        }
    }
}
