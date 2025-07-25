﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL.Interfaces;

namespace QuanLyKhachSan.Models.DAL.Repositories
{
    internal class CustomerDAL : IEntityRepository<Customer>
    {
        public Customer? GetById(int id)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.Customer
                    where c.CustomerID == id
                    select c).FirstOrDefault();
        }

        public Customer? GetByIdentity(string identity)
        {
            using var dbcontext = new HotelDbContext();
            return (from c in dbcontext.Customer
                    where c.IdentityNumber == identity
                    select c).FirstOrDefault();
        }

        public List<Customer> GetAllData() 
        {
            using var dbcontext = new HotelDbContext();
            return dbcontext.Customer.ToList();
        }

        public void Add(Customer customer)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Customer.Add(customer);
            dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Remove(GetById(Id));
            dbcontext.SaveChanges();
        }

        public void Update(Customer customerInfo)
        {
            using var dbcontext = new HotelDbContext();
            dbcontext.Attach(customerInfo);
            dbcontext.Entry(customerInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public CustomerTier GetTier(int Id)
            => LoadTier(GetById(Id)).CustomerTier;

        public Customer LoadTier(Customer cus)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(cus);
            e.Reference(c => c.CustomerTier).Load();
            return cus;
        }

        public List<Reservation> GetReservations(int Id)
            => LoadResevations(GetById(Id)).Reservations;

        public Customer LoadResevations(Customer cus)
        {
            using var dbcontext = new HotelDbContext();
            var e = dbcontext.Entry(cus);
            e.Collection(c => c.Reservations).Load();
            return cus;
        }
    }
}
