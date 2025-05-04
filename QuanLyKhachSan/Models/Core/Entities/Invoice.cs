using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        public int ReservationID { get; set; }
        public int? UserID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        public int SurchargeRate { get; set; }

        [Column(TypeName="money")]
        public decimal TotalAmount { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string PaymentMethod { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        public Reservation Reservation { get; set; }
        public List<RevenueReport> RevenueReports { get; set; } = new List<RevenueReport>();
        //public List<Revenue_Invoice> RevenueDetails { get; set; }
    }
}
