using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RentalDAL : IEntityRepository<Rental>
    {
        public Rental? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from rf in dbcontext.Rental
                    where rf.RentalFormID == id
                    select rf).FirstOrDefault();
        }

        public List<Rental> GetAllData()
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Rental.ToList();
        }

        public void Add(Rental entitie)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Rental.Add(entitie);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Rental rentalFormInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(rentalFormInfo);
            dbcontext.Entry(rentalFormInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public Room GetRoom(int Id)
            => LoadRoom(GetById(Id)).Room;

        public Rental LoadRoom(Rental rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.Room).Load();
            return rent;
        }

        public User GetUser(int Id)
            => LoadUser(GetById(Id)).User;

        public Rental LoadUser(Rental rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.User).Load();
            return rent;
        }

        public Invoice GetInvoice(int Id)
            => LoadUser(GetById(Id)).Invoice;

        public Rental LoadInvoice(Rental rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Reference(c => c.Invoice).Load();
            return rent;
        }

        public List<RentalDetail> GetDetail(int Id)
            => LoadDetail(GetById(Id)).RentalDetails;

        public Rental LoadDetail(Rental rent)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(rent);
            e.Collection(c => c.RentalDetails).Load();
            return rent;
        }
    }
}
