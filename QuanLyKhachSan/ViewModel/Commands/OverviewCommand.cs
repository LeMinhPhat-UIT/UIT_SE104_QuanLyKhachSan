using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.Service;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class OverviewCommand : BaseCommand
    {
        private readonly NavigateCommand _navigateCommand;
        public OverviewCommand(NavigationService navigationService) 
        {
            _navigateCommand = new NavigateCommand(navigationService);
        }

        public override void Execute(object? parameter)
        {
            _navigateCommand.Execute(parameter);
        }
    }
}
