using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemManagament.Client.WPF.Validator
{
    public class StringValidator : ValidationRule, IStringValidator
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isParsingSucessFul = false;

            if (value.ToString().Length > 0)
            {
                isParsingSucessFul = true;
            }

            if (!isParsingSucessFul)
            {
                return new ValidationResult(false, "Input can't be empty.");
            }

            return new ValidationResult(true, null);
        }
    }
}
