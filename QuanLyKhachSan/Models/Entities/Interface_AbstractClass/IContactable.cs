using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models.Entities.Interface_AbstractClass
{
    public interface IContactable
    {
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [StringLength(10)]
        [Column(TypeName="char")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Address { get; set; }

    }
}
