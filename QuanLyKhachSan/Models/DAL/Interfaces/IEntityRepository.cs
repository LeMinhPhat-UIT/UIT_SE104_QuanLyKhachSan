using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.DAL.Interfaces
{
    public interface IEntityRepository<T>
    {
        T? GetById(int id);
        List<T> GetAllData();
        void Add(T entities);
        void Delete(int ID);
        void Update(T entity);
    }
}
