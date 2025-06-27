using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel;

namespace QuanLyKhachSan_BackUp.ViewModel.Commands
{
    public class RoomDetailCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private RoomDetailViewModel _roomDetailViewModel;


        public RoomDetailCommand(RoomDetailViewModel roomDetailViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null) 
        {
            _canExecute = canExecute;
            _roomDetailViewModel = roomDetailViewModel;
            _execute = execute;
        }
        public override void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
    }
}
