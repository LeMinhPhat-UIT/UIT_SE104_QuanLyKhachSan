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
    internal class RevenueService : IBusinessService<RevenueReport>
    {
        public RevenueReport GetById(int id)
            => RepositoryHub.RevenueRepo.GetById(id);

        public List<RevenueReport> GetAllData()
            => RepositoryHub.RevenueRepo.GetAllData();

        public void Add(RevenueReport revenue)
            => RepositoryHub.RevenueRepo.Add(revenue);

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.RevenueRepo.Delete(Id);
        }

        public void Update(RevenueReport revenue)
            => RepositoryHub.RevenueRepo.Update(revenue);
        public void AddInvoice(int reportID, int invoiceID)
            => RepositoryHub.RevenueRepo.AddInvoice(reportID, invoiceID);

        public void DeleteInvoice(int reportID, int invoiceID)
            => RepositoryHub.RevenueRepo.DeleteInvoice(reportID, invoiceID);

        public User GetUser(int Id)
            => RepositoryHub.RevenueRepo.GetUser(Id);

        public RoomTier GetRoomTier(int Id)
            => RepositoryHub.RevenueRepo.GetRoomTier(Id);

        public List<Invoice> GetInvoices(int Id)
            => RepositoryHub.RevenueRepo.GetInvoices(Id);
    }
}
