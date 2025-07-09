using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.Models.BLL;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.UI.Views.SubViews;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Service;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel
{
    public class LoadRoomListButton : BaseViewModel
    {
        private bool _isChecked;

        public string Label { get; set; }
        public bool IsChecked { get => _isChecked; set { _isChecked = value; OnPropertyChanged(nameof(IsChecked)); } }
        public ICommand Command { get; set; }

        public LoadRoomListButton(RoomTierViewModel? roomTierViewModel, Action<object?> execute)
        {
            if (roomTierViewModel == null)
            {
                Label = "Tất cả";
                IsChecked = true;
                Command = new BookingCommand(null, execute);
            }
            else
            {
                Label = roomTierViewModel.RoomTierName;
                IsChecked = false;
                Command = new BookingCommand(null, execute);
            }
        }
    }

    public class BookingViewModel : BaseViewModel
    {
        private UserViewModel _userViewModel;
        private ObservableCollection<RoomViewModel> _rooms;
        private ObservableCollection<LoadRoomListButton> _loadRooms;
        private ObservableCollection<CustomerViewModel> _customers;
        private RoomViewModel _selectedRoom;
        private ReservationViewModel _reservation;
        private InvoiceViewModel _invoice;
        private readonly SidebarCommand _sidebarCommand;
        private int _adults;
        private int _kids;
        private RuleViewModel _rule;


        public UserViewModel User => _userViewModel;
        public IEnumerable<CustomerViewModel> Customers => _customers;
        public IEnumerable<RoomViewModel> Rooms => _rooms;
        public IEnumerable<LoadRoomListButton> LoadRoomButtons => _loadRooms;
        public RoomViewModel SelectedRoom { get => _selectedRoom; set { _selectedRoom = value; OnPropertyChanged(nameof(SelectedRoom)); UpdateTotal(); } }
        public ReservationViewModel Reservation { get => _reservation; set { _reservation = value; OnPropertyChanged(nameof(Reservation)); UpdateTotal(); } }
        public InvoiceViewModel Invoice { get => _invoice; set { OnPropertyChanged(nameof(Invoice)); } }
        public int Adults { get => _adults; set { _adults = value; OnPropertyChanged(nameof(Adults)); OnPropertyChanged(nameof(CustomersCount)); } }
        public int Kids { get => _kids; set { _kids = value; OnPropertyChanged(nameof(Kids)); OnPropertyChanged(nameof(CustomersCount)); } }
        public int CustomersCount => Adults + Kids;


        public ICommand AdultsIncrease { get; }
        public ICommand AdultsDecrease { get; }
        public ICommand KidsIncrease { get; }
        public ICommand KidsDecrease { get; }
        public ICommand CustomerAdd { get; }
        public ICommand Checked { get; }
        public ICommand Save { get; }

        public SidebarCommand SidebarCommand => _sidebarCommand;
        public BookingViewModel(NavigationStore navigationStore)
        {
            _sidebarCommand = new SidebarCommand(navigationStore);
            _userViewModel = navigationStore.User;
            _customers = new ObservableCollection<CustomerViewModel>();
            _reservation = new ReservationViewModel();
            _rooms = new ObservableCollection<RoomViewModel>();
            _loadRooms = new ObservableCollection<LoadRoomListButton>();
            _invoice = new InvoiceViewModel(_selectedRoom, _reservation);
            _rule = new RuleViewModel(QuanLyKhachSan.Models.BLL.Service.RuleService.GetById(1));

            var roomList = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData().Where(x => x.RoomState == "Available").ToList();
            roomList.ForEach(room => {
                var roomViewModel = new RoomViewModel(room);
                _rooms?.Add(roomViewModel);
            });
            _loadRooms?.Add(new LoadRoomListButton(null, _ => this.LoadRoomByTier("Tất cả")));

            var roomTierList = QuanLyKhachSan.Models.BLL.Service.RoomTierService.GetAllData();
            roomTierList.ForEach(roomTier => _loadRooms?.Add(
                new LoadRoomListButton(new RoomTierViewModel(roomTier), _ => this.LoadRoomByTier(roomTier.RoomTierName)))
            );

            AdultsIncrease = new BookingCommand(this, _ => { Adults++; UpdateInvoice(); }, _ => CustomersCount < _rule.RoomMaxCustomer);
            AdultsDecrease = new BookingCommand(this, _ => { Adults = Math.Max(0, --Adults); UpdateInvoice(); });

            KidsIncrease = new BookingCommand(this, _ => { Kids++; UpdateInvoice(); }, _ => CustomersCount < _rule.RoomMaxCustomer);
            KidsDecrease = new BookingCommand(this, _ => { Kids = Math.Max(0, --Kids); UpdateInvoice(); });

            CustomerAdd = new BookingCommand(this, _ => OpenAndAddCustomer(), _ => _customers.Count < CustomersCount);

            Save = new BookingCommand(this, _ => AddReservationAndInvoice(), _ => _invoice.Total != 0);

            Checked = new BookingCommand(this, (object isChecked) => HasForeignCustomerCheck((bool)isChecked));
        }

        private void HasForeignCustomerCheck(bool isChecked)
        {
            if (isChecked)
                _invoice.Coef = 1.5;
            else _invoice.Coef = 1;
            UpdateTotal();
        }

        private void AddReservationAndInvoice()
        {
            var reservation = new Reservation()
            {
                UserID = User.ID,
                RoomID = SelectedRoom.RoomID,
                CheckInDate = Reservation.CheckIn,
                CheckOutDate = Reservation.CheckOut,
                Status = "Pending",
                CustomersCount = CustomersCount,
            };
            var invoice = new Invoice()
            {
                ReportID = null,
                UserID = User.ID,
                InvoiceDate = Reservation.CheckOut,
                SurchargeRate = Invoice.SurchargeRate,
                Coef = (decimal)Invoice.Coef,
                TotalAmount = (decimal)Invoice.Total,
                Status = Invoice.Status,
                PaymentMethod = ""
            };
            QuanLyKhachSan.Models.BLL.Service.ReservationService.Add(reservation);
            _customers.ToList().ForEach(x => QuanLyKhachSan.Models.BLL.Service.ReservationService.AddCustomer(reservation.ReservationID, x.ID));

            invoice.ReservationID = reservation.ReservationID;
            QuanLyKhachSan.Models.BLL.Service.InvoiceService.Add(invoice);

            var room = QuanLyKhachSan.Models.BLL.Service.RoomService.GetById(SelectedRoom.RoomID);
            room.RoomState = "Occupied";
            QuanLyKhachSan.Models.BLL.Service.RoomService.Update(room);
            _rooms.Remove(SelectedRoom);
            _reservation = new ReservationViewModel();
            _customers.Clear();
            _invoice = new InvoiceViewModel(_selectedRoom, _reservation);
            OnPropertyChanged(nameof(Invoice));
        }

        private void OpenAndAddCustomer()
        {
            var viewmodel = new AddUpdateCustomerViewModel();
            var addUpdateCustomerWindow = new AddUpdateCustomerWindow()
            {
                DataContext = viewmodel,
            };
            viewmodel.CloseAction = () => addUpdateCustomerWindow.Close();
            addUpdateCustomerWindow.ShowDialog();
            if (viewmodel.Customer.ID != 0 && _customers.FirstOrDefault(x => x.ID == viewmodel.Customer.ID) == null)
            {
                _customers?.Add(viewmodel.Customer);
                if (viewmodel.Customer.CustomerTierName == "Nước ngoài")
                    _invoice.Coef = 1.5;
                if (_customers?.Count >= _rule.CustomerToApplySurchargeRate)
                    _invoice.SurchargeRate = _rule.SurchargeRate;
                UpdateTotal();
            }
        }

        private void LoadRoomByTier(string? roomTierName = null)
        {
            _rooms.Clear();
            var roomList = QuanLyKhachSan.Models.BLL.Service.RoomService.GetAllData().Where(x => x.RoomState == "Available").ToList();
            if (!string.IsNullOrEmpty(roomTierName) && roomTierName != "Tất cả")
                roomList.ForEach(room => {
                    var roomViewModel = new RoomViewModel(room);
                    if (roomViewModel.RoomTierName == roomTierName)
                        _rooms.Add(roomViewModel);
                });
            else
                roomList.ForEach(room => {
                    var roomViewModel = new RoomViewModel(room);
                    _rooms.Add(roomViewModel);
                });
            _loadRooms.ToList().ForEach(x => x.IsChecked = x.Label == roomTierName);
        }

        private void UpdateTotal()
        {
            if (_selectedRoom != null && _reservation != null)
                Invoice.Total = (double)SelectedRoom.PricePerDay * Reservation.Nights * (100 + Invoice.SurchargeRate) * Invoice.Coef / 100;
        }

        private void UpdateInvoice()
        {
            if (CustomersCount >= _rule.RoomMaxCustomer)
                _invoice.SurchargeRate = _rule.SurchargeRate;
            else
                _invoice.SurchargeRate = 0;
            UpdateTotal();
        }
    }
}
