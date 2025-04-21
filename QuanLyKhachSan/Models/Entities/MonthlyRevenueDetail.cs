using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class MonthlyRevenueDetail
    {
        [ForeignKey("ReportMonth")]
        [Column(TypeName="smalldatetime")]
        public DateTime ReportMonth { get; set; }

        [ForeignKey("RoomTierID")]
        public int RoomTierID { get; set; }

        [Column(TypeName="real")]
        public decimal RevenueRate { get; set; }
        public MonthlyRevenueReport Report { get; set; }
        public RoomTier RoomTier { get; set; }
    } 
}
