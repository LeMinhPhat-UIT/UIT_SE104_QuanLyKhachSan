using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string RoleName { get; set; }
        public List<User> Users { get; set; }

        public Role() { }
        public Role(string name)
            =>RoleName = name;
    }
}
