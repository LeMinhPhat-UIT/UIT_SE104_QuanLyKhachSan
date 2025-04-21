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
    public class RevenueService : IBusinessService<MonthlyRevenueReport>
    {
        public MonthlyRevenueReport GetById(int id)
            => DALs.RevenueRepo.GetById(id);

        public List<MonthlyRevenueReport> GetAllData()
            => DALs.RevenueRepo.GetAllData();

        public void Add(MonthlyRevenueReport revenue)
            => DALs.RevenueRepo.Add(revenue);

        public void Delete(int Id)
            => DALs.RevenueRepo.Delete(Id);

        public void Update(MonthlyRevenueReport revenue)
            => DALs.RevenueRepo.Update(revenue);

        public List<MonthlyRevenueReport> Search(MonthlyRevenueReport template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.MonthlyRevenueReport.AsQueryable();
            var props = typeof(MonthlyRevenueReport).GetProperties();
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
