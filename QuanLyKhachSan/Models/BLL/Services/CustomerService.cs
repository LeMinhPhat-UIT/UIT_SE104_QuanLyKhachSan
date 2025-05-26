using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.Models.BLL.Helpers.Validation;
using QuanLyKhachSan.UI.Utilities;
using QuanLyKhachSan.Models.Core.Entities;
using System.Windows;
using EntityFramework;

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class CustomerService : IBusinessService<Customer>
    {
        public Customer GetById(int id)
            => RepositoryHub.CustomerRepo.GetById(id);

        public Customer? GetByIdentity(string identity)
            => RepositoryHub.CustomerRepo.GetByIdentity(identity);

        public List<Customer> GetAllData()
            => RepositoryHub.CustomerRepo.GetAllData();

        public void Add(Customer customer)
        {
            if(CheckValid.IsCustomerValid(customer))
                RepositoryHub.CustomerRepo.Add(customer);
        }

        public void Delete(int Id)
        {
            if (GetReservations(Id).Count != 0)
            {
                DeleteDialogHelper.RestrictWarning();
                return;
            }
            RepositoryHub.CustomerRepo.Delete(Id);
        }

        public void Update(Customer customer)
        {
            if (CheckValid.IsCustomerValid(customer))
                RepositoryHub.CustomerRepo.Update(customer);
        }

        public CustomerTier GetCustomerTier(int cusID)
            => RepositoryHub.CustomerRepo.GetTier(cusID);

        public List<Reservation> GetReservations(int cusID)
            => RepositoryHub.CustomerRepo.GetReservations(cusID);

        
    }
}
