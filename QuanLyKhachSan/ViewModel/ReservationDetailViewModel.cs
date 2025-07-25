﻿using System;
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
using Microsoft.Azure.Cosmos.Spatial;

namespace QuanLyKhachSan.ViewModel
{
    public class RoomDetailViewModel : BaseViewModel
    {
        private ReservationViewModel _reservation;
        private CustomerViewModel _selectedCustomer;

        public ReservationViewModel Reservation { get => _reservation; set { _reservation = value; OnPropertyChanged(nameof(Reservation)); } }
        public CustomerViewModel SelectedCustomer { get => _selectedCustomer; set { _selectedCustomer = value; OnPropertyChanged(nameof(SelectedCustomer)); } }
        public bool IsSaved { get; set; } = false;

        public Action? CloseAction { get; set; }

        public ICommand Close { get; set; }
        public ICommand CustomerAdd { get; set; }
        public ICommand CustomerDelete { get; set; }
        public ICommand Save { get; set; }

        public RoomDetailViewModel(ReservationViewModel reservation)
        {
            _reservation = reservation;
            Close = new RoomDetailCommand(this, _ => CloseAction?.Invoke());
            CustomerAdd = new RoomDetailCommand(this, _ => OpenAndAddCustomer(), _ => Reservation.Customers.Count() < Reservation.CustomersCount);
            CustomerDelete = new RoomDetailCommand(this, _ => DeleteCustomer());
            Save = new RoomDetailCommand(this, _ => SaveAndClose());
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer != null && SelectedCustomer.ID != Reservation.Customers.First().ID)
            {
                if (QuanLyKhachSan.Models.BLL.Service.CustomerService.GetReservations(SelectedCustomer.ID).Count == 0)
                    QuanLyKhachSan.Models.BLL.Service.CustomerService.Delete(SelectedCustomer.ID);
                Reservation.DeleteCustomer(SelectedCustomer);
            }
        }

        private void SaveAndClose()
        {
            IsSaved = true;
            var invoiceOfThisReservation = QuanLyKhachSan.Models.BLL.Service.InvoiceService.GetAllData().FirstOrDefault(x => x.ReservationID == Reservation.ReservationID);
            if (Reservation.Customers.Count() < Reservation.CustomersCount)
            {
                string message = $"hãy cung cấp đầy đủ thông tin khách hàng, bạn đang thiếu {Reservation.CustomersCount - Reservation.Customers.Count()} khách hàng";
                if (invoiceOfThisReservation.Coef != 1)
                    message += " (có khách nước ngoài)";
                MessageBox.Show(message);
                IsSaved = false;
                return;
            }
            if (invoiceOfThisReservation.Coef != 1 && !Reservation.Customers.Any(x => x.CustomerTierName == "Nước ngoài"))
            {
                string message = "bạn cần có ít nhất một khách nước ngoài";
                MessageBox.Show(message);
                IsSaved = false; 
                return;
            }
            var realCustomerList = QuanLyKhachSan.Models.BLL.Service.ReservationService.GetCustomers(Reservation.ReservationID);
            Reservation.Customers.ToList().ForEach(x =>
            {
                if (realCustomerList.FirstOrDefault(y => y.CustomerID == x.ID) == null)
                    QuanLyKhachSan.Models.BLL.Service.ReservationService.AddCustomer(Reservation.ReservationID, x.ID);
            });
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
