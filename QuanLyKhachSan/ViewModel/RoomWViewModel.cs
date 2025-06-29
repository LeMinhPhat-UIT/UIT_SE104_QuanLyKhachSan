using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyKhachSan.UI.Views.SubViews;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Store;
using QuanLyKhachSan_BackUp.ViewModel.Commands;

namespace QuanLyKhachSan.ViewModel
{
    public class LoadRoomButton : BaseViewModel
    {
        private bool _isChecked;
        private string _label;
        private string _key;

        public string Label { get => _label; set { _label = value; OnPropertyChanged(nameof(Label)); } }
        public string Key { get => _key; set { _key = value; OnPropertyChanged(nameof(Key)); } }
        public bool IsChecked { get => _isChecked; set { _isChecked = value; OnPropertyChanged(nameof(IsChecked)); } }
        public ICommand Command { get; set; }

        public LoadRoomButton(string? roomState, string label, Action<object?> execute)
        {
            Key = roomState;
            Label = label;
            IsChecked = false;
            Command = new RoomCommand(null, execute);
        }
    }

    public class RoomWViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly UserViewModel _userViewModel;
        private readonly SidebarCommand _sidebarCommand;
        private ObservableCollection<RoomViewModel> _rooms;
        private ObservableCollection<LoadRoomButton> _loadRooms;
        private RoomViewModel _selectedRoom;

        public UserViewModel User => _userViewModel;
        public RoomViewModel SelectedRoom { get => _selectedRoom; set { _selectedRoom = value; OnPropertyChanged(nameof(SelectedRoom)); } }
        public SidebarCommand SidebarCommand => _sidebarCommand;
        public IEnumerable<RoomViewModel> Rooms => _rooms;
        public IEnumerable<LoadRoomButton> LoadRooms => _loadRooms;


        public ICommand AllRooms;
        public ICommand AvailableRooms;
        public ICommand OccupiedRooms;
        public ICommand RoomAdd { get; }
        public ICommand RoomUpdate { get; }
        public ICommand RoomDelete { get; }
        public ICommand ShowDetail { get; }

        public RoomWViewModel(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
            _selectedRoom = new RoomViewModel();
            _sidebarCommand = new SidebarCommand(navigationStore);
            _rooms = new ObservableCollection<RoomViewModel>();
            _loadRooms = new ObservableCollection<LoadRoomButton>();
            _userViewModel = navigationStore.User;

            var roomList = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData();
            roomList.ForEach(room => {
                var roomViewModel = new RoomViewModel(room);
                _rooms?.Add(roomViewModel);
            });

            UpdateLoadRoomButtons();

            RoomAdd = new RoomCommand(this, _ => OpenAndAddRoom(), _ => User.UserRole == "Administrator");

            RoomUpdate = new RoomCommand(this, _ => OpenAndUpdateRoom(), _ => User.UserRole == "Administrator");

            RoomDelete = new RoomCommand(this, _ => DeleteRoom(), _ => User.UserRole == "Administrator");

            ShowDetail = new RoomCommand(this, _ => OpenRoomDetail(), _ => SelectedRoom!=null && SelectedRoom.RoomState == "Occupied");
        }

        private void OpenRoomDetail()
        {
            var reservations = QuanLyKhachSan.Models.BLL.Service.RoomService.GetReservations(SelectedRoom.RoomID);
            var reservationViewModel = new ReservationViewModel(reservations[reservations.Count - 1]);
            var viewmodel = new RoomDetailViewModel(reservationViewModel);
            var roomDetailWindow = new RoomDetailWindow()
            {
                DataContext = viewmodel,
            };
            viewmodel.CloseAction = () => roomDetailWindow.Close();
            roomDetailWindow.ShowDialog();
        }

        private void UpdateLoadRoomButtons()
        {
            _loadRooms.Clear();

            var roomList = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData();

            _loadRooms.Add(new LoadRoomButton(null, $"Tất cả ({roomList.Count})", _ => LoadRoomByState()) { IsChecked = true });
            _loadRooms.Add(new LoadRoomButton("Available", $"Trống ({roomList.Count(x => x.RoomState == "Available")})", _ => LoadRoomByState("Available")));
            _loadRooms.Add(new LoadRoomButton("Occupied", $"Đã đặt ({roomList.Count(x => x.RoomState == "Occupied")})", _ => LoadRoomByState("Occupied")));

            OnPropertyChanged(nameof(LoadRooms));
        }

        private void DeleteRoom()
        {
            QuanLyKhachSan.Models.BLL.Service.RoomService.Delete(SelectedRoom.RoomID);
            _rooms.Remove(SelectedRoom);
            SelectedRoom = new RoomViewModel();
            UpdateLoadRoomButtons();
        }

        private void OpenAndAddRoom()
        {
            var viewmodel = new AddUpdateRoomViewModel();
            var addUpdateRoomWindow = new AddUpdateRoomWindow()
            {
                DataContext = viewmodel
            };
            viewmodel.CloseAction = () => addUpdateRoomWindow.Close();
            addUpdateRoomWindow.ShowDialog();
            if (viewmodel.IsSaved && SelectedRoom.RoomID==0)
            {
                _rooms.Add(viewmodel.Room);
                UpdateLoadRoomButtons();
            }
            else OnPropertyChanged(nameof(Rooms));
        }

        private void OpenAndUpdateRoom()
        {
            var viewmodel = new AddUpdateRoomViewModel(SelectedRoom);
            var addUpdateRoomWindow = new AddUpdateRoomWindow()
            {
                DataContext = viewmodel
            };
            viewmodel.CloseAction = () => addUpdateRoomWindow.Close();
            addUpdateRoomWindow.ShowDialog();
            if (viewmodel.IsSaved && SelectedRoom.RoomID == 0)
            {
                _rooms.Add(viewmodel.Room);
                UpdateLoadRoomButtons();
            }
            else OnPropertyChanged(nameof(Rooms));
        }

        private void LoadRoomByState(string? roomState = null)
        {
            if(roomState == null)
            {
                var roomList = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData();
                roomList.ForEach(room => _rooms.Add(new RoomViewModel(room)));
            }
            else
            {
                _rooms?.Clear();
                var roomList = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData();
                roomList.Where(room => room.RoomState == roomState).ToList().ForEach(room => _rooms.Add(new RoomViewModel(room)));
            }
            LoadRooms.ToList().ForEach(x => x.IsChecked = roomState == x.Key);
        }
    }
}
