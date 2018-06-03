using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.Converters
{
    public sealed class UnitValueToStringConverter : IValueConverter
    {
        private string valueFormat = "0.0000";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unitValueObject = (UnitValue)value;

            var objectValue = unitValueObject.Value;
            var unit = unitValueObject.Unit;

            if (unit == "Byte" && double.Parse(objectValue) >= 1024)
            {
                objectValue = (double.Parse(objectValue) / 1024).ToString(this.valueFormat);
                unit = "kB";
            }

            if (unit == "kB" && double.Parse(objectValue) >= 1024)
            {
                objectValue = (double.Parse(objectValue) / 1024).ToString(this.valueFormat);
                unit = "MB";
            }

            if (unit == "MB" && double.Parse(objectValue) >= 4096)
            {
                objectValue = (double.Parse(objectValue) / 1024).ToString(this.valueFormat);
                unit = "GB";
            }

            return objectValue + " " + unit;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
