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
    public class RoomTierService : IBusinessService<RoomTier>
    {
        public RoomTier GetById(int id)
            => DALs.RoomTierRepo.GetById(id);

        public List<RoomTier> GetAllData()
            => DALs.RoomTierRepo.GetAllData();

        public void Add(RoomTier tier)
            => DALs.RoomTierRepo.Add(tier);

        public void Delete(int Id)
        {
            if (DALs.RoomTierRepo.GetReport(Id).Count != 0)
            {
                DeleteWarning.RestrictWarning();
                return;
            }
            DALs.RoomTierRepo.Delete(Id);
        }

        public void Update(RoomTier tier)
            => DALs.RoomTierRepo.Update(tier);

        public List<Room> GetRoom(int Id)
            => DALs.RoomTierRepo.GetRoom(Id);

        public List<RevenueReport> GetReport(int Id)
            => DALs.RoomTierRepo.GetReport(Id);
    }
}
