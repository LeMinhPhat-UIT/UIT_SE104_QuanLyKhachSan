using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RevenueDetailDAL : IDetailRepository<RevenueDetail>
    {
        public void Add(RevenueDetail detail)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Add(detail);
            dbcontext.SaveChanges();
        }
        public void Delete(int id, int invoiceID)
        {
            using var dbcontext = new HotelDbContext();
            var detail = (from d in dbcontext.RevenueDetail
                          where d.ReportID == id && d.InvoiceID == invoiceID
                          select d).FirstOrDefault();
            dbcontext.Remove(detail);
            dbcontext.SaveChanges();
        }
        public void Update(RevenueDetail revenueDetail)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(revenueDetail);
            dbcontext.Entry(revenueDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
