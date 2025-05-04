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
    internal class AmenityService : IBusinessService<Amenity>
    {
        public Amenity GetById(int id)
            => RepositoryHub.AmenityRepo.GetById(id);

        public List<Amenity> GetAllData()
            => RepositoryHub.AmenityRepo.GetAllData();

        public void Add(Amenity tier)
            => RepositoryHub.AmenityRepo.Add(tier);

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.AmenityRepo.Delete(Id);
        }

        public void Update(Amenity tier)
            => RepositoryHub.AmenityRepo.Update(tier);

        public List<Room> GetRooms(int Id)
            => RepositoryHub.AmenityRepo.GetRooms(Id);
    }
}
