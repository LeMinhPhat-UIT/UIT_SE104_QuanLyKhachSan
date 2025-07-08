using System.Globalization;
using System.Windows.Controls;

namespace QuanLyKhachSan.ValidationRules
{
    public class CCCDValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var cccd = value as string;

            if (!cccd.All(char.IsDigit))
                return new ValidationResult(false, "CCCD chỉ được chứa số.");

            if (cccd.Length != 12)
                return new ValidationResult(false, "CCCD phải có đúng 12 số.");
            return ValidationResult.ValidResult;
        }
    }
}
