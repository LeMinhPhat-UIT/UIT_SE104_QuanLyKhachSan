using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class AmenityViewModel
    {
        public int ID { get; set; } 
        public string AmenityName { get; }

        public AmenityViewModel(Amenity amenity)
        {
            ID = amenity.AmenityID;
            AmenityName = amenity.AmenityName;
        }
    }
}
