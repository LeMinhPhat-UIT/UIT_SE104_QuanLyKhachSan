using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Service;
using QuanLyKhachSan.ViewModel.Store;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class NavigateCommand : BaseCommand
    {
        private NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
