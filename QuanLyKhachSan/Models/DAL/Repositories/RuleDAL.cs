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
    public class RuleDAL : IEntityRepository<Rule>
    {
        public Rule? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from r in dbcontext.Rule
                    where r.RuleID == id
                    select r).FirstOrDefault();
        }
        public List<Rule> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Rule.ToList();
        }

        public void Delete(int ID)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(ID));
            dbcontext.SaveChanges();
        }

        public void Add(Rule rule)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Rule.Add(rule);
            dbcontext.SaveChanges();
        }

        public void Update(Rule rule)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(rule);
            dbcontext.Entry(rule).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
