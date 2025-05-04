using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    internal class AmenityDAL : IEntityRepository<Amenity>
    {
        public Amenity? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from ct in dbcontext.Amenity
                    where ct.AmenityID == id
                    select ct).FirstOrDefault();
        }

        public List<Amenity> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Amenity.ToList();
        }

        public void Add(Amenity entities)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Amenity.Add(entities);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Amenity AmenityInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(AmenityInfo);
            dbcontext.Entry(AmenityInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public List<Room> GetRooms(int Id)
            => LoadRooms(GetById(Id)).Rooms;

        public Amenity LoadRooms(Amenity tier)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(tier);
            e.Collection(c => c.Rooms).Load();
            return tier;
        }
    }
}
