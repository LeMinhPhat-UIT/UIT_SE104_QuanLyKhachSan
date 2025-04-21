using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class RoomTier
    {
        [Key]
        public int RoomTierID { get; set; }

        [Column(TypeName="nvarchar")]
        public string RoomTierName { get; set; }

        [Column(TypeName="money")]
        public decimal RoomTierPrice { get; set; }
        public List<RoomTier> Rooms { get; set; }
        public List<MonthlyRevenueDetail> RevenueDetails { get; set; }
    }
}
