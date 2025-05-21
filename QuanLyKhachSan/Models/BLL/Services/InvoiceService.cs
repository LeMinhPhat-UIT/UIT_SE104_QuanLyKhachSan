using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Helpers.Validation;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class InvoiceService : IBusinessService<Invoice>
    {
        public Invoice GetById(int id)
            => RepositoryHub.InvoiceRepo.GetById(id);

        public List<Invoice> GetAllData()
            => RepositoryHub.InvoiceRepo.GetAllData();

        public void Add(Invoice invoice)
        {
            if(CheckValid.IsInvoiceValid(invoice))
                RepositoryHub.InvoiceRepo.Add(invoice);
        }

        public void Delete(int Id)
        {
            if (GetById(Id).ReportID != null)
            {
                DeleteDialogHelper.RestrictWarning();
                return;
            }
            else if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.InvoiceRepo.Delete(Id);
        }

        public void Update(Invoice invoice)
        {
            if (CheckValid.IsInvoiceValid(invoice))
                RepositoryHub.InvoiceRepo.Update(invoice);
        }

        public User GetUser(int invoiceID)
            => RepositoryHub.InvoiceRepo.GetUser(invoiceID);

        public RevenueReport GetRevenueReport(int Id)
            => RepositoryHub.InvoiceRepo.GetRevenueReport(Id);

        public Reservation GetReservation(int Id)
            => RepositoryHub.InvoiceRepo.GetReservation(Id);

    }
}
