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

        public static UnitLongValue TryGetUnitLongValue(this object managementObject, string unit)
        {
            return new UnitLongValue(unit, (long?)managementObject);
        }

        public static UnitULongValue TryGetUnitULongValue(this object managementObject, string unit)
        {
            return new UnitULongValue(unit, (ulong?)managementObject);
        }

        public static UnitIntValue TryGetUnitIntValue(this object managementObject, string unit)
        {
            return new UnitIntValue(unit, (int?)managementObject);
        }

        public static UnitUIntValue TryGetUnitUIntValue(this object managementObject, string unit)
        {
            return new UnitUIntValue(unit, (uint?)managementObject);
        }

        public static UnitUShortValue TryGetUnitUShortValue(this object managementObject, string unit)
        {
            return new UnitUShortValue(unit, (ushort?)managementObject);
        }

        public static UnitShortValue TryGetUnitShortValue(this object managementObject, string unit)
        {
            return new UnitShortValue(unit, (short?)managementObject);
        }
    }
}
