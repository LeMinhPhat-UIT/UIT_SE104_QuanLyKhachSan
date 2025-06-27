using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
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
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<RevenueReport> RevenueReports { get; set; } = new List<RevenueReport>();
        public int CountRooms { get => Rooms.Count; }
        public RoomTier() { }
        public RoomTier(string roomTierName, decimal roomTierPrice)
        {
            RoomTierName = roomTierName;
            RoomTierPrice = roomTierPrice;
        }
    }
}
