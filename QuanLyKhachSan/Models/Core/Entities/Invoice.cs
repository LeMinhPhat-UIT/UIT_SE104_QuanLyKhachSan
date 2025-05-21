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
        public int? ReportID { get; set; } = null;
        public int? UserID { get; set; }

        [Column(TypeName="smalldatetime")]
        public DateTime InvoiceDate { get; set; }

        public int SurchargeRate { get; set; }

        [Column(TypeName="money")]
        public decimal TotalAmount { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string PaymentMethod { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Status { get; set; } = "Pending";

        [ForeignKey("UserID")]
        public User User { get; set; }
        public Reservation Reservation { get; set; }
        [ForeignKey("ReportID")]
        public RevenueReport RevenueReport { get; set; }

        public Invoice() { }
        public Invoice(int reservationID, int userID, DateTime invoiceDate, int surchargeRate, decimal totalAmount, string paymentMethod, string status="Pending")
        {
            ReservationID = reservationID;
            UserID = userID;
            InvoiceDate = invoiceDate;
            SurchargeRate = surchargeRate;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
            Status = status;
        }
    }
}
