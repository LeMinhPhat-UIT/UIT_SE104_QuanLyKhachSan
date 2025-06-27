using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        private int _id;
        private string _name;
        private string _identity;
        private string _phone;
        private string _tier;

        public int ID { get => _id; set { _id = value; OnPropertyChanged(nameof(ID)); } }
        public string CustomerName { get => _name; set { _name = value; OnPropertyChanged(nameof(CustomerName)); } }
        public string IdentityNumber { get => _identity; set { _identity = value; OnPropertyChanged(nameof(IdentityNumber)); } }
        public string PhoneNumber { get => _phone; set { _phone = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public string CustomerTierName { get => _tier; set { _tier = value; OnPropertyChanged(nameof(CustomerTierName)); } }

        public CustomerViewModel() { }
        public CustomerViewModel(Customer customer)
        {
            ID = customer.CustomerID;
            CustomerName = customer.CustomerName;
            IdentityNumber = customer.IdentityNumber;
            PhoneNumber = customer.PhoneNumber;
            CustomerTierName = QuanLyKhachSan.Models.BLL.Service.CustomerService.GetCustomerTier(customer.CustomerID).CustomerTierName;
        }

        public Customer ToCustomer()
        {
            return new Customer()
            {
                CustomerName = CustomerName,
                IdentityNumber = IdentityNumber,
                PhoneNumber = PhoneNumber,
                CustomerTierID = QuanLyKhachSan.Models.BLL.Service.CustomerTierService.GetAllData().First(x => x.CustomerTierName == CustomerTierName).CustomerTierID,
            };
        }
    }
}
