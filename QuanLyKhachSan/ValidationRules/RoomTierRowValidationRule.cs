using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;


namespace QuanLyKhachSan.ValidationRules
{
    public class RoomTierRowValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bindingGroup = (BindingGroup)value;
            RoomTierViewModel roomTier = bindingGroup.Items[0] as RoomTierViewModel;
            if (roomTier == null)
                return new ValidationResult(false, "dòng không hợp lệ");
            else if (string.IsNullOrEmpty(roomTier.RoomTierName) || string.IsNullOrWhiteSpace(roomTier.RoomTierName))
                return new ValidationResult(false, "không thể bỏ trống tên loại phòng");
            else if (roomTier.RoomTierPrice <= 0)
                return new ValidationResult(false, "giá loại phòng phải lớn hơn 0");
            return ValidationResult.ValidResult;
        }
    }
}
