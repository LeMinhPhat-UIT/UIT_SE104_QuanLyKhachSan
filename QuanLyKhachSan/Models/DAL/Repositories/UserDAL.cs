using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class UserDAL : IEntityRepository<User>
    {
        public User? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.User
                    where c.UserID == id
                    select c).FirstOrDefault();
        }

        public List<User> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.User.ToList();
        }

        public void Add(User staff)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.User.Add(staff);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(User staffInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(staffInfo);
            dbcontext.Entry(staffInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
