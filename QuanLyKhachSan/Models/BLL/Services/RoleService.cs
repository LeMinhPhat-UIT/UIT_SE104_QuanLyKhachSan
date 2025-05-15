using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class RoleService : IBusinessService<Role>
    {
        public Role GetById(int id)
            => RepositoryHub.RoleRepo.GetById(id);

        public List<Role> GetAllData()
            => RepositoryHub.RoleRepo.GetAllData();

        public void Add(Role tier)
            => RepositoryHub.RoleRepo.Add(tier);

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.RoleRepo.Delete(Id);
        }

        public void Update(Role tier)
            => RepositoryHub.RoleRepo.Update(tier);

        public List<User> GetUsers(int Id)
            => RepositoryHub.RoleRepo.GetUsers(Id);
    }
}
