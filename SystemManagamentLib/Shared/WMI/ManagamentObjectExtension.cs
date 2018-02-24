using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;

namespace SystemManagament.Shared.WMI
{
    public static class ManagamentObjectExtension
    {
        public static string TryGetStringValue(this object managementObject)
        {
            return managementObject?.ToString() ?? string.Empty;
        }

        public static UnitValue TryGetUnitValue(this object managementObject, string unit)
        {
            return new UnitValue(unit, managementObject?.ToString() ?? string.Empty);
        }
    }
}
