using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRMVersion1._0.Validators
{
   public class DatePickerValidator : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
            if (value == null || value == "")
            {
                return new ValidationResult(false, "Date cannot be empty.");
            }
            else
            {
                DateTime date;
                if (!DateTime.TryParse(value.ToString(), out date))
                {
                    return new ValidationResult(false, "Value needs to be date!");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
