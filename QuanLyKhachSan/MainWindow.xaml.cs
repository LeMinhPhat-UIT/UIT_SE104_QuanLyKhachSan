using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.Models.DAL.Repositories;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // testing area

            HotelDbContext.DropDatabase(); //ok
            HotelDbContext.CreateDatabase(); //ok

            //DALs.StaffRepo.Add(
            //    new Staff()
            //    {
            //        StaffName = "lmp",
            //        IdentityNumber = "000000000000",
            //        Authority = "nv",
            //        EmailAddress = "abcxyz",
            //        PhoneNumber = "0123456789",
            //        Address = "abcxyz"
            //    }
            //);

            //AccountService.Add(
            //    new Account()
            //    {
            //        StaffID = 1,
            //        AccountName = "lmp",
            //        Password = "password"
            //    }    
            //);

            //AccountService.Login(1, "password");

            List<string> CustomerTierNameList = new List<string> { "silver", "gold", "diamond" };
            CustomerTierNameList
                .ForEach(x => Service.CustomerTierService.Add(new CustomerTier { CustomerTierName = x }));

            List<Customer> CustomerList = new List<Customer>
            {
                new Customer
                {
                    CustomerName = "A",
                    IdentityNumber = "000000000000",
                    CustomerAddress = "abc",
                    PhoneNumber = "0123456789",
                    CustomerTierID = 1,
                },
                new Customer
                {
                    CustomerName = "B",
                    IdentityNumber = "000000000001",
                    CustomerAddress = "abc",
                    PhoneNumber = "0123456789",
                    CustomerTierID = 1,
                },
                new Customer
                {
                    CustomerName = "C",
                    IdentityNumber = "000000000002",
                    CustomerAddress = "abc",
                    PhoneNumber = "0123456789",
                    CustomerTierID = 2,
                },
                new Customer
                {
                    CustomerName = "D",
                    IdentityNumber = "000000000003",
                    CustomerAddress = "abc",
                    PhoneNumber = "0123456789",
                    CustomerTierID = 3,
                }
            };
            CustomerList
                .ForEach(x => Service.CustomerService.Add(x));

            List<User> UserList = new List<User>
            {
                new User
                {
                    IdentityNumber = "000000000000",
                    UserName = "NhanVienA",
                    Password = "1",
                    Role = "NhanVien",
                    EmailAddress = "abc@gmail.com",
                    PhoneNumber = "0123456789",
                    Address = "xyz",
                },
                new User
                {
                    IdentityNumber = "000000000001",
                    UserName = "NhanVienB",
                    Password = "2",
                    Role = "NhanVien",
                    EmailAddress = "abc@gmail.com",
                    PhoneNumber = "0123456789",
                    Address = "xyz",
                },
            };
            UserList
                .ForEach(x => Service.UserService.Add(x));



            //var test = new CustomerService();
            //var list = test.GetCustomerTier(3);
            //MessageBox.Show(list.CustomerTierName.ToString());
        }
    }
}