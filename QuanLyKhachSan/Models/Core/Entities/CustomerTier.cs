using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class CustomerTier
    {
        [Key]
        public int CustomerTierID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string CustomerTierName { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
