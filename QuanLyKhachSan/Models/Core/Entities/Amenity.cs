using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.Core.Entities
{
    public class Amenity
    {
        [Key]
        public int AmenityID { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar")]
        public string AmenityName { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
