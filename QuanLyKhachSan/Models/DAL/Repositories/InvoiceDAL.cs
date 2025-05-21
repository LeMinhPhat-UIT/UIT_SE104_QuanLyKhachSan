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
    internal class InvoiceDAL : IEntityRepository<Invoice>
    {
        public Invoice? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from i in dbcontext.Invoice
                    where i.InvoiceID == id
                    select i).FirstOrDefault();
        }

        public List<Invoice> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Invoice.ToList();
        }

        public void Add(Invoice invoice)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Invoice.Add(invoice);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Invoice invoiceInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(invoiceInfo);
            dbcontext.Entry(invoiceInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public User GetUser(int Id)
            => LoadUser(GetById(Id)).User;

        public Invoice LoadUser(Invoice invoice)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(invoice);
            e.Reference(c => c.User).Load();
            return invoice;
        }

        public RevenueReport GetRevenueReport(int Id)
            => LoadReport(GetById(Id)).RevenueReport;

        public Invoice LoadReport(Invoice invoice)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(invoice);
            e.Reference(c => c.RevenueReport).Load();
            return invoice;
        }

        public Reservation GetReservation(int Id)
            => LoadReservation(GetById(Id)).Reservation;

        public Invoice LoadReservation(Invoice invoice)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(invoice);
            e.Reference(c => c.Reservation).Load();
            return invoice;
        }
    }
}
