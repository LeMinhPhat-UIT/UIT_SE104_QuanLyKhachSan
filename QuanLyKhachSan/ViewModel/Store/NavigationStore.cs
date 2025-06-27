using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.ViewModel.Store
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        private UserViewModel _user;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set 
            {
                _currentViewModel = value; 
                OnCurrentViewModelChanged();
            }
        }

        public UserViewModel User { get => _user; set => _user = value; }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged() 
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
