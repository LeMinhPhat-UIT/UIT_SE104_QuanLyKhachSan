using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class UserDAL : IEntityRepository<User>
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

        public void Add(User staff)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.User.Add(staff);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(User staffInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(staffInfo);
            dbcontext.Entry(staffInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public List<Invoice> GetInvoice(int id) 
            => LoadInvoice(GetById(id)).Invoices;

        public User LoadInvoice(User user)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(user);
            e.Collection(c => c.Invoices).Load();
            return user;
        }

        public List<Rental> GetRentalForm(int id)
            => LoadRentalForm(GetById(id)).RentalForms;

        public User LoadRentalForm(User user)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(user);
            e.Collection(c => c.Invoices).Load();
            return user;
        }

        public List<RevenueReport> GetReport(int id)
            => LoadReport(GetById(id)).RevenueReports;

        public User LoadReport(User user)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(user);
            e.Collection(c => c.Invoices).Load();
            return user;
        }
    }
}
