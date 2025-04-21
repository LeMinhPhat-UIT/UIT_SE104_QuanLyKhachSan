using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class CustomerDAL : IEntityRepository<Customer>
    {
        public Customer? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.Customer
                    where c.CustomerID == id
                    select c).FirstOrDefault();
        }

        public List<Customer> GetAllData() 
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Customer.ToList();
        }

        public void Add(Customer customer)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Customer.Add(customer);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Customer customerInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(customerInfo);
            dbcontext.Entry(customerInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
