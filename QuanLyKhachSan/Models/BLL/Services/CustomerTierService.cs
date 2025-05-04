using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class CustomerTierService : IBusinessService<CustomerTier>
    {
        public CustomerTier GetById(int id)
            => RepositoryHub.CustomerTierRepo.GetById(id);

        public List<CustomerTier> GetAllData()
            => RepositoryHub.CustomerTierRepo.GetAllData();

        public void Add(CustomerTier tier)
            => RepositoryHub.CustomerTierRepo.Add(tier);

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.CustomerTierRepo.Delete(Id);
        }

        public void Update(CustomerTier tier)
            => RepositoryHub.CustomerTierRepo.Update(tier);

        public List<Customer> GetCustomers(int Id)
            => RepositoryHub.CustomerTierRepo.GetCustomers(Id);
    }
}
