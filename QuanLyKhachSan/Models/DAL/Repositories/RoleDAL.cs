using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RoleDAL : IEntityRepository<Role>
    {
        public Role? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from ct in dbcontext.Role
                    where ct.RoleID == id
                    select ct).FirstOrDefault();
        }

        public List<Role> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Role.ToList();
        }

        public void Add(Role role)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Role.Add(role);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Role RoleInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(RoleInfo);
            dbcontext.Entry(RoleInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public List<User> GetUsers(int id)
            => LoadUsers(GetById(id)).Users;

        public Role LoadUsers(Role role)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(role);
            e.Collection(c => c.Users).Load();
            return role;
        }
    }
}
