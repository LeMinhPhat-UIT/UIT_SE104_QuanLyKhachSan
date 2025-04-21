using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class CustomerTierDAL : IEntityRepository<CustomerTier>
    {
        public CustomerTier? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from ct in dbcontext.CustomerTier
                    where ct.CustomerTierID == id
                    select ct).FirstOrDefault();
        }

        public List<CustomerTier> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.CustomerTier.ToList();
        }

        public void Add(CustomerTier entities)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.CustomerTier.Add(entities);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(CustomerTier customerTierInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(customerTierInfo);
            dbcontext.Entry(customerTierInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
