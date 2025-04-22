using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string UserName { get; set; }

        [StringLength(200)]
        [Column(TypeName="varchar")]
        public string Password { get; set; }

        [StringLength(12)]
        [Column(TypeName="char")]
        public string IdentityNumber {  get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string Role { get; set; }

        [StringLength(20)]
        [Column(TypeName="char")]
        public string EmailAddress { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName="ntext")]
        public string Address { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Rental> RentalForms { get; set; }
        public List<RevenueReport> RevenueReports { get; set; }
    }
}
