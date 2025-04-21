using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class InvoiceDAL : IEntityRepository<Invoice>
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
    }
}
