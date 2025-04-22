using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.DAL;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class RoomService : IBusinessService<Room>
    {
        public Room GetById(int id)
            => DALs.RoomRepo.GetById(id);

        public List<Room> GetAllData()
            => DALs.RoomRepo.GetAllData();

        public void Add(Room room)
            => DALs.RoomRepo.Add(room);

        public void Delete(int Id)
            => DALs.RoomRepo.Delete(Id);

        public void Update(Room room)
            => DALs.RoomRepo.Update(room);

        public RoomTier GetTier(int Id)
            => DALs.RoomRepo.GetTier(Id);

        public List<Rental> GetRentalDetail(int Id)
            => DALs.RoomRepo.GetRentalDetail(Id);

        public List<Room> Search(Room template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.Room.AsQueryable();
            var props = typeof(Room).GetProperties();
            props.ToList().ForEach(
                prop =>
                {
                    var value = prop.GetValue(template);
                    if (value == null) return;
                    if (prop.PropertyType == typeof(string))
                    {
                        string strValue = value as string;
                        if (!string.IsNullOrWhiteSpace(strValue))
                        {
                            list = list.Where(a =>
                                EF.Functions.Like(EF.Property<string>(a, prop.Name), $"%{strValue}%"));
                        }
                    }
                    else if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                    {
                        // kiểu nullable như int?, DateTime?, bool?
                        list = list.Where(a =>
                            EF.Property<object>(a, prop.Name).Equals(value));
                    }
                }
            );
            return list.ToList();
        }
    }
}
