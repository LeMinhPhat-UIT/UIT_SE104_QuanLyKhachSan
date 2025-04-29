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
    public class RoomService : IBusinessService<Room>
    {
        public Room GetById(int id)
            => RepositoryHub.RoomRepo.GetById(id);

        public List<Room> GetAllData()
            => RepositoryHub.RoomRepo.GetAllData();

        public void Add(Room room)
        {
            decimal tierPrice = RepositoryHub.RoomTierRepo.GetById((int)room.RoomTierID).RoomTierPrice;
            if (room.PricePerDay < tierPrice)
                return;
            RepositoryHub.RoomRepo.Add(room);
        }

        public void Delete(int Id)
        {
            if (DeleteDialogHelper.Warning() == System.Windows.MessageBoxResult.No)
                return;
            RepositoryHub.RoomRepo.Delete(Id);
        }

        public void Update(Room room)
        {
            decimal tierPrice = RepositoryHub.RoomTierRepo.GetById((int)room.RoomTierID).RoomTierPrice;
            if (room.PricePerDay < tierPrice)
                return;
            RepositoryHub.RoomRepo.Update(room);
        }

        public RoomTier GetTier(int Id)
            => RepositoryHub.RoomRepo.GetTier(Id);

        public List<Rental> GetRentalDetail(int Id)
            => RepositoryHub.RoomRepo.GetRentalDetail(Id);
    }
}
