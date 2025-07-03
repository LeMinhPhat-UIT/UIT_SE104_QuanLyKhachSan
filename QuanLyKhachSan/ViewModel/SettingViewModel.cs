using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel
{
    public class RuleDisplayItem : BaseViewModel
    {
        private string _header;
        private string _value;

        public string Header { get => _header; set { _header = value; OnPropertyChanged(nameof(Header)); } }
        public string Value 
        { 
            get => _value; 
            set 
            { 
                _value = value; 
                OnPropertyChanged(nameof(Value)); 
            } 
        }
    }
    public class SettingViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserViewModel _userViewModel;
        private readonly SidebarCommand _sidebarCommand;
        public ObservableCollection<RoomTierViewModel> _roomTiers;
        private ObservableCollection<CustomerTierViewModel> _customerTiers;
        private ObservableCollection<RuleDisplayItem> _ruleDisplayItems;
        private RuleViewModel _rule;
        private RoomTierViewModel _selectedRoomTier;
        private CustomerTierViewModel _selectedCustomerTier;

        public IEnumerable<RoomTierViewModel> RoomTiers => _roomTiers;
        public IEnumerable<CustomerTierViewModel> CustomerTiers => _customerTiers;
        public IEnumerable<RuleDisplayItem> RuleDisplayItems => _ruleDisplayItems;
        public RuleViewModel Rule 
        {
            get => _rule;
            set 
            {  
                _rule = value; 
                OnPropertyChanged(nameof(Rule)); 
                UpdateRule();
            } 
        }
        public RoomTierViewModel SelectedRoomTier { get => _selectedRoomTier; set { _selectedRoomTier = value; OnPropertyChanged(nameof(SelectedRoomTier)); } }
        public CustomerTierViewModel SelectedCustomerTier { get => _selectedCustomerTier; set { _selectedCustomerTier = value; OnPropertyChanged(nameof(SelectedCustomerTier)); } }
        public SidebarCommand SidebarCommand => _sidebarCommand;
        public UserViewModel User => _userViewModel;
        public ICommand DeleteCustomerTier { get; }
        public ICommand DeleteRoomTier { get; }

        public SettingViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _userViewModel = navigationStore.User;
            _sidebarCommand = new SidebarCommand(navigationStore);
            _roomTiers = new ObservableCollection<RoomTierViewModel>();
            _customerTiers = new ObservableCollection<CustomerTierViewModel>();

            QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetAllData().ForEach(x => _roomTiers.Add(new RoomTierViewModel(x)));
            QuanLyKhachSan.Models.BLL.Service.CustomerTierService.GetAllData().ForEach(x => _customerTiers.Add(new CustomerTierViewModel(x)));
            _rule = new RuleViewModel(QuanLyKhachSan.Models.BLL.Service.RuleService.GetById(1));
            _ruleDisplayItems = new ObservableCollection<RuleDisplayItem>()
            {
                new RuleDisplayItem {Header="Khách tối đa/phòng", Value=_rule.RoomMaxCustomer.ToString()},
                new RuleDisplayItem {Header="Tỷ lệ phụ thu", Value=_rule.SurchargeRate.ToString()},
                new RuleDisplayItem {Header="Áp dụng từ khách thứ", Value=_rule.CustomerToApplySurchargeRate.ToString()},
            };
            foreach(var item in _ruleDisplayItems)
                item.PropertyChanged += RuleDisplayItem_PropertyChanged;

            DeleteCustomerTier = new SettingCommand(this, param => RemoveCustomerTier(param as CustomerTierViewModel));
            DeleteRoomTier = new SettingCommand(this, param => RemoveRoomTier(param as RoomTierViewModel));
        }

        private void RemoveCustomerTier(CustomerTierViewModel item)
        {
            if (item is CustomerTierViewModel vm)
            {
                QuanLyKhachSan.Models.BLL.Service.CustomerTierService.Delete(vm.ID);
                if (QuanLyKhachSan.Models.BLL.Service.CustomerTierService.GetById(vm.ID) == null)
                    _customerTiers.Remove(vm);
            }
        }

        private void RemoveRoomTier(RoomTierViewModel item)
        {
            if (item is RoomTierViewModel vm)
            {
                QuanLyKhachSan.Models.BLL.Service.RoomTierService.Delete(vm.ID);
                if(QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetById(vm.ID)==null)
                    _roomTiers.Remove(vm);
            }
        }

        public void RemoveInvalidRoomTier(RoomTierViewModel item)
        {
            if (_roomTiers.Contains(item))
                _roomTiers.Remove(item);
        }

        public void RemoveInvalidCustomerTier(CustomerTierViewModel item)
        {
            if (_customerTiers.Contains(item))
                _customerTiers.Remove(item);
        }

        private void RuleDisplayItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RuleDisplayItem.Value))
            {
                var item = sender as RuleDisplayItem;
                if (item == null) return;

                switch (item.Header)
                {
                    case "Khách tối đa/phòng":
                        if (int.TryParse(item.Value, out int maxCustomer))
                            _rule.RoomMaxCustomer = maxCustomer;
                        break;
                    case "Tỷ lệ phụ thu":
                        if (int.TryParse(item.Value, out int surchargeRate))
                            _rule.SurchargeRate = surchargeRate;
                        break;
                    case "Áp dụng từ khách thứ":
                        if (int.TryParse(item.Value, out int customerToApply))
                            _rule.CustomerToApplySurchargeRate = customerToApply;
                        break;
                }

                UpdateRule();
            }
        }

        private void UpdateRule()
        {
            Rule rule = new Rule()
            {
                RuleID = _rule.ID,
                RoomMaxCustomer = _rule.RoomMaxCustomer,
                SurchargeRate = _rule.SurchargeRate,
                CustomerToApplySurchargeRate = _rule.CustomerToApplySurchargeRate,
            };
            QuanLyKhachSan.Models.BLL.Service.RuleService.Update(rule);
        }
    }
}
