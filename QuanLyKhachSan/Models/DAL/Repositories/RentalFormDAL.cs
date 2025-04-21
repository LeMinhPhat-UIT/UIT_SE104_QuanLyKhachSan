using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RentalFormDAL : IEntityRepository<RentalForm>
    {
        public RentalForm? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from rf in dbcontext.RentalForm
                    where rf.RentalFormID == id
                    select rf).FirstOrDefault();
        }

        public List<RentalForm> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.RentalForm.ToList();
        }

        public void Add(RentalForm entitie)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.RentalForm.Add(entitie);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(RentalForm rentalFormInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(rentalFormInfo);
            dbcontext.Entry(rentalFormInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }
    }
}
