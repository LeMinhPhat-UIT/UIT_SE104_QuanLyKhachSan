using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Reservation_Customer
    {
        public int ReservationID { get; set; }
        public int CustomerID { get; set; }
        public bool IsRepresentative { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }
    }
}
