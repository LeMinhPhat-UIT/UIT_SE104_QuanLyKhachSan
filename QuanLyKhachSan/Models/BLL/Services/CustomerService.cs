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

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class CustomerService : IBusinessService<Customer>
    {
        public Customer GetById(int id)
            => RepositoryHub.CustomerRepo.GetById(id);

        public List<Customer> GetAllData()
            => RepositoryHub.CustomerRepo.GetAllData();

        public void Add(Customer customer)
        {
            if(CheckValid.IsCustomerValid(customer))
                RepositoryHub.CustomerRepo.Add(customer);
        }

        public void Delete(int Id)
        {
            if (RepositoryHub.CustomerRepo.GetReservations(Id).Count != 0)
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

        //public List<Customer> Search(Customer template)
        //{
        //    using var dbcontext = new HotelDbContext();
        //    var list = dbcontext.Customer.AsQueryable();
        //    var props = typeof(Customer).GetProperties();
        //    props.ToList().ForEach(
        //        prop =>
        //        {
        //            var value = prop.GetValue(template);
        //            if (value == null) return;
        //            if (prop.PropertyType == typeof(string))
        //            {
        //                string strValue = value as string;
        //                if (!string.IsNullOrWhiteSpace(strValue))
        //                {
        //                    list = list.Where(a =>
        //                        EF.Functions.Like(EF.Property<string>(a, prop.Name), $"%{strValue}%"));
        //                }
        //            }
        //            else if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
        //            {
        //                // kiểu nullable như int?, DateTime?, bool?
        //                list = list.Where(a =>
        //                    EF.Property<object>(a, prop.Name).Equals(value));
        //            }
        //        }
        //    );
        //    return list.ToList();
        //}
    }
}
