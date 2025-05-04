using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            AddCustomer(reservation, Service.CustomerService.GetById(reservation.CustomerID));
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
            }
            RepositoryHub.ReservationRepo.Update(reservation);
        }
        public void AddCustomer(Reservation resevation, Customer customer)
            => RepositoryHub.ReservationRepo.AddCustomer(resevation, customer);

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
