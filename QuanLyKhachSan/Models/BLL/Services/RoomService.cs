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
    public class RoomService : IBusinessService<Room>
    {
        public Room GetById(int id)
            => DALs.RoomRepo.GetById(id);

        public List<Room> GetAllData()
            => DALs.RoomRepo.GetAllData();

        public void Add(Room room)
        {
            decimal tierPrice = DALs.RoomTierRepo.GetById((int)room.RoomTierID).RoomTierPrice;
            if (room.PricePerDay < tierPrice)
                return;
            DALs.RoomRepo.Add(room);
        }

        public void Delete(int Id)
        {
            if (DeleteWarning.Warning() == System.Windows.MessageBoxResult.No)
                return;
            DALs.RoomRepo.Delete(Id);
        }

        public void Update(Room room)
        {
            decimal tierPrice = DALs.RoomTierRepo.GetById((int)room.RoomTierID).RoomTierPrice;
            if (room.PricePerDay < tierPrice)
                return;
            DALs.RoomRepo.Update(room);
        }

        public RoomTier GetTier(int Id)
            => DALs.RoomRepo.GetTier(Id);

        public List<Rental> GetRentalDetail(int Id)
            => DALs.RoomRepo.GetRentalDetail(Id);
    }
}
