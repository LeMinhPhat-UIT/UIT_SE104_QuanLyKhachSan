using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RevenueDAL : IEntityRepository<MonthlyRevenueReport>
    {
        public MonthlyRevenueReport? GetById(int month)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.MonthlyRevenueReport
                    where c.ReportMonth.Month == month
                    select c).FirstOrDefault();
        }

        public List<MonthlyRevenueReport> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.MonthlyRevenueReport.ToList();
        }

        public void Add(MonthlyRevenueReport report)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.MonthlyRevenueReport.Add(report);
            dbcontext.SaveChanges();
        }

        public void Delete(int month)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(month));
            dbcontext.SaveChanges();
        }

        public void Update(MonthlyRevenueReport reportInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(reportInfo);
            dbcontext.Entry(reportInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
