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
    public class CustomerTierService : IBusinessService<CustomerTier>
    {
        public CustomerTier GetById(int id)
            => DALs.CustomerTierRepo.GetById(id);

        public List<CustomerTier> GetAllData()
            => DALs.CustomerTierRepo.GetAllData();

        public void Add(CustomerTier tier)
            => DALs.CustomerTierRepo.Add(tier);

        public void Delete(int Id)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.CustomerTierRepo.Delete(Id);
        }

        public void Update(CustomerTier tier)
            => DALs.CustomerTierRepo.Update(tier);

        public List<Customer> GetCustomers(int Id)
            => DALs.CustomerTierRepo.GetCustomers(Id);
    }
}
