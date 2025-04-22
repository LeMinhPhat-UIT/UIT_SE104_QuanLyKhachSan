using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.DAL;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class InvoiceService : IBusinessService<Invoice>
    {
        public Invoice GetById(int id)
            => DALs.InvoiceRepo.GetById(id);

        public List<Invoice> GetAllData()
            => DALs.InvoiceRepo.GetAllData();

        public void Add(Invoice invoice)
            => DALs.InvoiceRepo.Add(invoice);

        public void Delete(int Id)
            => DALs.InvoiceRepo.Delete(Id);

        public void Update(Invoice invoice)
            => DALs.InvoiceRepo.Update(invoice);

        public User GetUser(int invoiceID)
            => DALs.InvoiceRepo.GetUser(invoiceID);

        public List<RevenueDetail> GetRevenueDetail(int Id)
            => DALs.InvoiceRepo.GetRevenueDetail(Id);

        public Rental GetRental(int Id)
            => DALs.InvoiceRepo.GetRental(Id);

        public List<Invoice> Search(Invoice template)
        {
            using var dbcontext = new HotelDbContext();
            var list = dbcontext.Invoice.AsQueryable();
            var props = typeof(Invoice).GetProperties();
            props.ToList().ForEach(
                prop =>
                {
                    var value = prop.GetValue(template);
                    if (value == null) return;
                    if (prop.PropertyType == typeof(string))
                    {
                        string strValue = value as string;
                        if (!string.IsNullOrWhiteSpace(strValue))
                        {
                            list = list.Where(a =>
                                EF.Functions.Like(EF.Property<string>(a, prop.Name), $"%{strValue}%"));
                        }
                    }
                    else if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                    {
                        // kiểu nullable như int?, DateTime?, bool?
                        list = list.Where(a =>
                            EF.Property<object>(a, prop.Name).Equals(value));
                    }
                }
            );
            return list.ToList();
        }
    }
}
