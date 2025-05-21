using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Helpers.Validation;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class ReservationService : IBusinessService<Reservation>
    {
        public Reservation GetById(int id)
            => RepositoryHub.ReservationRepo.GetById(id);

        public List<Reservation> GetAllData()
            => RepositoryHub.ReservationRepo.GetAllData();

        public void Add(Reservation reservation)
        {
            if(CheckValid.IsReservationValid(reservation))
                RepositoryHub.ReservationRepo.Add(reservation);
            AddCustomer(reservation.ReservationID, reservation.CustomerID);
            var room = Service.RoomService.GetById(reservation.RoomID);
            room.RoomState = "Occupied";
            Service.RoomService.Update(room);
        }

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.ReservationRepo.Delete(Id);
        }
        public void Update(Reservation reservation)
        {
            if(reservation.Status == "CheckOut" || reservation.Status == "Cancelled")
            {
                var room = Service.RoomService.GetById(reservation.RoomID);
                room.RoomState = "Available";
                Service.RoomService.Update(room);
                if (reservation.Status == "Cancelled")
                {
                    using var dbcontext = new HotelDbContext();
                    var rent = dbcontext.Reservation
                        .Include(x => x.Invoice)
                        .FirstOrDefault(x => x.ReservationID == reservation.ReservationID);
                    var inv = Service.InvoiceService.GetById(rent.Invoice.InvoiceID);
                    if (inv.ReportID != null)
                    {
                        MessageBox.Show(
                            @"This reservation cannot be canceled because its invoice has already been included in a revenue report.",
                            "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
                        return;
                    }
                    else
                        Service.InvoiceService.Delete(rent.Invoice.InvoiceID);
                }
            }
            RepositoryHub.ReservationRepo.Update(reservation);
        }
        public void AddCustomer(int resevationID, int customerID)
            => RepositoryHub.ReservationRepo.AddCustomer(resevationID, customerID);

        public void DeleteCustomer(int reservationID, int customerID)
            => RepositoryHub.ReservationRepo.DeleteCustomer(reservationID, customerID);

        public Room GetRoom(int Id)
            => RepositoryHub.ReservationRepo.GetRoom(Id);

        public User GetUser(int Id)
            => RepositoryHub.ReservationRepo.GetUser(Id);

        public Invoice GetInvoice(int Id)
            => RepositoryHub.ReservationRepo.GetInvoice(Id);

        //public List<Reservation_Customer> GetDetail(int Id)
        //    => RepositoryHub.ReservationRepo.GetDetail(Id);
    }
}
