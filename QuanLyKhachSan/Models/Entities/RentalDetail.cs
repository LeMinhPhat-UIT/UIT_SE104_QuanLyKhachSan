using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class RentalDetail
    {
        public int RentalFormID { get; set; }
        public int CustomerID { get; set; }
        public bool IsRepresentative { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("RentalFormID")]
        public Rental RentalForm { get; set; }
    }
}
