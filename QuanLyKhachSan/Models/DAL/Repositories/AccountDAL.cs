using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class AccountDAL : IEntityRepository<Account>
    {
        public Account? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from a in dbcontext.Account
                    where a.StaffID == id
                    select a).FirstOrDefault();
        }

        public List<Account> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Account.ToList();
        }

        public void Add(Account newAccount)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Add(newAccount);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Account accountInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(accountInfo);
            dbcontext.Entry(accountInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
