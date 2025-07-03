using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class RuleViewModel : BaseViewModel
    {
        private int _id;
        private int _roomMaxCustomer;
        private int _surchargeRate;
        private int _customerToApplySurchargeRate;

        public int ID { get => _id; set { _id = value;OnPropertyChanged(nameof(ID)); } }
        public int RoomMaxCustomer { get => _roomMaxCustomer; set { _roomMaxCustomer = value;OnPropertyChanged(nameof(RoomMaxCustomer)); } }
        public int SurchargeRate { get => _surchargeRate; set { _surchargeRate = value;OnPropertyChanged(nameof(SurchargeRate)); } }
        public int CustomerToApplySurchargeRate { get => _customerToApplySurchargeRate; set { _customerToApplySurchargeRate = value; OnPropertyChanged(nameof(CustomerToApplySurchargeRate)); } }

        public RuleViewModel(Rule rule)
        {
            ID = rule.RuleID;
            RoomMaxCustomer = rule.RoomMaxCustomer;
            SurchargeRate = rule.SurchargeRate;
            CustomerToApplySurchargeRate = rule.CustomerToApplySurchargeRate;
        }
    }
}
