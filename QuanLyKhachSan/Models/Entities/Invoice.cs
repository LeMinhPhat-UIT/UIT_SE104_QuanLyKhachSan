using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [ForeignKey("RentalForm")]
        public int RentalFormID { get; set; }
        public int? StaffID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName="money")]
        public decimal TotalAmount { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string PaymentMethod { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }

        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }
        public RentalForm RentalForm { get; set; }
    }
}
