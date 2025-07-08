using System.Globalization;
using System.Windows.Controls;

namespace QuanLyKhachSan.ValidationRules
{
    public class PhoneNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var phone = value as string;

            if (!phone.All(char.IsDigit))
                return new ValidationResult(false, "SĐT chỉ được chứa số.");

            if (phone.Length != 10)
                return new ValidationResult(false, "SĐT phải có đúng 10 số.");

            return ValidationResult.ValidResult;
        }
    }
}
