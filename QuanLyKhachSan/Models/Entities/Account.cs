using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Account
    {
        [Key]
        [ForeignKey("StaffID")]
        public int StaffID { get; set; }

        [StringLength(50)]
        [Column(TypeName="nvarchar")]
        public string AccountName { get; set; }

        [StringLength(200)]
        [Column(TypeName="varchar")]
        public string Password { get; set; }
        public Staff Staff { get; set; }
    }
}
