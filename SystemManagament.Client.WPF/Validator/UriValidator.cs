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
    public class UriValidator : ValidationRule, IUriValidator
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Uri outUri;

            if (!(Uri.TryCreate(value.ToString(), UriKind.Absolute, out outUri)
               && (outUri.Scheme == Uri.UriSchemeNetTcp)))
            {
                return new ValidationResult(false, "Incorrect URI.");
            }

            return new ValidationResult(true, null);
        }
    }
}
