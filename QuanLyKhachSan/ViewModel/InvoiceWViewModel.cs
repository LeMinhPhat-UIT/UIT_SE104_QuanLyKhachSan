using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.ViewModel
{
    public class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.ToString() == parameter?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return parameter?.ToString();
            return Binding.DoNothing;
        }
    }

    public class InvoiceWViewModel : BaseViewModel
    {
        private InvoiceViewModel _invoice;
        private ReservationViewModel _reservation;
        private RoomViewModel _room;

        public Action? CloseAction { get; set; }

        public InvoiceViewModel Invoice { get => _invoice; set { _invoice = value; OnPropertyChanged(nameof(Invoice)); } }
        public ReservationViewModel Reservation { get => _reservation; set { _reservation = value; OnPropertyChanged(nameof(Reservation)); } }
        public int CustomersCount => Reservation.Customers.ToList().Count;
        public RoomViewModel Room { get => _room; set { _room = value; OnPropertyChanged(nameof(Room)); } }

        public ICommand Pay { get; }

        public InvoiceWViewModel(ReservationViewModel reservation)
        {
            _reservation = reservation;
            _invoice = new InvoiceViewModel(QuanLyKhachSan.Models.BLL.Service.ReservationService.GetInvoice(reservation.ReservationID));
            _room = new RoomViewModel(QuanLyKhachSan.Models.BLL.Service.ReservationService.GetRoom(reservation.ReservationID));

            Pay = new InvoiceCommand(this, _ => UpdateInvoice(), _ => !string.IsNullOrEmpty(Invoice.PaymentMethod));
        }

        private void UpdateInvoice()
        {
            var invoice = QuanLyKhachSan.Models.BLL.Service.InvoiceService.GetById(Invoice.ID);
            invoice.PaymentMethod = Invoice.PaymentMethod;
            invoice.Status = "Paid";
            QuanLyKhachSan.Models.BLL.Service.InvoiceService.Update(invoice);
            CloseAction?.Invoke();
        }
    }
}
