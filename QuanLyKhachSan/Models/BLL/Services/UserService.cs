using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.BLL.SupportService;
using QuanLyKhachSan.Models.DAL;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class UserService : IBusinessService<User>
    {
        public User GetById(int id)
            => DALs.UserRepo.GetById(id);

        public List<User> GetAllData()
            => DALs.UserRepo.GetAllData();

        public void Add(User user)
            => DALs.UserRepo.Add(user);

        public void Delete(int Id)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.UserRepo.Delete(Id);
        }

        public void Update(User user)
            => DALs.UserRepo.Update(user);

        public List<Invoice> GetInvoice(int id)
            => DALs.UserRepo.GetInvoice(id);

        public List<Rental> GetRental(int id)
            => DALs.UserRepo.GetRental(id);

        
    }
}
