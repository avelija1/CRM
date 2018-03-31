using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRMVersion1._0.Validators
{
   public class QuantityValidator : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || value == "")
            {
                return new ValidationResult(false, "Quantity cannot be empty.");

            }
            else
            {
                int quantity;
                if (!int.TryParse(value.ToString(), out quantity))
                {
                    return new ValidationResult(false, "Quantity needs to be a number");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
