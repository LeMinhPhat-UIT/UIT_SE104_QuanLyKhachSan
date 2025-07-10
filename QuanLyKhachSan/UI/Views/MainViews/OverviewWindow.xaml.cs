using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using System.Windows.Controls.Primitives;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.Models.BLL.Helpers.Security;

namespace QuanLyKhachSan.UI.Views.MainViews
{
    /// <summary>
    /// Interaction logic for OverviewWindow.xaml
    /// </summary>
    public partial class OverviewWindow : UserControl
    {
        public OverviewWindow()
        {
            InitializeComponent();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordPopup.IsOpen = true;
            NewPasswordBox.Focus();
        }

        private void UpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = NewPasswordBox.Password;

            if (!string.IsNullOrEmpty(newPassword))
            {
                var viewmodel = DataContext as OverviewViewModel;
                var user = QuanLyKhachSan.Models.BLL.Service.UserService.GetById(viewmodel.User.ID);
                user.Password = PasswordService.HashPassword(newPassword);
                QuanLyKhachSan.Models.BLL.Service.UserService.Update(user);
                MessageBox.Show($"Mật khẩu đã được cập nhật thành, yêu cầu đăng nhập lại", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                ChangePasswordPopup.IsOpen = false;
                NewPasswordBox.Clear();
                viewmodel.SidebarCommand.Logout?.Execute(null);
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn thực sự muốn đăng xuất?", "Thông báo", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var viewmodel = DataContext as OverviewViewModel;
                viewmodel.SidebarCommand.Logout?.Execute(null);
            }
        }
    }
}
