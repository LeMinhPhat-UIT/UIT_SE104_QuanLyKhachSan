using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string StaffName { get; set; }

        [StringLength(12)]
        [Column(TypeName="char")]
        public string IdentityNumber {  get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string Authority { get; set; }

        [StringLength(20)]
        [Column(TypeName="char")]
        public string EmailAddress { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName="ntext")]
        public string Address { get; set; }
        public Account Account { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<RentalForm> RentalForms { get; set; }
    }
}
