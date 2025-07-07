using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.Core.Entities;

namespace QuanLyKhachSan.ViewModel.EntityViewModels
{
    public class RoomViewModel : BaseViewModel
    {
        private int _id;
        private string _roomNumber;
        private decimal _pricePerDay;
        private string _roomState;
        private string _roomTierName;
        private ObservableCollection<AmenityViewModel> _amenities = new ObservableCollection<AmenityViewModel>();

        public int RoomID { get => _id; set { _id = value; OnPropertyChanged(nameof(RoomID)); } }
        public string RoomNumber { get => _roomNumber; set { _roomNumber = value; OnPropertyChanged(nameof(RoomNumber)); } }
        public decimal PricePerDay { get => _pricePerDay; set { _pricePerDay = value; OnPropertyChanged(nameof(PricePerDay)); }  }
        public string RoomState { get => _roomState; set { _roomState = value; OnPropertyChanged(nameof(RoomState)); }  }
        public string RoomTierName 
        { 
            get =>_roomTierName; 
            set 
            { 
                _roomTierName = value; 
                OnPropertyChanged(nameof(RoomTierName)); 
                OnPropertyChanged(nameof(Amenity)); 
            } 
        }
        public string Amenity => string.Join(", ", Amenities.Select(x => x.AmenityName));
        public IEnumerable<AmenityViewModel> Amenities => _amenities;


        public RoomViewModel()
        {

        }

        public RoomViewModel(Room room)
        {
            RoomID = room.RoomID;
            RoomNumber = room.RoomNumber;
            RoomState = room.RoomState;
            PricePerDay = QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetById((int)room.RoomTierID).RoomTierPrice;
            RoomTierName = QuanLyKhachSan.Models.BLL.Service.RoomService.GetTier(room.RoomID).RoomTierName;
            QuanLyKhachSan.Models.BLL.Service.RoomService.GetAmenities(room.RoomID).ForEach(x => _amenities.Add(new AmenityViewModel(x)));

            _amenities.CollectionChanged += Amenities_CollectionChanged;
        }

        private void Amenities_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Amenity));
        }

        public void AddAmenity(AmenityViewModel amenity)
        {
            _amenities.Add(amenity);
        }
        public void ClearAmenity()
        {
            _amenities.Clear();
        }
        public void DeleteAmenity(AmenityViewModel amenity)
        {
            _amenities.Remove(amenity);
        }
    }
}
