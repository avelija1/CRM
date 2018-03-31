using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CRMVersion1._0.Validators
{
   public class ServiceNameValidator : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if ((int)value == -1)
            {
                return new ValidationResult(false, "Service cannot be empty.");
            }

            return ValidationResult.ValidResult;
        }

        //Exampple for regex. You will validate this way phone, website, email etc fields.
    //    private string _regex = @"^\d{3}-\d{3}-\d{4}$";
    //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    //    {
    //        if (value == null)
    //            return new ValidationResult(false, "value cannot be empty.");
    //        else
    //        {
    //            if (!Regex.IsMatch(value.ToString(), _regex))
    //                return new ValidationResult(false, "Enter numbers like xxx-xxx-xxxx.");
    //        }
    //        return ValidationResult.ValidResult;
    //    }
    //}
}
}
