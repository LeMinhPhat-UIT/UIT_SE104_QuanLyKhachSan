using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.BLL.Services;
using QuanLyKhachSan.Models.DAL.Repositories;

namespace QuanLyKhachSan.Models.BLL
{
    internal class Service
    {
        public static readonly AmenityService AmenityService = new AmenityService();
        public static readonly CustomerService CustomerService = new CustomerService();
        public static readonly CustomerTierService CustomerTierService = new CustomerTierService();
        public static readonly InvoiceService InvoiceService = new InvoiceService();
        public static readonly ReservationService ReservationService = new ReservationService();
        public static readonly RevenueService RevenueService = new RevenueService();
        public static readonly RoleService RoleService = new RoleService();
        public static readonly RoomService RoomService = new RoomService();
        public static readonly RoomTierService RoomTierService = new RoomTierService();
        public static readonly UserService UserService = new UserService();
        //public static Reservation_CustomerService Reservation_CustomerService => new Reservation_CustomerService();
        //public static Revenue_InvoiceService Revenue_InvoiceService => new Revenue_InvoiceService();
    }
}
