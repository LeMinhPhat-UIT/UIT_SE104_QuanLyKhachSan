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
    public class RoomTierService : IBusinessService<RoomTier>
    {
        public RoomTier GetById(int id)
            => DALs.RoomTierRepo.GetById(id);

        public List<RoomTier> GetAllData()
            => DALs.RoomTierRepo.GetAllData();

        public void Add(RoomTier tier)
            => DALs.RoomTierRepo.Add(tier);

        public void Delete(int Id)
            => DALs.RoomTierRepo.Delete(Id);

        public void Update(RoomTier tier)
            => DALs.RoomTierRepo.Update(tier);

        public List<RoomTier> Filter(RoomTier template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.RoomTier.AsQueryable();
            var props = typeof(RoomTier).GetProperties();
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
