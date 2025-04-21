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
    public class StaffService : IBusinessService<Staff>
    {
        public Staff GetById(int id)
            => DALs.StaffRepo.GetById(id);

        public List<Staff> GetAllData()
            => DALs.StaffRepo.GetAllData();

        public void Add(Staff staff)
            => DALs.StaffRepo.Add(staff);

        public void Delete(int Id)
            => DALs.StaffRepo.Delete(Id);

        public void Update(Staff staff)
            => DALs.StaffRepo.Update(staff);

        public List<Staff> Filter(Staff template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.Staff.AsQueryable();
            var props = typeof(Staff).GetProperties();
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
