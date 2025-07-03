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
        private readonly Func<object?, bool>? _canExecute;

        public NavigateCommand(NavigationService navigationService, Func<object?, bool>? canExecute = null)
        {
            _navigationService = navigationService;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
