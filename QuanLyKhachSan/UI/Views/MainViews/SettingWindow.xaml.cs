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
            var item = e.Row.Item as RoomTierViewModel;

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (item != null && (string.IsNullOrEmpty(item.RoomTierName) || item.RoomTierPrice==0))
                {
                    var vm = this.DataContext as SettingViewModel;
                    if (vm != null)
                    {
                        vm.RemoveInvalidRoomTier(item);
                    }
                }
                else
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
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void DataGrid_CustomerTier_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var item = e.Row.Item as CustomerTierViewModel;

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (item != null && string.IsNullOrEmpty(item.CustomerTierName))
                {
                    var vm = this.DataContext as SettingViewModel;
                    if (vm != null)
                    {
                        vm.RemoveInvalidCustomerTier(item);
                    }
                }
                else
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
            }), System.Windows.Threading.DispatcherPriority.Background);
        }
    }
}
