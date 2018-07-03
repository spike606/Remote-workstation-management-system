using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemManagament.Client.WPF.Validator
{
    public class TimeIntervalValidator : ValidationRule, ITimeIntervalValidator
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool isParsingSucessFul = false;

            uint result;

            if (uint.TryParse(value.ToString(), out result))
            {
                if (result > 1 && result < 11)
                {
                    isParsingSucessFul = true;
                }
            }

            if (!isParsingSucessFul)
            {
                return new ValidationResult(false, "Input must be between 2 and 10 seconds.");
            }

            return new ValidationResult(true, null);
        }
    }
}
