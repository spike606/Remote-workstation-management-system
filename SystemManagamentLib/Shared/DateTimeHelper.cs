using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Shared
{
    public class DateTimeHelper
    {
        internal static DateTime ConvertRegistryDateStringToCorrectDateTimeFormat(string dateAsString)
        {
            string[] possibleDateFormats = { "yyyyMMdd", "dd.MM.yyyy", "M/d/yyyy" };

            DateTime dateTimeValue;

            foreach (string dateStringFormat in possibleDateFormats)
            {
                if (DateTime.TryParseExact(dateAsString, dateStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeValue))
                {
                    return dateTimeValue;
                }
            }

            return default(DateTime);
        }
    }
}
