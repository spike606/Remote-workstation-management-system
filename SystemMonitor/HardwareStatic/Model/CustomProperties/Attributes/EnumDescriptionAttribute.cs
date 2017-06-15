using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumDescriptionAttribute : Attribute
    {
        public EnumDescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
