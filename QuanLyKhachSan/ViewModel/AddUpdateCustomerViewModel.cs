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
using System.Windows;
using System.Security.Policy;

namespace QuanLyKhachSan.ViewModel
{
    public class AddUpdateCustomerViewModel : BaseViewModel
    {
        private CustomerViewModel _customer;
        private ObservableCollection<CustomerTierViewModel> _customerTiers;
        private CustomerTierViewModel _selectedCustomerTier;
        private ObservableCollection<CustomerViewModel> _suggestions;
        private CustomerViewModel _selectedCustomer;

        
        public CustomerViewModel Customer 
        { 
            get => _customer; 
            set 
            {
                _customer = value; 
                OnPropertyChanged(nameof(Customer));
            } 
        }
        public IEnumerable<CustomerTierViewModel> CustomerTiers => _customerTiers;
        public IEnumerable<CustomerViewModel> Suggestions => _suggestions;
        public CustomerTierViewModel SelectedCustomerTier 
        { 
            get => _selectedCustomerTier; 
            set { _selectedCustomerTier = value; OnPropertyChanged(nameof(SelectedCustomerTier)); } 
        }
        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                if (_selectedCustomer != null)
                {
                    Customer.IdentityNumber = _selectedCustomer.IdentityNumber;
                    Customer.CustomerName = _selectedCustomer.CustomerName;
                    Customer.PhoneNumber = _selectedCustomer.PhoneNumber;
                    Customer.CustomerTierName = _selectedCustomer.CustomerTierName;
                }
            }
        }
        public Action? CloseAction { get; set; }


        public ICommand Save { get; }
        public ICommand Close { get; }

        public AddUpdateCustomerViewModel()
        {
            _customerTiers = new ObservableCollection<CustomerTierViewModel>();
            _suggestions = new ObservableCollection<CustomerViewModel>();
            _customer = new CustomerViewModel();
            _selectedCustomer = new CustomerViewModel();

            var customerTierList = QuanLyKhachSan.Models.BLL.Service.CustomerTierService.GetAllData();
            customerTierList.ForEach(x => _customerTiers.Add(new CustomerTierViewModel(x)));

            QuanLyKhachSan.Models.BLL.Service.CustomerService.GetAllData().ForEach(x => _suggestions.Add(new CustomerViewModel(x)));

            Save = new AddUpdateCustomerCommand
            (
                this,
                _ =>
                {
                    var cus = QuanLyKhachSan.Models.BLL.Service.CustomerService.GetByIdentity(Customer.IdentityNumber);
                    if (cus != null)
                        Customer = new CustomerViewModel(cus);
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
