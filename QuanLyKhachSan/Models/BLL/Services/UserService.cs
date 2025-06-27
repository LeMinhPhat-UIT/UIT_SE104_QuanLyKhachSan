using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Helpers.Security;
using QuanLyKhachSan.Models.BLL.Helpers.Validation;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class UserService : IBusinessService<User>
    {
        public User GetById(int id)
            => RepositoryHub.UserRepo.GetById(id);

        public User? GetByIdentity(string identity)
            => RepositoryHub.UserRepo.GetByIdentity(identity);

        public List<User> GetAllData()
            => RepositoryHub.UserRepo.GetAllData();

        public void Add(User user)
        {
            if (CheckValid.IsUserValid(user))
            {
                user.Password = PasswordService.HashPassword(user.Password);
                RepositoryHub.UserRepo.Add(user);
            }
        }

        public void Delete(int id)
        {
            if (GetReservations(id).Count !=0 || GetRevenueReports(id).Count !=0 || GetInvoices(id).Count != 0)
            {
                DeleteDialogHelper.RestrictWarning();
                return;
            }
            RepositoryHub.UserRepo.Delete(id);
        }

        public void Update(User user)
        {
            if (CheckValid.IsUserValid(user))
                RepositoryHub.UserRepo.Update(user);
        }

        public List<Invoice> GetInvoices(int id)
            => RepositoryHub.UserRepo.GetInvoices(id);

        public List<Reservation> GetReservations(int id)
            => RepositoryHub.UserRepo.GetReservations(id);

        public List<RevenueReport> GetRevenueReports(int id)
            => RepositoryHub.UserRepo.GetReports(id);

        //Add
        public Role GetRole(int id)
            => RepositoryHub.UserRepo.GetRole(id);
    }
}
