using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Commands;

namespace QuanLyKhachSan.ViewModel
{
    public class AddUpdateCustomerViewModel : BaseViewModel
    {
        private CustomerViewModel _customer;
        private ObservableCollection<CustomerTierViewModel> _customerTiers;
        private CustomerTierViewModel _selectedCustomerTier;

        
        public CustomerViewModel Customer { get =>  _customer; set { _customer = value; OnPropertyChanged(nameof(Customer)); } }
        public IEnumerable<CustomerTierViewModel> CustomerTiers => _customerTiers;
        public CustomerTierViewModel SelectedCustomerTier 
        { 
            get => _selectedCustomerTier; 
            set { _selectedCustomerTier = value; OnPropertyChanged(nameof(SelectedCustomerTier)); } 
        }
        public Action? CloseAction { get; set; }


        public ICommand Save { get; }
        public ICommand Close { get; }

        public AddUpdateCustomerViewModel()
        {
            _customerTiers = new ObservableCollection<CustomerTierViewModel>();
            _customer = new CustomerViewModel();    

            var customerTierList = QuanLyKhachSan.Models.BLL.Service.CustomerTierService.GetAllData();
            customerTierList.ForEach(x => _customerTiers.Add(new CustomerTierViewModel(x)));

            Save = new AddUpdateCustomerCommand
            (
                this,
                _ =>
                {
                    var cus = QuanLyKhachSan.Models.BLL.Service.CustomerService.GetByIdentity(Customer.IdentityNumber);
                    if (cus != null)
                        Customer.ID = cus.CustomerID;
                    else
                    {
                        var customer = Customer.ToCustomer();
                        QuanLyKhachSan.Models.BLL.Service.CustomerService.Add(customer);
                        Customer.ID = customer.CustomerID;
                    }
                    CloseAction?.Invoke();
                },
                _ =>
                {
                    if(SelectedCustomerTier != null)
                        Customer.CustomerTierName = SelectedCustomerTier.CustomerTierName;
                    return 
                        !string.IsNullOrEmpty(Customer.CustomerName) && !string.IsNullOrEmpty(Customer.IdentityNumber) && 
                        !string.IsNullOrEmpty(Customer.PhoneNumber) && !string.IsNullOrEmpty(Customer.CustomerTierName);
                }
            );

            Close = new AddUpdateCustomerCommand( this, _ => CloseAction?.Invoke() );
        }
    }
}
