using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            foreach (var item in attributes)
            {
                EnumDescriptionAttribute attribute = attributes[0] as EnumDescriptionAttribute;
                if (attributes != null)
                {
                    return attribute.Description;
                }
            }

            return enumValue.ToString();
        }
    }
}
