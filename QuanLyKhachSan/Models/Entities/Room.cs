using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int? RoomTierID { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string RoomNumber { get; set; }

        [Column(TypeName="money")]
        public decimal PricePerDay { get; set; }
        public int Capacity { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string RoomState { get; set; }
        public List<Rental> Rentals { get; set; }

        [ForeignKey("RoomTierID")]
        public RoomTier RoomTier { get; set; }
    }
}
