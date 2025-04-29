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
    public class RentalDetailService
    {
        public void Add(RentalDetail rentalDetail)
            => DALs.RentalDetailRepo.Add(rentalDetail);

        public void Delete(int rentalID, int customerID)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.RentalDetailRepo.Delete(rentalID, customerID);
        }

        public void Update(RentalDetail rentalDetail)
            => DALs.RentalDetailRepo.Update(rentalDetail);
    }
}
