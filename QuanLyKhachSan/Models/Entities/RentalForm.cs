using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class RentalForm
    {
        [Key]
        public int RentalFormID { get; set; }
        public int? StaffID { get; set; }
        public int RoomID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime RentalDate { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime ReturnDate { get; set; }

        [ForeignKey("RoomID")]
        public RoomTier Room { get; set; }

        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }
        public List<RentalDetail> RentalDetails { get; set; }
        public Invoice Invoice { get; set; }
    }
}
