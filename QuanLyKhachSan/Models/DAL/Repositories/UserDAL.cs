using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    internal class UserDAL : IEntityRepository<User>
    {
        public User? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.User
                    where c.UserID == id
                    select c).FirstOrDefault();
        }

        public List<User> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.User.ToList();
        }

        public void Add(User user)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.User.Add(user);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(User userInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(userInfo);
            dbcontext.Entry(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public List<Invoice> GetInvoices(int id) 
            => LoadInvoices(GetById(id)).Invoices;

        public User LoadInvoices(User user)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(user);
            e.Collection(c => c.Invoices).Load();
            return user;
        }

        public List<Reservation> GetReservations(int id)
            => LoadReservations(GetById(id)).Reservations;

        public User LoadReservations(User user)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(user);
            e.Collection(c => c.Reservations).Load();
            return user;
        }

        public List<RevenueReport> GetReports(int id)
            => LoadReports(GetById(id)).RevenueReports;

        public User LoadReports(User user)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(user);
            e.Collection(c => c.Invoices).Load();
            return user;
        }
    }
}
