using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models.Entities.Interface_AbstractClass
{
    public interface IEntity<T>
    {
        [Key]
        public T ID { get; set; }
    }
}
