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
    internal class RoomTierService : IBusinessService<RoomTier>
    {
        public RoomTier GetById(int id)
            => RepositoryHub.RoomTierRepo.GetById(id);

        public List<RoomTier> GetAllData()
            => RepositoryHub.RoomTierRepo.GetAllData();

        public void Add(RoomTier tier)
            => RepositoryHub.RoomTierRepo.Add(tier);

        public void Delete(int Id)
        {
            if (RepositoryHub.RoomTierRepo.GetReports(Id).Count != 0 || RepositoryHub.RoomTierRepo.GetRooms(Id).Count !=0)
            {
                DeleteDialogHelper.RestrictWarning();
                return;
            }
            RepositoryHub.RoomTierRepo.Delete(Id);
        }

        public void Update(RoomTier tier)
            => RepositoryHub.RoomTierRepo.Update(tier);

        public List<Room> GetRooms(int Id)
            => RepositoryHub.RoomTierRepo.GetRooms(Id);

        public List<RevenueReport> GetReports(int Id)
            => RepositoryHub.RoomTierRepo.GetReports(Id);
    }
}
