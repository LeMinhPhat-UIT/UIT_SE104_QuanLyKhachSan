using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class InvoiceDetailDAL : IDetailRepository<InvoiceDetail>
    {
        public void Add(params InvoiceDetail[] details)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.AddRange(details);
            dbcontext.SaveChanges();
        }
        public void Delete(int invoiceID, int customerID)
        {
            using var dbcontext = new HotelDbContext();
            var detail = (from d in dbcontext.InvoiceDetail
                          where d.InvoiceID == invoiceID && d.CustomerID == customerID
                          select d).FirstOrDefault();
            dbcontext.Remove(detail);
            dbcontext.SaveChanges();
        }
        public void Update(InvoiceDetail invoiceDetail)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(invoiceDetail);
            dbcontext.Entry(invoiceDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
