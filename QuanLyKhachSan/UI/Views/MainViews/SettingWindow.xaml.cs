﻿using System;
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
using QuanLyKhachSan.Models.BLL.Helpers.Security;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.UI.Views.MainViews
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : UserControl
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_RoomTier_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var dataGrid = sender as DataGrid;
                if (dataGrid == null) return;

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (Validation.GetHasError(e.Row))
                        e.Cancel = true;
                    else
                    {
                        var item = e.Row.Item as RoomTierViewModel;
                        if (item != null)
                        {
                            RoomTier roomTier = new RoomTier()
                            {
                                RoomTierName = item.RoomTierName,
                                RoomTierPrice = item.RoomTierPrice,
                                
                            };
                            if (item.ID != 0)
                            {
                                roomTier.RoomTierID = item.ID;
                                QuanLyKhachSan.Models.BLL.Service.RoomTierService.Update(roomTier);
                            }
                            else
                            {
                                QuanLyKhachSan.Models.BLL.Service.RoomTierService.Add(roomTier);
                                item.ID = roomTier.RoomTierID;
                            }
                        }
                    }
                }), System.Windows.Threading.DispatcherPriority.Background);
            }
        }

        private void DataGrid_CustomerTier_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var dataGrid = sender as DataGrid;
                if (dataGrid == null) return;

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (Validation.GetHasError(e.Row))
                        e.Cancel = true;
                    else
                    {
                        var item = e.Row.Item as CustomerTierViewModel;
                        if (item != null)
                        {
                            CustomerTier cusTier = new CustomerTier()
                            {
                                CustomerTierName = item.CustomerTierName,
                            };
                            if (item.ID != 0) 
                            {
                                cusTier.CustomerTierID = item.ID;
                                QuanLyKhachSan.Models.BLL.Service.CustomerTierService.Update(cusTier);
                            }
                            else 
                            {
                                QuanLyKhachSan.Models.BLL.Service.CustomerTierService.Add(cusTier);
                                item.ID = cusTier.CustomerTierID;
                            }
                        }
                    }
                }), System.Windows.Threading.DispatcherPriority.Background);
            }
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
                var viewmodel = DataContext as SettingViewModel;
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
                var viewmodel = DataContext as SettingViewModel;
                viewmodel.SidebarCommand.Logout?.Execute(null);
            }
        }
    }
}
