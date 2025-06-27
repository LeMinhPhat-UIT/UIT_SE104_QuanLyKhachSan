using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.UI.Views.SubViews;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel
{
    public class UserWViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        private UserViewModel _user;
        private SidebarCommand _sidebarCommand;
        private ObservableCollection<UserViewModel> _users;
        private UserViewModel _selectedUser;
        private string _searchingIdentity;

        public IEnumerable<UserViewModel> Users => _users;
        public UserViewModel User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public UserViewModel SelectedUser { get => _selectedUser; set { _selectedUser = value; OnPropertyChanged(nameof(SelectedUser)); } }
        public string SearchingIdentity { get => _searchingIdentity; set { _searchingIdentity = value; OnPropertyChanged(nameof(SearchingIdentity)); } }
        public SidebarCommand SidebarCommand => _sidebarCommand;

        public ICommand UserAdd { get; }
        public ICommand UserDelete { get; } 
        public ICommand Search { get; }

        public UserWViewModel(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
            _user = navigationStore.User;
            _sidebarCommand = new SidebarCommand(navigationStore);

            _users = new ObservableCollection<UserViewModel>();
            QuanLyKhachSan.Models.BLL.Service.UserService.GetAllData().ForEach(x => _users.Add(new UserViewModel(x)));
            _users.Remove(_users.First(x => x.ID == User.ID));

            UserAdd = new UserCommand(this, _ => OpenAddUserWindow());
            UserDelete = new UserCommand(this, _ => DeleteUser());
            Search = new UserCommand(this, _ => SearchUserByIdentity());
        }

        private void SearchUserByIdentity()
        {
            var userList = QuanLyKhachSan.Models.BLL.Service.UserService.GetAllData().Where(x => x.IdentityNumber.Contains(SearchingIdentity) && x.UserID!=User.ID).ToList();
            _users.Clear();
            if (string.IsNullOrWhiteSpace(SearchingIdentity))
            {
                QuanLyKhachSan.Models.BLL.Service.UserService.GetAllData().ForEach(x => _users.Add(new UserViewModel(x)));
                _users.Remove(_users.First(x => x.ID == User.ID));
                return;
            }
            userList.ForEach(x => _users.Add(new UserViewModel(x)));
        }

        private void DeleteUser()
        {
            QuanLyKhachSan.Models.BLL.Service.UserService.Delete(SelectedUser.ID);
            _users.Remove(SelectedUser);
            SelectedUser = new UserViewModel();
        }

        private void OpenAddUserWindow()
        {
            var viewmodel = new AddUpdateUserViewModel();
            var addUpdateUserWindow = new AddUpdateStaffWindow()
            {
                DataContext = viewmodel,
            };
            viewmodel.CloseAction = () => addUpdateUserWindow.Close();
            addUpdateUserWindow.ShowDialog();
            if (viewmodel.IsSaved)
                _users.Add(viewmodel.User);
        }
    }
}
