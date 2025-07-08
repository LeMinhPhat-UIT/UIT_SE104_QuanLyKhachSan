using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

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
                if (_customer != null)
                    _customer.PropertyChanged -= Customer_PropertyChanged;

                _customer = value;

                if (_customer != null)
                    _customer.PropertyChanged += Customer_PropertyChanged;

                OnPropertyChanged(nameof(Customer));
            }
        }

        public IEnumerable<CustomerTierViewModel> CustomerTiers => _customerTiers;
        public IEnumerable<CustomerViewModel> Suggestions => _suggestions;

        public CustomerTierViewModel SelectedCustomerTier
        {
            get => _selectedCustomerTier;
            set
            {
                _selectedCustomerTier = value;
                OnPropertyChanged(nameof(SelectedCustomerTier));
            }
        }

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));

                // Không autofill ở đây
                // Chỉ hiển thị gợi ý thôi, không làm gì thêm
            }
        }

        public Action? CloseAction { get; set; }

        public ICommand Save { get; }
        public ICommand Close { get; }

        private bool _isAutofilled = false;

        public AddUpdateCustomerViewModel()
        {
            _customerTiers = new ObservableCollection<CustomerTierViewModel>();
            _suggestions = new ObservableCollection<CustomerViewModel>();
            _customer = new CustomerViewModel();
            _selectedCustomer = new CustomerViewModel();

            // Gắn sự kiện theo dõi thay đổi trong IdentityNumber
            _customer.PropertyChanged += Customer_PropertyChanged;

            // Load data
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
                    {
                        Customer.ID = cus.CustomerID;
                    }
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
                    if (SelectedCustomerTier != null)
                        Customer.CustomerTierName = SelectedCustomerTier.CustomerTierName;

                    // Kiểm tra CCCD: 12 chữ số
                    bool isValidCCCD = !string.IsNullOrEmpty(Customer.IdentityNumber) &&
                                       Customer.IdentityNumber.Length == 12 &&
                                       Customer.IdentityNumber.All(char.IsDigit);

                    // Kiểm tra SĐT: 10 chữ số
                    bool isValidPhone = !string.IsNullOrEmpty(Customer.PhoneNumber) &&
                                        Customer.PhoneNumber.Length == 10 &&
                                        Customer.PhoneNumber.All(char.IsDigit);

                    return
                        !string.IsNullOrEmpty(Customer.CustomerName) &&
                        !string.IsNullOrEmpty(Customer.IdentityNumber) &&
                        !string.IsNullOrEmpty(Customer.PhoneNumber) &&
                        !string.IsNullOrEmpty(Customer.CustomerTierName) &&
                        isValidCCCD &&
                        isValidPhone;
                }
            );

            Close = new AddUpdateCustomerCommand(this, _ => CloseAction?.Invoke());
        }

        private void Customer_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Customer.IdentityNumber))
            {
                var cccd = Customer.IdentityNumber;

                // Chỉ autofill khi nhập đủ 12 số
                if (!string.IsNullOrEmpty(cccd) && cccd.Length == 12)
                {
                    var matched = _suggestions.FirstOrDefault(c => c.IdentityNumber == cccd);
                    if (matched != null)
                    {
                        _isAutofilled = true;

                        Customer.CustomerName = matched.CustomerName;
                        Customer.PhoneNumber = matched.PhoneNumber;
                        Customer.CustomerTierName = matched.CustomerTierName;
                        SelectedCustomerTier = _customerTiers.FirstOrDefault(t => t.CustomerTierName == matched.CustomerTierName);
                        return; // thoát sớm nếu tìm thấy
                    }
                }

                // Nếu không tìm thấy CCCD hợp lệ hoặc chưa đủ 12 số → xoá dữ liệu autofill
                if (_isAutofilled)
                {
                    Customer.CustomerName = string.Empty;
                    Customer.PhoneNumber = string.Empty;
                    Customer.CustomerTierName = string.Empty;
                    SelectedCustomerTier = null;
                }
            }
        }
    }
}
