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
    public class RentalService : IBusinessService<Rental>
    {
        public Rental GetById(int id)
            => DALs.RentalRepo.GetById(id);

        public List<Rental> GetAllData()
            => DALs.RentalRepo.GetAllData();

        public void Add(Rental rental)
        {
            var list = new List<string> { "Pending", "CheckIn", "CheckOut", "Cancelled" };
            if(rental.CheckOutDate<rental.CheckInDate)
                if(list.Any(x => x.Equals(rental.Status)))
                    DALs.RentalRepo.Add(rental);
        }

        public void Delete(int Id)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.RentalRepo.Delete(Id);
        }

        public void Update(Rental rental)
            => DALs.RentalRepo.Update(rental);

        public Room GetRoom(int Id)
            => DALs.RentalRepo.GetRoom(Id);

        public User GetUser(int Id)
            => DALs.RentalRepo.GetUser(Id);

        public Invoice GetInvoice(int Id)
            => DALs.RentalRepo.GetInvoice(Id);

        public List<RentalDetail> GetDetail(int Id)
            => DALs.RentalRepo.GetDetail(Id);

    }
}
