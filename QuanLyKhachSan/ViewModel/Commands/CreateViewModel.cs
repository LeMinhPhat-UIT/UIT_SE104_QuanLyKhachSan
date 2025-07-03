using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class CreatViewModel
    {
        private readonly NavigationStore _navigationStore;

        public CreatViewModel(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
        }


        public OverviewViewModel CreateOverviewViewModel()
            => new OverviewViewModel(_navigationStore);

        public BookingViewModel CreateBookingViewModel()
            => new BookingViewModel(_navigationStore);

        public RoomWViewModel CreateRoomViewModel()
            => new RoomWViewModel(_navigationStore);

        public ReservationWViewModel CreateReservationViewModel()
            => new ReservationWViewModel(_navigationStore);

        public UserWViewModel CreateUserViewModel()
            => new UserWViewModel(_navigationStore);

        public RevenueViewModel CreateRevenueViewModel()
            => new RevenueViewModel(_navigationStore);

        public SettingViewModel CreateSettingViewModel()
            => new SettingViewModel(_navigationStore);
    }
}
