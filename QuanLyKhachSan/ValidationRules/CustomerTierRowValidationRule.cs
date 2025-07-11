using QuanLyKhachSan.ViewModel.EntityViewModels;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace QuanLyKhachSan.ValidationRules
{
    public class CustomerTierRowValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = (BindingGroup)value;
            CustomerTierViewModel cusTier = bindingGroup.Items[0] as CustomerTierViewModel;
            if (cusTier == null)
                return new ValidationResult(false, "dòng không hợp lệ");
            else if (string.IsNullOrEmpty(cusTier.CustomerTierName) || string.IsNullOrWhiteSpace(cusTier.CustomerTierName))
                return new ValidationResult(false, "không thể bỏ trống tên loại phòng");
            return ValidationResult.ValidResult;
        }
    }
}
