using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public int? UserID { get; set; }
        public int RoomID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime CheckOutDate { get; set; }

        [StringLength(20)]
        [Column(TypeName="varchar")]
        public string Status { get; set; }
        public int CustomersCount { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        //public List<Reservation_Customer> RentalDetails { get; set; }
        public Invoice Invoice { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public Reservation() { }
        public Reservation(int userID, int roomID, DateTime checkInDate, DateTime checkOutDate, string status)
        {
            UserID = userID;
            RoomID = roomID;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = status;
        }
    }
}
