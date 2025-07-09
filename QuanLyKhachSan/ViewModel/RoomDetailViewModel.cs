using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.UI.Views.SubViews;
using System.Windows;

namespace QuanLyKhachSan.ViewModel
{
    public class RoomDetailViewModel : BaseViewModel
    {
        private ReservationViewModel _reservation;
        private CustomerViewModel _selectedCustomer;

        public ReservationViewModel Reservation { get => _reservation; set { _reservation = value; OnPropertyChanged(nameof(Reservation)); } }
        public CustomerViewModel SelectedCustomer { get => _selectedCustomer; set { _selectedCustomer = value; OnPropertyChanged(nameof(SelectedCustomer)); } }

        public Action? CloseAction { get; set; }

        public ICommand Close { get; set; }
        public ICommand CustomerAdd { get; set; }
        public ICommand CustomerDelete { get; set; }
        public ICommand Save { get; set; }

        public RoomDetailViewModel(ReservationViewModel reservation)
        {
            _reservation = reservation;
            Close = new RoomDetailCommand(this, _ => CloseAction?.Invoke());
            CustomerAdd = new RoomDetailCommand(this, _ => OpenAndAddCustomer());
            CustomerDelete = new RoomDetailCommand(this, _ => DeleteCustomer());
            Save = new RoomDetailCommand(this, _ => SaveAndClose());
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer != null && SelectedCustomer.ID != Reservation.Customers.First().ID)
                Reservation.DeleteCustomer(SelectedCustomer);
        }

        private void SaveAndClose()
        {
            if (Reservation.Customers.Count() < Reservation.CustomersCount)
            {
                MessageBox.Show($"Please fill in all the customers, you are missing {Reservation.CustomersCount - Reservation.Customers.Count()} customer(s)");
                return;
            }
            Reservation.Customers.ToList().ForEach(x =>
                QuanLyKhachSan.Models.BLL.Service.ReservationService.AddCustomer(Reservation.ReservationID, x.ID)
            );
            CloseAction?.Invoke();
        }

        private void OpenAndAddCustomer()
        {
            var viewmodel = new AddUpdateCustomerViewModel();
            var addUpdateCustomerWindow = new AddUpdateCustomerWindow()
            {
                DataContext = viewmodel,
            };
            viewmodel.CloseAction = () => addUpdateCustomerWindow.Close();
            addUpdateCustomerWindow.ShowDialog();
            if (viewmodel.Customer.ID != 0 && Reservation.Customers.Count() < Reservation.CustomersCount && Reservation.Customers.FirstOrDefault(x => x.ID == viewmodel.Customer.ID) == null)
            {
                Reservation.AddCustomer(viewmodel.Customer);
                //QuanLyKhachSan.Models.BLL.Service.ReservationService.AddCustomer(Reservation.ReservationID, viewmodel.Customer.ID);
            }
        }
    }
}
