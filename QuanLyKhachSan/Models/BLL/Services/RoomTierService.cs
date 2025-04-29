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
    public class RoomTierService : IBusinessService<RoomTier>
    {
        public RoomTier GetById(int id)
            => RepositoryHub.RoomTierRepo.GetById(id);

        public List<RoomTier> GetAllData()
            => RepositoryHub.RoomTierRepo.GetAllData();

        public void Add(RoomTier tier)
            => RepositoryHub.RoomTierRepo.Add(tier);

        public void Delete(int Id)
        {
            if (RepositoryHub.RoomTierRepo.GetReport(Id).Count != 0)
            {
                DeleteDialogHelper.RestrictWarning();
                return;
            }
            RepositoryHub.RoomTierRepo.Delete(Id);
        }

        public void Update(RoomTier tier)
            => RepositoryHub.RoomTierRepo.Update(tier);

        public List<Room> GetRoom(int Id)
            => RepositoryHub.RoomTierRepo.GetRoom(Id);

        public List<RevenueReport> GetReport(int Id)
            => RepositoryHub.RoomTierRepo.GetReport(Id);
    }
}
