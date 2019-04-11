using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyProject.Validation
{
    public class EmptyTextBox : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string tbText = value as string;
                if (string.IsNullOrWhiteSpace(tbText))
                    return new ValidationResult(false, "Please fill in the blank.");
                else
                    return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
