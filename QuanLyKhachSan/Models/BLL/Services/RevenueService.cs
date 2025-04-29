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
    public class RevenueService : IBusinessService<RevenueReport>
    {
        public RevenueReport GetById(int id)
            => DALs.RevenueRepo.GetById(id);

        public List<RevenueReport> GetAllData()
            => DALs.RevenueRepo.GetAllData();

        public void Add(RevenueReport revenue)
            => DALs.RevenueRepo.Add(revenue);

        public void Delete(int Id)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.RevenueRepo.Delete(Id);
        }

        public void Update(RevenueReport revenue)
            => DALs.RevenueRepo.Update(revenue);

        public User GetUser(int Id)
            => DALs.RevenueRepo.GetUser(Id);

        public RoomTier GetRoomTier(int Id)
            => DALs.RevenueRepo.GetRoomTier(Id);

        public List<RevenueDetail> GetDetail(int Id)
            => DALs.RevenueRepo.GetDetail(Id);
    }
}
