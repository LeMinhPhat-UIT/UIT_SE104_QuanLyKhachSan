using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class RoomTierViewModel
    {
        public int ID { get; set; }
        public string RoomTierName { get; set; }
        public decimal RoomTierPrice { get; set; }
        public int RoomCount { get; }
        public int Capacity { get; set; }

        public RoomTierViewModel(RoomTier roomTier)
        {
            ID = roomTier.RoomTierID;
            RoomTierName = roomTier.RoomTierName;
            RoomTierPrice = roomTier.RoomTierPrice;
            RoomCount = QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetRooms(roomTier.RoomTierID).Count;
            if (roomTier.RoomTierName == "Phòng đơn")
                Capacity = 1;
            else if(roomTier.RoomTierName == "Phòng đôi")
                Capacity = 2;
            else
                Capacity = 3;
        }
    }
}
