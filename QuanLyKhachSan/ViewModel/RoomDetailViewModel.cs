using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Commands;

namespace QuanLyKhachSan.ViewModel
{
    public class RoomDetailViewModel : BaseViewModel
    {
        private ReservationViewModel _reservation;

        public ReservationViewModel Reservation { get =>_reservation; set { _reservation = value; OnPropertyChanged(nameof(Reservation)); } }

        public Action? CloseAction { get; set; }

        public ICommand Close { get; set; }

        public RoomDetailViewModel(ReservationViewModel reservation) 
        {
            _reservation = reservation;
            Close = new RoomDetailCommand(this, _ => CloseAction?.Invoke());
        }
    }
}
