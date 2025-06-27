using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    internal class ReservationDAL : IEntityRepository<Reservation>
    {
        public Reservation? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from rf in dbcontext.Reservation
                    where rf.ReservationID == id
                    select rf).FirstOrDefault();
        }

        public List<Reservation> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Reservation.ToList();
        }

        public void Add(Reservation entity)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Reservation.Add(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Reservation reservation)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(reservation);
            dbcontext.Entry(reservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void AddCustomer(int reservationID, int customerID)
        {
            using var dbcontext = new HotelDbContext();
            var reservation = dbcontext.Reservation.Include(r => r.Customers).FirstOrDefault(r => r.ReservationID == reservationID);
            var customer = RepositoryHub.CustomerRepo.GetById(customerID);
            reservation.Customers.Add(customer);
            dbcontext.SaveChanges(); 
        }

        public void DeleteCustomer(int reservationID, int customerID)
        {
            using var dbcontext = new HotelDbContext();
            var reservation = dbcontext.Reservation.Include(x => x.Customers).FirstOrDefault(x => x.ReservationID == reservationID);
            var customer = reservation.Customers.FirstOrDefault(x => x.CustomerID == customerID);
            reservation.Customers.Remove(customer);
            dbcontext.SaveChanges();
        }

        public Room GetRoom(int Id)
            => LoadRoom(GetById(Id)).Room;

        public Reservation LoadRoom(Reservation rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.Room).Load();
            return rent;
        }

        public User GetUser(int Id)
            => LoadUser(GetById(Id)).User;

        public Reservation LoadUser(Reservation rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.User).Load();
            return rent;
        }

        public Invoice GetInvoice(int Id)
            => LoadInvoice(GetById(Id)).Invoice;

        public Reservation LoadInvoice(Reservation rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.Invoice).Load();
            return rent;
        }

        public List<Customer> GetCustomers(int Id)
            => LoadCustomers(GetById(Id)).Customers;

        public Reservation LoadCustomers(Reservation rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Collection(c => c.Customers).Load();
            return rent;
        }
    }
}
