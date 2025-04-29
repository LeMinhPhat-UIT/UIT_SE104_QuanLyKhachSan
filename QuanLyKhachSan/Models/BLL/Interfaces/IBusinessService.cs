using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models.BLL.Interfaces
{
    public interface IBusinessService<T>
    {
        public T GetById(int id);
        public List<T> GetAllData();
        public void Add(T entity);
        public void Delete(int id);
        public void Update(T entity);
        //public List<T> Search(T template);
    }
}
