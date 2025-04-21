using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.DAL.Interfaces;
using QuanLyKhachSan.Models.DAL.Repositories;

namespace QuanLyKhachSan.Models.DAL
{
    public class DALs
    {
        public static CustomerDAL CustomerRepo => new CustomerDAL();
        public static CustomerTierDAL CustomerTierRepo => new CustomerTierDAL();
        public static InvoiceDAL InvoiceRepo => new InvoiceDAL();
        public static RentalFormDAL RentalRepo => new RentalFormDAL();
        public static RevenueDAL RevenueRepo => new RevenueDAL();
        public static RoomDAL RoomRepo => new RoomDAL();
        public static RoomTierDAL RoomTierRepo => new RoomTierDAL();
        public static UserDAL UserRepo => new UserDAL();

        public static RentalDetailDAL RentalDetailRepo => new RentalDetailDAL();
        public static RevenueDetailDAL RevenueDetailRepo => new RevenueDetailDAL();
    }
}
