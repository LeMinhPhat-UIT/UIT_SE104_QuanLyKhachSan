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
        public static void GenerateData()
        {
            HotelDbContext.DropDatabase();
            HotelDbContext.CreateDatabase();

            var RoleList = new List<Role>
            {
                new Role("Administrator"),
                new Role("Employee")
            };
            RoleList.ForEach(x => Service.RoleService.Add(x));

            var UserList = new List<User>
            {
                new User{UserName="Lê Quý Bình", Password="password123", RoleID=1, WorkingDate=new DateTime(2020, 1, 1),
                         EmailAddress="lequyb@hotel.vn", PhoneNumber="0987654321", IdentityNumber="100000000001"},

                new User{UserName="Ngô Thanh Hằng", Password="password123", RoleID=1, WorkingDate=new DateTime(2020, 1, 15),
                         EmailAddress="ngothanhh@hotel.vn", PhoneNumber="0987654322", IdentityNumber="100000000002"},

                new User{UserName="Đặng Văn Khoa", Password="password123", RoleID=2, WorkingDate=new DateTime(2021, 1, 2),
                         EmailAddress="dangvank@hotel.vn", PhoneNumber="0987654323", IdentityNumber="100000000003"},

                new User{UserName="Trần Thị Mai", Password="password123", RoleID=2, WorkingDate=new DateTime(2021, 10, 3),
                         EmailAddress="tranthim@hotel.vn", PhoneNumber="0987654324", IdentityNumber="100000000004"},

                new User{UserName="Phan Thanh Tú", Password="password123", RoleID=2, WorkingDate=new DateTime(2022, 5, 4),
                         EmailAddress="phathant@hotel.vn", PhoneNumber="0987654325", IdentityNumber="100000000005"},

                new User{UserName="Võ Ngọc An", Password="password123", RoleID=2, WorkingDate=new DateTime(2022, 5, 20),
                         EmailAddress="vongoca@hotel.vn", PhoneNumber="0987654326", IdentityNumber="100000000006"},

                new User{UserName="Bùi Minh Nhật", Password="password123", RoleID=2, WorkingDate=new DateTime(2023, 1, 6),
                         EmailAddress="buiminnh@hotel.vn", PhoneNumber="0987654327", IdentityNumber="100000000007"},

                new User{UserName="Hồ Thị Kim", Password="password123", RoleID=2, WorkingDate=new DateTime(2023, 7, 15),
                         EmailAddress="hothik@hotel.vn", PhoneNumber="0987654328", IdentityNumber="100000000008"},

                new User{UserName="Tạ Đình Phong", Password="password123", RoleID=2, WorkingDate=new DateTime(2024, 1, 8),
                         EmailAddress="tadinph@hotel.vn", PhoneNumber="0987654329", IdentityNumber="100000000009"},

                new User{UserName="Dương Cẩm Tú", Password="password123", RoleID=2, WorkingDate=new DateTime(2024, 10, 9),
                         EmailAddress="duongcamt@hotel.vn", PhoneNumber="0987654330", IdentityNumber="100000000010"},
            };

            UserList.ForEach(x => Service.UserService.Add(x));
        }
    }
}
