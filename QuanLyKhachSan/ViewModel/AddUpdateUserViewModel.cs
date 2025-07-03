using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyKhachSan.Models.BLL.Helpers.Security;
using QuanLyKhachSan.Models.Core.Entities;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.ViewModel
{
    public class AddUpdateUserViewModel : BaseViewModel
    {
        private ObservableCollection<RoleViewModel> _roles;
        private UserViewModel _user;
        private RoleViewModel _selectedRole;
        private DateTime _selectedDate;


        public IEnumerable<RoleViewModel> Roles => _roles;
        public RoleViewModel SelectedRole { get => _selectedRole; set { _selectedRole = value; OnPropertyChanged(nameof(SelectedRole)); } }
        public bool IsSaved { get; set; } = false;
        public DateTime SelectedDate { get => _selectedDate; set { _selectedDate = value; OnPropertyChanged(nameof(SelectedDate)); } }
        public UserViewModel User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }

        public Action? CloseAction { get; set; }
        public ICommand Save { get; }
        public ICommand Close { get; }

        public AddUpdateUserViewModel()
        {
            _roles = new ObservableCollection<RoleViewModel>();
            QuanLyKhachSan.Models.BLL.Service.RoleService.GetAllData().ForEach(x => _roles.Add(new RoleViewModel(x)));
            _user = new UserViewModel();

            Save = new AddUpdateUserCommand(this, _ => SaveUser(), _ =>
            {
                return 
                    !string.IsNullOrWhiteSpace(_user.UserName) && !string.IsNullOrWhiteSpace(_user.Identity) &&
                    !string.IsNullOrWhiteSpace(_user.UserEmail) && !string.IsNullOrWhiteSpace(_user.PhoneNumber) &&
                    SelectedDate != null && SelectedRole != null;
            });
            Close = new AddUpdateUserCommand(this, _ => CloseAction?.Invoke());
        }

        private void SaveUser()
        {
            if(QuanLyKhachSan.Models.BLL.Service.UserService.GetByIdentity(_user.Identity) != null)
            {
                MessageBox.Show("This IdentityNumber has already existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            IsSaved = true;
            var user = new User();
            user.UserName = _user.UserName;
            user.IdentityNumber = _user.Identity;
            user.RoleID = SelectedRole.ID;
            user.WorkingDate = _user.WorkingDate.Date;
            user.EmailAddress = _user.UserEmail;
            user.PhoneNumber = _user.PhoneNumber;
            user.Password = "password123";
            QuanLyKhachSan.Models.BLL.Service.UserService.Add(user);
            _user.ID = user.UserID;
            CloseAction?.Invoke();
        }
    }
}
