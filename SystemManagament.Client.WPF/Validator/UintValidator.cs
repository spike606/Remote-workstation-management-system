using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SystemManagament.Client.WPF.Validator
{
    public class UintValidator : ValidationRule, IUintValidator
    {
        public uint Min { get; } = 10;

        public uint Max { get; } = 86400;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            uint parseResult = 0;
            bool isParsingSucessFul = true;

            if (value.ToString().Length > 0)
            {
                isParsingSucessFul = uint.TryParse(value.ToString(), out parseResult);
            }

            if (!isParsingSucessFul)
            {
                return new ValidationResult(false, "Illegal characters");
            }

            if ((parseResult < this.Min) || (parseResult > this.Max))
            {
                return new ValidationResult(false, "Please enter value in the range: " + this.Min + " - " + this.Max + ".");
            }

            return new ValidationResult(true, null);
        }
    }
}
