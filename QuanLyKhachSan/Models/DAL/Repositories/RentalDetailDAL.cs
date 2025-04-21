using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    public class RentalDetailDAL : IDetailRepository<RentalDetail>
    {
        public void Add(params RentalDetail[] rentalDetails)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Add(rentalDetails);
            dbcontext.SaveChanges();
        }

        public void Delete(int rentalID, int customerID)
        {
            using var dbcontext = new HotelDbContext();
            var rentalDetail = (from rd in dbcontext.RentalDetail
                                where rd.RentalFormID == rentalID && rd.CustomerID == customerID
                                select rd).FirstOrDefault();
            dbcontext.Remove(rentalDetail);
            dbcontext.SaveChanges();
        }
    }
}
