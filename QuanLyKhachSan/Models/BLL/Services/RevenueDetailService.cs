using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class RevenueDetailService
    {
        public void Add(RevenueDetail revenueDetail)
            => RepositoryHub.RevenueDetailRepo.Add(revenueDetail);

        public void Delete(int rentalID, int customerID)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.RevenueDetailRepo.Delete(rentalID, customerID);
        }

        public void Update(RevenueDetail revenueDetail)
            => RepositoryHub.RevenueDetailRepo.Update(revenueDetail);
    }
}
