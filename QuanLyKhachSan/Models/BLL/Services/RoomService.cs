using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyKhachSan.Models.BLL.Helpers.Validation;
using QuanLyKhachSan.Models.BLL.Interfaces;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.Models.DAL;
using QuanLyKhachSan.UI.Utilities;

namespace QuanLyKhachSan.Models.BLL.Services
{
    internal class RoomService : IBusinessService<Room>
    {
        public Room GetById(int id)
            => RepositoryHub.RoomRepo.GetById(id);

        public List<Room> GetAllData()
            => RepositoryHub.RoomRepo.GetAllData();

        public void Add(Room room)
        {
            if(CheckValid.IsRoomValid(room))
                RepositoryHub.RoomRepo.Add(room);
        }

        public void Delete(int Id)
        {

            if (RepositoryHub.RoomRepo.GetReservations(Id).Count != 0)
            {
                DeleteDialogHelper.RestrictWarning();
                return;
            }
            RepositoryHub.RoomRepo.Delete(Id);
        }

        public void Update(Room room)
        {
            if (CheckValid.IsRoomValid(room))
                RepositoryHub.RoomRepo.Add(room);
        }

        public void AddAmenity(Room room, Amenity amenity)
            => RepositoryHub.RoomRepo.AddAmenity(room, amenity);

        public void DeleteAmenity(int roomID, int amenityID)
            => RepositoryHub.RoomRepo.DeleteAmenity(roomID, amenityID);

        public RoomTier GetTier(int Id)
            => RepositoryHub.RoomRepo.GetTier(Id);

        public List<Reservation> GetReservations(int Id)
            => RepositoryHub.RoomRepo.GetResevations(Id);
    }
}
