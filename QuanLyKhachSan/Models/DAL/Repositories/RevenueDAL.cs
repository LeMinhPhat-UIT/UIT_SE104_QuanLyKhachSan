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
    public class RevenueDAL : IEntityRepository<RevenueReport>
    {
        public RevenueReport? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.RevenueReport
                    where c.ReportID == id
                    select c).FirstOrDefault();
        }

        public List<RevenueReport> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.RevenueReport.ToList();
        }

        public void Add(RevenueReport report)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.RevenueReport.Add(report);
            dbcontext.SaveChanges();
        }

        public void Delete(int month)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(month));
            dbcontext.SaveChanges();
        }

        public void Update(RevenueReport reportInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(reportInfo);
            dbcontext.Entry(reportInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public User GetUser(int Id)
            => LoadUser(GetById(Id)).User;

        public RevenueReport LoadUser(RevenueReport report)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(report);
            e.Reference(c => c.User).Load();
            return report;
        }

        public RoomTier GetRoomTier(int Id)
            => LoadTier(GetById(Id)).RoomTier;

        public RevenueReport LoadTier(RevenueReport report)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(report);
            e.Reference(c => c.RoomTier).Load();
            return report;
        }

        public List<RevenueDetail> GetDetail(int Id)
            => LoadDetail(GetById(Id)).RevenueDetails;

        public RevenueReport LoadDetail(RevenueReport report)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(report);
            e.Collection(c => c.RevenueDetails).Load();
            return report;
        }
    }
}
