using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using QuanLyKhachSan.Models.BLL.Helpers.Security;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Service;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel.Commands
{
    class LoginCommand : BaseCommand
    {
        private LoginViewModel _loginViewModel;
        private NavigateCommand _navigateCommand;
        private NavigationStore _navigationStore;

        public override bool CanExecute(object? parameter)
        {
            if (!string.IsNullOrWhiteSpace(_loginViewModel.UserID) && !string.IsNullOrWhiteSpace(_loginViewModel.Password))
                if (int.TryParse(_loginViewModel.UserID, out int UserID))
                    return true;
            return false;
        }

        public override void Execute(object? parameter)
        {
            LoginResult loginResult = LoginService.Login(Convert.ToInt32(_loginViewModel.UserID), _loginViewModel.Password);
            if (!loginResult.Success)
                MessageBox.Show(loginResult.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else 
            {
                _navigationStore.User = loginResult.User;
                _navigateCommand.Execute(null); 
            }
        }

        public LoginCommand(LoginViewModel loginViewModel, NavigationStore navigationStore, Func<OverviewViewModel> createOverviewViewModel)
        {
            _loginViewModel = loginViewModel;
            _navigationStore = navigationStore;
            _navigateCommand = new NavigateCommand(new NavigationService(navigationStore, createOverviewViewModel));

            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(LoginViewModel.UserID) || 
               e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
