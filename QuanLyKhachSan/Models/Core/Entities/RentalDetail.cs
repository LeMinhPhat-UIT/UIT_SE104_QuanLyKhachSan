using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class RentalDetail
    {
        public int RentalID { get; set; }
        public int CustomerID { get; set; }
        public bool IsRepresentative { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("RentalID")]
        public Rental Rental { get; set; }
    }
}
