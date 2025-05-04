using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Revenue_Invoice
    {
        public int ReportID { get; set; }

        public int InvoiceID { get; set; }

        [ForeignKey("ReportID")]
        public RevenueReport Report { get; set; }

        [ForeignKey("InvoiceID")]
        public Invoice Invoice { get; set; }
    } 
}
