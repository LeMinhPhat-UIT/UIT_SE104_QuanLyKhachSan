using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class RevenueReport
    {
        [Key]
        public int ReportID {  get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime ReportDate { get; set; }

        public int UserID { get; set; }
        public int RoomTierID { get; set; }

        [Column(TypeName="money")]
        public decimal TotalRevenue { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("RoomTierID")]
        public RoomTier RoomTier { get; set; }
        public List<RevenueDetail> RevenueDetails { get; set; }
    }
}
