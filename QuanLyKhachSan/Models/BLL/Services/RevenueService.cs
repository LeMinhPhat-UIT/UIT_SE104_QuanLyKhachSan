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
    public class RevenueService : IBusinessService<RevenueReport>
    {
        public RevenueReport GetById(int id)
            => DALs.RevenueRepo.GetById(id);

        public List<RevenueReport> GetAllData()
            => DALs.RevenueRepo.GetAllData();

        public void Add(RevenueReport revenue)
            => DALs.RevenueRepo.Add(revenue);

        public void Delete(int Id)
            => DALs.RevenueRepo.Delete(Id);

        public void Update(RevenueReport revenue)
            => DALs.RevenueRepo.Update(revenue);

        public User GetUser(int Id)
            => DALs.RevenueRepo.GetUser(Id);

        public RoomTier GetRoomTier(int Id)
            => DALs.RevenueRepo.GetRoomTier(Id);

        public List<RevenueDetail> GetDetail(int Id)
            => DALs.RevenueRepo.GetDetail(Id);

        public List<RevenueReport> Search(RevenueReport template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.MonthlyRevenueReport.AsQueryable();
            var props = typeof(RevenueReport).GetProperties();
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
