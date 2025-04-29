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
    public class RentalDetailService
    {
        public void Add(RentalDetail rentalDetail)
            => RepositoryHub.RentalDetailRepo.Add(rentalDetail);

        public void Delete(int rentalID, int customerID)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.RentalDetailRepo.Delete(rentalID, customerID);
        }

        public void Update(RentalDetail rentalDetail)
            => RepositoryHub.RentalDetailRepo.Update(rentalDetail);
    }
}
