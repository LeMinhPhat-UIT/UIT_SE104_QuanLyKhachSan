using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.DAL.Interfaces
{
    public interface IDetailRepository<T>
    {
        void Add(params T[] entity);
        void Delete(int id1, int id2);
    }
}
