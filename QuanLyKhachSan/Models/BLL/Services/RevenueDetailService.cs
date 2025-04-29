using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using QuanLyKhachSan.Models.BLL.SupportService;
using QuanLyKhachSan.Models.DAL;

namespace QuanLyKhachSan.Models.BLL.Services
{
    public class RevenueDetailService
    {
        public void Add(RevenueDetail revenueDetail)
            => DALs.RevenueDetailRepo.Add(revenueDetail);

        public void Delete(int rentalID, int customerID)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.RevenueDetailRepo.Delete(rentalID, customerID);
        }

        public void Update(RevenueDetail revenueDetail)
            => DALs.RevenueDetailRepo.Update(revenueDetail);
    }
}
