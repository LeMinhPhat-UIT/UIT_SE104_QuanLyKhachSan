using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class ReservationViewModel : BaseViewModel
    {
        private DateTime _checkIn;
        private DateTime _checkOut;
        private ObservableCollection<CustomerViewModel> _customers = new ObservableCollection<CustomerViewModel>();
        private string _status;
        
        public int ReservationID { get; set; }
        public string RoomNumber { get; set; }
        public DateTime CheckIn { get => _checkIn; set { _checkIn = value; OnPropertyChanged(nameof(CheckIn)); OnPropertyChanged(nameof(Nights)); } }
        public DateTime CheckOut { get => _checkOut; set { _checkOut = value; OnPropertyChanged(nameof(CheckOut)); OnPropertyChanged(nameof(Nights)); } }
        public int Nights => (CheckOut - CheckIn).Days;
        public string Status { get => _status; set { _status = value; OnPropertyChanged(nameof(Status)); } }
        public IEnumerable<CustomerViewModel> Customers => _customers;

        public ReservationViewModel() 
        {
            CheckIn = DateTime.Now.Date;
            CheckOut = DateTime.Now.Date;
            Status = "Pending";
        }
        public ReservationViewModel(Reservation reservation)
        {
            ReservationID = reservation.ReservationID;
            RoomNumber = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetRoom(reservation.ReservationID).RoomNumber;
            CheckIn = reservation.CheckInDate;
            CheckOut = reservation.CheckOutDate;
            QuanLyKhachSan.Models.BLL.Service.ReservationService
                .GetCustomers(reservation.ReservationID)
                .ForEach(x => _customers?.Add(new CustomerViewModel(x)));
            Status = reservation.Status;
        }

        public int GetNights()
            => (CheckOut - CheckIn).Days;

        public int GetCustomersCount()
            => Customers.ToList().Count;
    }
}
