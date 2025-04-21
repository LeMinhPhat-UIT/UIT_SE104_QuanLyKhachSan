using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class StaffDAL : IEntityRepository<Staff>
    {
        public Staff? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.Staff
                    where c.StaffID == id
                    select c).FirstOrDefault();
        }

        public List<Staff> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Staff.ToList();
        }

        public void Add(Staff staff)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Staff.Add(staff);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Staff staffInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(staffInfo);
            dbcontext.Entry(staffInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
