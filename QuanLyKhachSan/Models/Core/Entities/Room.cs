using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int? RoomTierID { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string RoomNumber { get; set; }

        //[Column(TypeName="money")]
        //public decimal PricePerDay { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string RoomState { get; set; }

        [ForeignKey("RoomTierID")]
        public RoomTier RoomTier { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Amenity> Amenities { get; set; } = new List<Amenity>();
        public string GetAmenitiesByName 
        { 
            get => string.Join(", ", Amenities.Select(x => x.AmenityName));
        }
        public Room() { }
        public Room(int roomTierID, string roomNumber, string roomState)
        {
            RoomTierID = roomTierID;
            RoomNumber = roomNumber;
            RoomState = roomState;
        }
    }
}
