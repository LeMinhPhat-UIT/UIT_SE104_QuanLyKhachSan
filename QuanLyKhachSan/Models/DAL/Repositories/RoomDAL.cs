using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    internal class RoomDAL : IEntityRepository<Room>
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

        public void AddAmenity(Room room, Amenity amenity)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(room);
            room.Amenities.Add(amenity);
            dbcontext.SaveChanges();
        }

        public void DeleteAmenity(int roomID, int amenityID)
        {
            using var dbcontext = new HotelDbContext();
            var room = dbcontext.Room.Include(x => x.Amenities).FirstOrDefault(x => x.RoomID == roomID);
            var amenity = room.Amenities.FirstOrDefault(x => x.AmenityID == amenityID);
            room.Amenities.Remove(amenity);
            dbcontext.SaveChanges();
        }

        public RoomTier GetTier(int Id)
            => LoadRoomTier(GetById(Id)).RoomTier;

        public Room LoadRoomTier(Room room)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(room);
            e.Reference(c => c.RoomTier).Load();
            return room;
        }

        public List<Reservation> GetReservations(int Id)
            => LoadReservations(GetById(Id)).Reservations;

        public Room LoadReservations(Room room)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(room);
            e.Collection(c => c.Reservations).Load();
            return room;
        }

        public List<Reservation> GetAmenities(int Id)
            => LoadAmenities(GetById(Id)).Reservations;

        public Room LoadAmenities(Room room)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(room);
            e.Collection(c => c.Amenities).Load();
            return room;
        }
    }
}
