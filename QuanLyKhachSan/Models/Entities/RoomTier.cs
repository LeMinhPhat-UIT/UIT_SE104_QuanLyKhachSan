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

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string RoomTierName { get; set; }

        [Column(TypeName="money")]
        public decimal RoomTierPrice { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RevenueReport> RevenueReports { get; set; }
    }
}
