using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class InvoiceDetail
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int DaysStayed { get; set; }

        [Column(TypeName="money")]
        public decimal PricePerDay { get; set; }

        [Column(TypeName="real")]
        public decimal SurchargeRate { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("InvoiceID")]
        public Invoice Invoice { get; set; }
    }
}
