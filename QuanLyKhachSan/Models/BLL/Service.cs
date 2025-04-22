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
        public static CustomerService CustomerRepo => new CustomerService();
        public static CustomerTierService CustomerTierRepo => new CustomerTierService();
        public static InvoiceService InvoiceRepo => new InvoiceService();
        public static RentalService RentalRepo => new RentalService();
        public static RevenueService RevenueRepo => new RevenueService();
        public static RoomService RoomRepo => new RoomService();
        public static RoomTierService RoomTierRepo => new RoomTierService();
        public static UserService UserRepo => new UserService();
        public static RentalDetailService RentalDetailRepo => new RentalDetailService();
        public static RevenueDetailService RevenueDetailRepo => new RevenueDetailService();
    }
}
