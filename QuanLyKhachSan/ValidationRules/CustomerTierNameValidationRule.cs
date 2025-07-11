using Microsoft.IdentityModel.Tokens;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace QuanLyKhachSan.ValidationRules
{
    public class CustomerTierNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return new ValidationResult(false, "không thể để trống tên loại khách hàng");
            if (Char.IsDigit(name[0]))
                return new ValidationResult(false, "ký tự đầu không được là một số");
            return ValidationResult.ValidResult;
        }
    }
}
