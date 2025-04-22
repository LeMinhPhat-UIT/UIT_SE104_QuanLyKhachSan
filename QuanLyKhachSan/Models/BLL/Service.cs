using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.BLL.Services;
using QuanLyKhachSan.Models.DAL.Repositories;

namespace QuanLyKhachSan.Models.BLL
{
    public class Service
    {
        public static CustomerService CustomerService => new CustomerService();
        public static CustomerTierService CustomerTierService => new CustomerTierService();
        public static InvoiceService InvoiceService => new InvoiceService();
        public static RentalService RentalService => new RentalService();
        public static RevenueService RevenueService => new RevenueService();
        public static RoomService RoomService => new RoomService();
        public static RoomTierService RoomTierService => new RoomTierService();
        public static UserService UserService => new UserService();
        public static RentalDetailService RentalDetailService => new RentalDetailService();
        public static RevenueDetailService RevenueDetailService => new RevenueDetailService();
    }
}
