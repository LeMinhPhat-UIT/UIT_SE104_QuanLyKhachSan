using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EntityFramework;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.BLL.Helpers.ReportHelpers;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.Core.Others;

namespace QuanLyKhachSan.Models
{
    public class Testing
    {
        public static void AddData()
        {
            HotelDbContext.DropDatabase();
            HotelDbContext.CreateDatabase();

            //Thêm CustomerTier
            var CustomerTierList = new List<CustomerTier>
            {
                new CustomerTier { CustomerTierName = "cooper" },
                new CustomerTier { CustomerTierName = "silver"},
                new CustomerTier { CustomerTierName = "gold" },
                new CustomerTier { CustomerTierName = "platium"},
                new CustomerTier { CustomerTierName = "diamond" },
            };
            CustomerTierList.ForEach(x => Service.CustomerTierService.Add(x));

            //Thêm Customer
            var CustomerList=new List<Customer>
            {
                new Customer 
                    {CustomerTierID=1, CustomerName="Nguyen Van A", Sex=true, IdentityNumber="000000000000", 
                     CustomerAddress=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString(),
                     PhoneNumber="0123456789"},
                new Customer
                    {CustomerTierID=1, CustomerName="Nguyen Van B", Sex=true, IdentityNumber="000000000001",
                     CustomerAddress=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString(),
                     PhoneNumber="0123456789"},
                new Customer
                    {CustomerTierID=2, CustomerName="Nguyen Van C", Sex=true, IdentityNumber="000000000002",
                     CustomerAddress=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString(),
                     PhoneNumber="0123456789"},
                new Customer
                    {CustomerTierID=4, CustomerName="Nguyen Van D", Sex=true, IdentityNumber="000000000003",
                     CustomerAddress=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString(),
                     PhoneNumber="0123456789"},
                new Customer
                    {CustomerTierID=3, CustomerName="Nguyen Van E", Sex=true, IdentityNumber="000000000004",
                     CustomerAddress=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString(),
                     PhoneNumber="0123456789"},
            };
            CustomerList.ForEach(x => Service.CustomerService.Add(x));

            //Thêm Amenity
            var AmenityList=new List<Amenity>
            {
                new Amenity{AmenityName="Bed"},
                new Amenity{AmenityName="Bathtub"},
                new Amenity{AmenityName="TV"},
                new Amenity{AmenityName="Air Conditioner"},
                new Amenity{AmenityName="Refrigerator"},
                new Amenity{AmenityName="Wifi"},
                new Amenity{AmenityName="Love Chair"},
            };
            AmenityList.ForEach(x => Service.AmenityService.Add(x));

            //Thêm RoomTier
            var RoomTierList=new List<RoomTier>
            {
                new RoomTier{RoomTierName="standard", RoomTierPrice=100000},
                new RoomTier{RoomTierName="vip", RoomTierPrice=150000},
                new RoomTier{RoomTierName="vipXPro", RoomTierPrice=200000},
            };
            RoomTierList.ForEach(x => Service.RoomTierService.Add(x));

            //Thêm Room
            var RoomList = new List<Room>
            {
                new Room{RoomTierID=1, RoomNumber="P101", PricePerDay=100000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=1, RoomNumber="P102", PricePerDay=100000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=1, RoomNumber="P103", PricePerDay=100000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=2, RoomNumber="P201", PricePerDay=200000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=2, RoomNumber="P202", PricePerDay=250000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=2, RoomNumber="P203", PricePerDay=200000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=2, RoomNumber="P204", PricePerDay=300000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=2, RoomNumber="P205", PricePerDay=350000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=3, RoomNumber="P301", PricePerDay=1000000, Capacity=2, RoomState="Available"},
                new Room{RoomTierID=3, RoomNumber="P302", PricePerDay=2000000, Capacity=2, RoomState="Available"},
            };
            var AmenitiesOfRoom = new List<int> { 1, 2, 3, 4 };
            RoomList.ForEach(x =>
            {
                Service.RoomService.Add(x);
                AmenitiesOfRoom.ForEach(y =>
                    Service.RoomService.AddAmenity(x.RoomID, y)
                );
            });

            var UserList = new List<User>
            {
                new User{UserName="Tran Van A", Password="1", Sex=false, Role="Admin", 
                         EmailAddress="tranvana@gmail.com", PhoneNumber="0123456789", 
                         IdentityNumber="000000000000",
                         Address=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString()
                        },
                new User{UserName="Tran Van B", Password="1", Sex=false, Role="Admin", 
                         EmailAddress="tranvanb@gmail.com", PhoneNumber="0123456789", 
                         IdentityNumber="000000000001",
                         Address=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString()
                        },
                new User{UserName="Tran Van C", Password="1", Sex=false, Role="Admin", 
                         EmailAddress="tranvanc@gmail.com", PhoneNumber="0123456789", 
                         IdentityNumber="000000000002",
                         Address=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString()
                        },
                new User{UserName="Tran Van D", Password="1", Sex=false, Role="Admin", 
                         EmailAddress="tranvand@gmail.com", PhoneNumber="0123456789", 
                         IdentityNumber="000000000004",
                         Address=new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString()
                        },
            };
            UserList.ForEach(x => Service.UserService.Add(x));

            var ReservationList=new List<Reservation>
            {
                new Reservation{UserID=1, RoomID=1, CustomerID=1, Status="Pending",
                                CheckInDate=new DateTime(2025, 5, 1), CheckOutDate=new DateTime(2025, 5, 3),
                               },
                new Reservation{UserID=1, RoomID=2, CustomerID=2, Status="Pending",
                                CheckInDate=new DateTime(2025, 5, 1), CheckOutDate=new DateTime(2025, 5, 3),
                               },
            };
            ReservationList.ForEach(x =>
            {
                Service.ReservationService.Add(x);
                Service.ReservationService.AddCustomer(x.ReservationID, x.CustomerID+2);
            });

            var InvoiceList = new List<Invoice>
            {
                new Invoice{ReservationID=1, UserID=1, InvoiceDate=DateTime.Now, SurchargeRate=10, TotalAmount=220000, PaymentMethod="Cash"},
                new Invoice{ReservationID=2, UserID=3, InvoiceDate=DateTime.Now, SurchargeRate=0, TotalAmount=200000, PaymentMethod="Credit Card"},
            };
            InvoiceList.ForEach(x => Service.InvoiceService.Add(x));

            ReportHelper.GenerateReport(1, 1, DateTime.Now);
        }

        public static void UpdateData()
        {
            Service.CustomerTierService.Update(new CustomerTier
            {
                CustomerTierID = 2,
                CustomerTierName = "updated customer tier"
            });
            
            Service.CustomerService.Update(new Customer
            {
                CustomerID = 1,
                CustomerTierID = 2,
                CustomerName = "Pham Quang A",
                PhoneNumber="0000000000",
                Sex = true,
                IdentityNumber = "000000000000",
                CustomerAddress = new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString()
            });

            Service.AmenityService.Update(new Amenity
            {
                AmenityID=1,
                AmenityName="Super Bed",
            });

            Service.UserService.Update(new User
            {
                UserID = 1,
                UserName = "Pham Quang B",
                Password = "1",
                Sex = true,
                Role = "Admin",
                EmailAddress = "tranvana@gmail.com",
                PhoneNumber = "0123456789",
                IdentityNumber = "000000000000",
                Address = new Address("123/abc", "abc", "abc", CommueType.Ward, "abc", DistrictType.UrbanDistrict, "Hồ Chí Minh", ProvinceType.Municipality).ToString()
            });
        }

        public static void DeleteData()
        {
            Service.RoomService.DeleteAmenity(1, 1);
            Service.ReservationService.DeleteCustomer(1, 1);
            Service.RevenueService.DeleteInvoice(1, 1);

            Service.CustomerTierService.Delete(1);
            //Service.CustomerService.Delete(1); //không hiểu sao dòng này để đây thì lỗi mà đem nó sang MainWindow.xaml.cs thì lại chạy đúng. Chung quy là nó chạy đúng
            Service.AmenityService.Delete(2);
            Service.RoomService.Delete(3);
            Service.UserService.Delete(2);
            Service.ReservationService.Delete(1);
            Service.RevenueService.Delete(1);
        }
    }
}
