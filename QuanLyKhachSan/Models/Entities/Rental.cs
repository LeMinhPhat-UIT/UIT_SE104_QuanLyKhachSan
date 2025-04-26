using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Rental
    {
        [Key]
        public int RentalID { get; set; }
        public int? UserID { get; set; }
        public int RoomID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime CheckOutDate { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        public List<RentalDetail> RentalDetails { get; set; }
        public Invoice Invoice { get; set; }
    }
}
