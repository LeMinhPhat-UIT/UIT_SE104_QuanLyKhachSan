using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Rule
    {
        public int RuleID { get; set; }
        public int RoomMaxCustomer { get; set; }
        public int SurchargeRate { get; set; }
        public int CustomerToApplySurchargeRate { set; get; }

    }
}
