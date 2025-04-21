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
using QuanLyKhachSan.Models.BLL.Services;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.Models.DAL.Repositories;

namespace QuanLyKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int cnt=0;
        public MainWindow()
        {
            InitializeComponent();

            // testing

            HotelDbContext.DropDatabase();
            HotelDbContext.CreateDatabase();

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

            DALs.CustomerTierRepo.Add(new CustomerTier { CustomerTierName = "vip" });

            DALs.CustomerRepo.Add(new Customer
            {
                CustomerName = "lmp1",
                IdentityNumber = "000000000000",
                CustomerAddress = "htp",
                CustomerPhoneNumber = "0123456789",
                CustomerTierID = 1,
            });
            DALs.CustomerRepo.Add(new Customer
            {
                CustomerName = "lmp2",
                IdentityNumber = "000000000001",
                CustomerAddress = "htp",
                CustomerPhoneNumber = "0123456789",
                CustomerTierID = 1,
            });
        }
    }
}