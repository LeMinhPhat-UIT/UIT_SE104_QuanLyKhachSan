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

        public Room GetRoom(int Id)
            => LoadRoom(GetById(Id)).Room;

        public RentalForm LoadRoom(RentalForm rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.Room).Load();
            return rent;
        }

        public User GetUser(int Id)
            => LoadUser(GetById(Id)).User;

        public RentalForm LoadUser(RentalForm rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.User).Load();
            return rent;
        }

        public Invoice GetInvoice(int Id)
            => LoadUser(GetById(Id)).Invoice;

        public RentalForm LoadInvoice(RentalForm rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.Invoice).Load();
            return rent;
        }

        public List<RentalDetail> GetDetail(int Id)
            => LoadDetail(GetById(Id)).RentalDetails;

        public RentalForm LoadDetail(RentalForm rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Collection(c => c.RentalDetails).Load();
            return rent;
        }
    }
}
