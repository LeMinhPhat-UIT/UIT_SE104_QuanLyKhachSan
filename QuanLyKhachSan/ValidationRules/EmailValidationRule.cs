using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace QuanLyKhachSan.ValidationRules
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var email = value as string;

            // Regex kiểm tra định dạng email cơ bản
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                return new ValidationResult(false, "Email không hợp lệ.");

            return ValidationResult.ValidResult;
        }
    }
}
