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
    internal class RoomTierDAL : IEntityRepository<RoomTier>
    {
        public RoomTier? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from rt in dbcontext.RoomTier
                    where rt.RoomTierID == id
                    select rt).FirstOrDefault();
        }

        public List<RoomTier> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.RoomTier.ToList();
        }

        public void Add(RoomTier entitie)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.RoomTier.Add(entitie);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(RoomTier roomTierInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(roomTierInfo);
            dbcontext.Entry(roomTierInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public List<Room> GetRooms(int Id)
            => LoadRooms(GetById(Id)).Rooms;

        public RoomTier LoadRooms(RoomTier tier)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(tier);
            e.Collection(c => c.Rooms).Load();
            return tier;
        }
        public List<RevenueReport> GetReports(int Id)
            => LoadReports(GetById(Id)).RevenueReports;

        public RoomTier LoadReports(RoomTier tier)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(tier);
            e.Collection(c => c.RevenueReports).Load();
            return tier;
        }
    }
}
