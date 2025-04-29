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
    public class RentalService : IBusinessService<Rental>
    {
        public Rental GetById(int id)
            => RepositoryHub.RentalRepo.GetById(id);

        public List<Rental> GetAllData()
            => RepositoryHub.RentalRepo.GetAllData();

        public void Add(Rental rental)
        {
            var list = new List<string> { "Pending", "CheckIn", "CheckOut", "Cancelled" };
            if(rental.CheckOutDate>rental.CheckInDate)
                if(list.Any(x => x.Equals(rental.Status)))
                    RepositoryHub.RentalRepo.Add(rental);
        }

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.RentalRepo.Delete(Id);
        }

        public void Update(Rental rental)
            => RepositoryHub.RentalRepo.Update(rental);

        public Room GetRoom(int Id)
            => RepositoryHub.RentalRepo.GetRoom(Id);

        public User GetUser(int Id)
            => RepositoryHub.RentalRepo.GetUser(Id);

        public Invoice GetInvoice(int Id)
            => RepositoryHub.RentalRepo.GetInvoice(Id);

        public List<RentalDetail> GetDetail(int Id)
            => RepositoryHub.RentalRepo.GetDetail(Id);

    }
}
