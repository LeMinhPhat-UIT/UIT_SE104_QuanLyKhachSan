using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using QuanLyKhachSan.UI.Views.SubViews;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel
{
    public class StatusToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value?.ToString();
            return status switch
            {
                "CheckIn" => (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E8F1FD")),
                "Pending" => (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FEECEB")),
                _ => Brushes.Transparent
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReservationWViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserViewModel _user;
        private readonly SidebarCommand _sidebarCommand;
        private ObservableCollection<ReservationViewModel> _reservations;
        private ReservationViewModel _selectedReservation;
        private string _roomNumberToSeach;

        public List<string> StatusValues { get; set; } = new List<string> { "Pending", "CheckIn", "CheckOut", "Cancelled" };

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public UserViewModel User => _user;
        public SidebarCommand SidebarCommand => _sidebarCommand;
        public ReservationViewModel SelectedReservation { get => _selectedReservation; set { _selectedReservation = value; OnPropertyChanged(nameof(SelectedReservation)); } }
        public string SearchingRoomNumber { get => _roomNumberToSeach; set { _roomNumberToSeach = value; OnPropertyChanged(nameof(SearchingRoomNumber)); } }

        public ICommand SelectedChanged { get; }
        public ICommand Search { get; }
        public ICommand ShowDetail { get; }
        public ReservationWViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _user = navigationStore.User;
            _reservations = new ObservableCollection<ReservationViewModel>();
            _sidebarCommand = new SidebarCommand(navigationStore);
            _selectedReservation = new ReservationViewModel();


            var reservationList = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetAllData()
                .Where(x => x.Status == "Pending" || x.Status == "CheckIn").ToList();
            reservationList.ForEach(x => _reservations.Add(new ReservationViewModel(x)));

            SelectedChanged = new ReservationCommand(this, _ => UpdateReservation());

            Search = new ReservationCommand(this, _ => SearchByRoomNumber(SearchingRoomNumber));

            ShowDetail = new ReservationCommand(this, _ => OpenReservationDetail());
        }

        private void OpenReservationDetail()
        {
            var viewmodel = new RoomDetailViewModel(SelectedReservation);
            var reservationDetailWindow = new ReservationDetailWindow()
            {
                DataContext = viewmodel,
            };
            viewmodel.CloseAction = () => reservationDetailWindow.Close();
            reservationDetailWindow.ShowDialog();
        }

        private void SearchByRoomNumber(string roomNumber)
        {
            if (!string.IsNullOrEmpty(roomNumber) || !string.IsNullOrWhiteSpace(roomNumber))
            {
                var reservationList = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetAllData()
                .Where(x =>
                {
                    x.Room = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetRoom(x.ReservationID);
                    return (x.Status == "Pending" || x.Status == "CheckIn") && x.Room.RoomNumber.Contains(roomNumber);
                }).ToList();
                _reservations.Clear();
                reservationList.ToList().ForEach(x => _reservations.Add(new ReservationViewModel(x)));
            }
            else
            {
                _reservations.Clear();
                var reservationList = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetAllData()
                .Where(x => x.Status == "Pending" || x.Status == "CheckIn").ToList();
                reservationList.ForEach(x => _reservations.Add(new ReservationViewModel(x)));
            }
        }

        private void UpdateReservation()
        {
            var reservation = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetById(SelectedReservation.ReservationID);
            reservation.Status = SelectedReservation.Status;
            if (SelectedReservation.Status == "CheckIn")
            {
                var viewmodel = new RoomDetailViewModel(SelectedReservation);
                var roomDetailWindow = new ReservationDetailWindow
                {
                    DataContext = viewmodel,
                };
                viewmodel.CloseAction = () => roomDetailWindow.Close();
                roomDetailWindow.ShowDialog();
            }
            else if (SelectedReservation.Status == "Cancelled")
            {
                _reservations.Remove(SelectedReservation);
                SelectedReservation = new ReservationViewModel();
            }
            else if (SelectedReservation.Status == "CheckOut")
            {
                var viewmodel = new InvoiceWViewModel(SelectedReservation);
                var invoiceWindow = new InvoiceWindow()
                {
                    DataContext = viewmodel,
                };
                viewmodel.CloseAction = () => invoiceWindow.Close();
                invoiceWindow.ShowDialog();
                _reservations.Remove(SelectedReservation);
                _selectedReservation = new ReservationViewModel();
            }
            QuanLyKhachSan.Models.BLL.Service.ReservationService.Update(reservation);
        }
    }
}
