using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemManagament.Client.WPF.Validator
{
    public class PathValidator : ValidationRule, IPathValidator
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!Directory.Exists(value.ToString()))
            {
                return new ValidationResult(false, "Specifed directory does not exists or is not in correct format.");
            }

            return new ValidationResult(true, null);
        }
    }
}
