using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class CustomerTierViewModel
    {
        public int ID { get; }
        public string CustomerTierName { get; }

        public CustomerTierViewModel(CustomerTier customerTier)
        {
            ID = customerTier.CustomerTierID;
            CustomerTierName = customerTier.CustomerTierName;
        }
    }
}
