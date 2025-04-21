using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RoomDAL : IEntityRepository<Room>
    {
        public Room? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from r in dbcontext.Room
                    where r.RoomID == id
                    select r).FirstOrDefault();
        }

        public List<Room> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Room.ToList();
        }

        public void Add(Room entitie)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Room.Add(entitie);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Room roomInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(roomInfo);
            dbcontext.Entry(roomInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
