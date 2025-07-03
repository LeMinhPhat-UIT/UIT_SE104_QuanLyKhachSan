using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.UI.Views.MainViews;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class SidebarCommand : BaseViewModel
    {
        private readonly NavigateCommand _navigateCommand;
        private readonly CreatViewModel _creatViewModel;

        public ICommand OverviewWindow { get; }
        public ICommand BookingWindow { get; }
        public ICommand RoomWindow { get; }
        public ICommand ReservationWindow { get; }
        public ICommand RevenueWindow { get; }
        public ICommand UserWindow { get; }
        public ICommand SettingWindow { get; }

        public SidebarCommand(NavigationStore navigationStore)
        {
            _creatViewModel = new CreatViewModel(navigationStore);

            OverviewWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateOverviewViewModel));
            BookingWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateBookingViewModel));
            RoomWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateRoomViewModel));
            ReservationWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateReservationViewModel));
            UserWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateUserViewModel), _ => navigationStore.User.UserRole=="Administrator");
            RevenueWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateRevenueViewModel), _ => navigationStore.User.UserRole == "Administrator");
            SettingWindow = new NavigateCommand(new Service.NavigationService(navigationStore, _creatViewModel.CreateSettingViewModel), _ => navigationStore.User.UserRole == "Administrator");
        }
    }
}
