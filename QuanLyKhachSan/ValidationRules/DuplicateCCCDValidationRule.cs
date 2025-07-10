using System.Globalization;
using System.Windows.Controls;

namespace QuanLyKhachSan.ValidationRules
{
    public class DuplicateCCCDValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var cccd = value as string;
            var dupCCCD = QuanLyKhachSan.Models.BLL.Service.UserService.GetAllData().FirstOrDefault(x => x.IdentityNumber == cccd);
            if (dupCCCD != null)
                return new ValidationResult(false, "CCCD này đã tồn tại");
            return ValidationResult.ValidResult;
        }
    }
}
