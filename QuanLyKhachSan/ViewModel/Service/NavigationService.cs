using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel.Service
{
    public class NavigationService
    {
        private NavigationStore _navigateStore;
        private Func<BaseViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<BaseViewModel> createViewModel)
        {
            _navigateStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigateStore.CurrentViewModel = _createViewModel();
        }
    }
}
