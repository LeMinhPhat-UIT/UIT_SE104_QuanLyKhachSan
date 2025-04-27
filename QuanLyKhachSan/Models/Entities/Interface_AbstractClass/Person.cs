using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Entities.Interface_AbstractClass
{
    public abstract class Person
    {
        [StringLength(12)]
        [Column(TypeName = "char")]
        public string IdentityNumber { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Column(TypeName = "bit")]
        public int Sex { get; set; }
    }
}
