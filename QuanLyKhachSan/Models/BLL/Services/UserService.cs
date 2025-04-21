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
    public class UserService : IBusinessService<User>
    {
        public User GetById(int id)
            => DALs.UserRepo.GetById(id);

        public List<User> GetAllData()
            => DALs.UserRepo.GetAllData();

        public void Add(User staff)
            => DALs.UserRepo.Add(staff);

        public void Delete(int Id)
            => DALs.UserRepo.Delete(Id);

        public void Update(User staff)
            => DALs.UserRepo.Update(staff);

        public List<User> Search(User template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.User.AsQueryable();
            var props = typeof(User).GetProperties();
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
