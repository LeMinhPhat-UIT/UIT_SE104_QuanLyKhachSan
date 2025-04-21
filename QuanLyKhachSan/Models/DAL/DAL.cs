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
        public static IEntityRepository<Account> AccountRepo => new AccountDAL();
        public static IEntityRepository<Customer> CustomerRepo => new CustomerDAL();
        public static IEntityRepository<CustomerTier> CustomerTierRepo => new CustomerTierDAL();
        public static IEntityRepository<Invoice> InvoiceRepo => new InvoiceDAL();
        public static IEntityRepository<RentalForm> RentalRepo => new RentalFormDAL();
        public static IEntityRepository<MonthlyRevenueReport> RevenueRepo => new RevenueDAL();
        public static IEntityRepository<Room> RoomRepo => new RoomDAL();
        public static IEntityRepository<RoomTier> RoomTierRepo => new RoomTierDAL();
        public static IEntityRepository<Staff> StaffRepo => new StaffDAL();

        public static IDetailRepository<InvoiceDetail> InvoiceDetailRepo => new InvoiceDetailDAL();
        public static IDetailRepository<RentalDetail> RentalDetailRepo => new RentalDetailDAL();
        public static IDetailRepository<MonthlyRevenueDetail> RevenueDetailRepo => new RevenueDetailDAL();
    }
}
