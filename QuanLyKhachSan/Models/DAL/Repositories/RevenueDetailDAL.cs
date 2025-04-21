using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RevenueDetailDAL : IDetailRepository<MonthlyRevenueDetail>
    {
        public void Add(params MonthlyRevenueDetail[] details)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.AddRange(details);
            dbcontext.SaveChanges();
        }
        public void Delete(int month, int tierID)
        {
            using var dbcontext = new HotelDbContext();
            var detail = (from d in dbcontext.MonthlyRevenueDetail
                          where d.ReportMonth.Month == month && d.RoomTierID == tierID
                          select d).FirstOrDefault();
            dbcontext.Remove(detail);
            dbcontext.SaveChanges();
        }
        public void Update(MonthlyRevenueDetail revenueDetail)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(revenueDetail);
            dbcontext.Entry(revenueDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
