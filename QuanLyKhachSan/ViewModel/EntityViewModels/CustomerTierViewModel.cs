using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class CustomerTierViewModel : BaseViewModel
    {
        private int _id;
        private string _name;

        public int ID { get => _id; set { _id = value; OnPropertyChanged(nameof(ID)); } }
        public string CustomerTierName { get => _name; set { _name = value; OnPropertyChanged(nameof(CustomerTierName)); } }

        public CustomerTierViewModel() { }

        public CustomerTierViewModel(CustomerTier customerTier)
        {
            ID = customerTier.CustomerTierID;
            CustomerTierName = customerTier.CustomerTierName;
        }
    }
}
