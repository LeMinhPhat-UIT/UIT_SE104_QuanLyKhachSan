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
    public class CustomerTierService : IBusinessService<CustomerTier>
    {
        public CustomerTier GetById(int id)
            => DALs.CustomerTierRepo.GetById(id);

        public List<CustomerTier> GetAllData()
            => DALs.CustomerTierRepo.GetAllData();

        public void Add(CustomerTier tier)
            => DALs.CustomerTierRepo.Add(tier);

        public void Delete(int Id)
            => DALs.CustomerTierRepo.Delete(Id);

        public void Update(CustomerTier tier)
            => DALs.CustomerTierRepo.Update(tier);

        public List<Customer> GetCustomers(int Id)
            => DALs.CustomerTierRepo.GetCustomers(Id);

        public List<CustomerTier> Filter(CustomerTier template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.CustomerTier.AsQueryable();
            var props = typeof(CustomerTier).GetProperties();
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
