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
    internal class RepositoryHub
    {
        public static readonly AmenityDAL AmenityRepo = new AmenityDAL();
        public static readonly CustomerDAL CustomerRepo = new CustomerDAL();
        public static readonly CustomerTierDAL CustomerTierRepo = new CustomerTierDAL();
        public static readonly InvoiceDAL InvoiceRepo = new InvoiceDAL();
        public static readonly ReservationDAL ReservationRepo = new ReservationDAL();
        public static readonly RevenueDAL RevenueRepo = new RevenueDAL();
        public static readonly RoleDAL RoleRepo = new RoleDAL();
        public static readonly RoomDAL RoomRepo = new RoomDAL();
        public static readonly RoomTierDAL RoomTierRepo = new RoomTierDAL();
        public static readonly UserDAL UserRepo = new UserDAL();
        public static readonly RuleDAL RuleRepo = new RuleDAL();
        //public static readonly Reservation_CustomerDAL RentalDetailRepo = new Reservation_CustomerDAL();
        //public static readonly Revenue_InvoiceDAL RevenueDetailRepo = new Revenue_InvoiceDAL();
    }
}
