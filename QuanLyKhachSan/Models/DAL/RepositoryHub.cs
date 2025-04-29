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
    public class RepositoryHub
    {
        public static readonly CustomerDAL CustomerRepo = new CustomerDAL();
        public static readonly CustomerTierDAL CustomerTierRepo = new CustomerTierDAL();
        public static readonly InvoiceDAL InvoiceRepo = new InvoiceDAL();
        public static readonly RentalDAL RentalRepo = new RentalDAL();
        public static readonly RevenueDAL RevenueRepo = new RevenueDAL();
        public static readonly RoomDAL RoomRepo = new RoomDAL();
        public static readonly RoomTierDAL RoomTierRepo = new RoomTierDAL();
        public static readonly UserDAL UserRepo = new UserDAL();
        public static readonly RentalDetailDAL RentalDetailRepo = new RentalDetailDAL();
        public static readonly RevenueDetailDAL RevenueDetailRepo = new RevenueDetailDAL();
    }
}
