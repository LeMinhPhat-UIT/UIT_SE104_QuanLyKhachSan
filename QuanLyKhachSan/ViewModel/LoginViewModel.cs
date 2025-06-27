using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuanLyKhachSan.ViewModel.Commands;
using QuanLyKhachSan.ViewModel.Service;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userID;
        private string _password;

        public string UserID { get => _userID; set {  _userID = value; OnPropertyChanged(); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; }

        public LoginViewModel(NavigationStore navigationStore, Func<OverviewViewModel> createOverviewViewModel)
        {
            LoginCommand = new LoginCommand(this, navigationStore, createOverviewViewModel);
        }

    }
}
