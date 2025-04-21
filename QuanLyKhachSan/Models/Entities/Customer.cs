using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Customer
    {
        [Key]
        public int CustomerID {  get; set; }
        public int? CustomerTierID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string CustomerName { get; set; }

        [StringLength(12)]
        [Column(TypeName="char")]
        public string IdentityNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName="ntext")]
        public string CustomerAddress { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string CustomerPhoneNumber { get; set; }

        [ForeignKey("CustomerTierID")]
        public CustomerTier CustomerTier { get; set; }
        public List<RentalDetail> RentalDetails { get; set; }
    }
}
