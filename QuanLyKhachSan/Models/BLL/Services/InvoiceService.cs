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
    public class InvoiceService : IBusinessService<Invoice>
    {
        public Invoice GetById(int id)
            => DALs.InvoiceRepo.GetById(id);

        public List<Invoice> GetAllData()
            => DALs.InvoiceRepo.GetAllData();

        public void Add(Invoice invoice)
            => DALs.InvoiceRepo.Add(invoice);

        public void Delete(int Id)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.InvoiceRepo.Delete(Id);
        }

        public void Update(Invoice invoice)
            => DALs.InvoiceRepo.Update(invoice);

        public User GetUser(int invoiceID)
            => DALs.InvoiceRepo.GetUser(invoiceID);

        public List<RevenueDetail> GetRevenueDetail(int Id)
            => DALs.InvoiceRepo.GetRevenueDetail(Id);

        public Rental GetRental(int Id)
            => DALs.InvoiceRepo.GetRental(Id);

    }
}
