using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class InvoiceViewModel : BaseViewModel
    {
        private int _id;
        private int _surchargeRate;
        private DateTime _invoiceDate;
        private double _coef;
        private double _total;
        private string _payment;
        private string _status = "Pending";
        private RoomViewModel _room;
        private ReservationViewModel _reservation;



        public int ID { get => _id; set { _id = value; OnPropertyChanged(nameof(ID)); } }
        public int SurchargeRate { get => _surchargeRate; set { _surchargeRate = value; OnPropertyChanged(nameof(SurchargeRate)); GetTotal(); } }
        public DateTime InvoiceDate { get => _invoiceDate; set { _invoiceDate = value; OnPropertyChanged(nameof(InvoiceDate)); } }
        public double Coef { get => _coef; set { _coef = value; OnPropertyChanged(nameof(Coef)); GetTotal(); } }
        public double Total { get => _total; set { _total = value; OnPropertyChanged(nameof(Total)); } }
        public string PaymentMethod { get => _payment; set { _payment = value; OnPropertyChanged(nameof(PaymentMethod)); } }
        public string Status { get => _status; set { _status = value; OnPropertyChanged(nameof(Status)); } }

        public InvoiceViewModel(RoomViewModel roomViewModel, ReservationViewModel reservationViewModel)
        {
            SurchargeRate = 0;
            Coef = 1;
            Total = 0;

            _room = roomViewModel;
            _reservation = reservationViewModel;
        }

        public InvoiceViewModel(Invoice invoice)
        {
            ID = invoice.InvoiceID;
            SurchargeRate = invoice.SurchargeRate;
            InvoiceDate = invoice.InvoiceDate;
            Coef = (double)invoice.Coef;
            Total = (double)invoice.TotalAmount;
            PaymentMethod = invoice.PaymentMethod;
            Status = invoice.Status;
        }

        public Invoice ToInvoice()
        {
            var invoice = new Invoice()
            {
                SurchargeRate = SurchargeRate,
                InvoiceDate = InvoiceDate,
                Coef = (decimal)Coef,
                TotalAmount = (decimal)Total,
                PaymentMethod = PaymentMethod,
                Status = Status
            };
            return invoice;
        }

        public double GetTotal()
        {   if(_room == null || _reservation == null) return 0;
            Total = (double)_room.PricePerDay * _reservation.Nights * (100 + SurchargeRate) * Coef / 100;
            return Total;
        }
    }
}
