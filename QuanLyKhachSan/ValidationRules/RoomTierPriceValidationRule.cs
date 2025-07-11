using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;

namespace QuanLyKhachSan.ValidationRules
{
    public class RoomTierPriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !decimal.TryParse(value.ToString(), out decimal price))
                return new ValidationResult(false, "Giá tiền phải là một số hợp lệ.");
            if (price <= 0)
                return new ValidationResult(false, "Giá tiền phải lớn hơn 0.");
            return ValidationResult.ValidResult;
        }
    }
}
