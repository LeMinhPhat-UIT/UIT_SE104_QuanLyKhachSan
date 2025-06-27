using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.ViewModel
{
    public class AddUpdateRoomViewModel : BaseViewModel
    {
        private RoomViewModel _room;
        private ObservableCollection<RoomTierViewModel> _roomTiers;
        private ObservableCollection<AmenityViewModel> _amenities;
        private ObservableCollection<AmenityViewModel> _selectedAmenities;
        private RoomTierViewModel _selectedRoomTier;
        private ObservableCollection<string> _roomStates;

        public RoomViewModel Room { get => _room; set { _room = value; OnPropertyChanged(nameof(Room)); } }
        public IEnumerable<string> RoomStates => _roomStates;
        public IEnumerable<RoomTierViewModel> RoomTiers => _roomTiers;
        public IEnumerable<AmenityViewModel> Amenities => _amenities;
        public IEnumerable<AmenityViewModel> SelectedAmenities => _selectedAmenities;
        public RoomTierViewModel SelectedTier { get => _selectedRoomTier; set { _selectedRoomTier = value; OnPropertyChanged(nameof(SelectedTier)); } }
        public bool IsSaved { get; set; } = false;

        public ICommand Save { get; set; }
        public ICommand Close { get; set; }
        public Action? CloseAction { get; set; }

        public AddUpdateRoomViewModel(RoomViewModel? room=null)
        {
            _amenities = new ObservableCollection<AmenityViewModel>();
            _roomTiers = new ObservableCollection<RoomTierViewModel>();
            _selectedAmenities = new ObservableCollection<AmenityViewModel>();
            _room = new RoomViewModel();
            _roomStates = new ObservableCollection<string>() { "Available", "Occupied" };

            QuanLyKhachSan.Models.BLL.Service.AmenityService.GetAllData().ForEach(x => _amenities.Add(new AmenityViewModel(x)));
            QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetAllData().ForEach(x => _roomTiers.Add(new RoomTierViewModel(x)));

            if(room != null && room.RoomID !=0)
            {
                _room = room;
                SelectedTier = RoomTiers.FirstOrDefault(x => x.RoomTierName == room.RoomTierName);
                room.Amenities.ToList().ForEach(x =>
                {
                    var foundItem = _amenities.FirstOrDefault(y => y.ID==x.ID);
                    if (foundItem != null)
                        _selectedAmenities.Add(foundItem);
                });
            }

            Save = new AddUpdateRoomCommand
            (
                this,
                _ => AddAndUpdate(),
                _ =>
                {
                    return
                        !string.IsNullOrEmpty(Room.RoomNumber) && Room.PricePerDay != 0 && !string.IsNullOrEmpty(Room.RoomState) &&
                        SelectedTier != null && SelectedAmenities != null;
                }
            );

            Close = new AddUpdateRoomCommand(this, _ => CloseAction?.Invoke());
        }

        private void AddAndUpdate()
        {
            if(_room.RoomID != 0)
            {                
                var room = QuanLyKhachSan.Models.BLL.Service.RoomService.GetById(_room.RoomID);
                room.RoomTierID = SelectedTier.ID;
                room.RoomNumber = _room.RoomNumber;
                room.PricePerDay = _room.PricePerDay;
                room.RoomState = _room.RoomState;
                var amenities = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAmenities(room.RoomID);
                amenities.ForEach(x => QuanLyKhachSan.Models.BLL.Service.RoomService.DeleteAmenity(room.RoomID, x.AmenityID));
                SelectedAmenities.ToList().ForEach(x => QuanLyKhachSan.Models.BLL.Service.RoomService.AddAmenity(room.RoomID, x.ID));
                QuanLyKhachSan.Models.BLL.Service.RoomService.Update(room);
                _room.RoomTierName = SelectedTier.RoomTierName;
                _room.ClearAmenity();
                SelectedAmenities.ToList().ForEach(x => _room.AddAmenity(x));
            }
            else
            {
                var room = new Room();
                room.RoomTierID = SelectedTier.ID;
                room.RoomNumber = _room.RoomNumber;
                room.PricePerDay = _room.PricePerDay;
                room.RoomState = _room.RoomState;
                room.RoomTierID = SelectedTier.ID;
                QuanLyKhachSan.Models.BLL.Service.RoomService.Add(room);
                SelectedAmenities.ToList().ForEach(x => QuanLyKhachSan.Models.BLL.Service.RoomService.AddAmenity(room.RoomID, x.ID));
            }
            IsSaved = true;
            CloseAction?.Invoke();
        }
    }
}
