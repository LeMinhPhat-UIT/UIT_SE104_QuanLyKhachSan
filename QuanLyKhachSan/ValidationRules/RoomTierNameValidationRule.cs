using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;


namespace QuanLyKhachSan.ValidationRules
{
    public class RoomTierNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return new ValidationResult(false, "không thể bỏ trống tên loại phòng");
            if (Char.IsDigit(name[0]))
                return new ValidationResult(false, "ký tự đầu không được là số");
            return ValidationResult.ValidResult;
        }
    }
}
