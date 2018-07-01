using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemManagament.Client.WPF.Validator
{
    public interface IStringValidator
    {
        ValidationResult Validate(object value, CultureInfo cultureInfo);
    }
}
