using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class RoomCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private RoomWViewModel _roomWViewModel;

        public RoomCommand(RoomWViewModel roomWViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
            if (roomWViewModel != null)
            {
                _roomWViewModel = roomWViewModel;
                _roomWViewModel.PropertyChanged += OnViewModelPropertyChanged;
                _roomWViewModel.SelectedRoom.PropertyChanged += OnViewModelPropertyChanged;
                
            }

        }

        public override void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        // Cho phép ViewModel gọi để cập nhật CanExecute (nếu cần)
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BookingViewModel.CustomersCount) ||
                e.PropertyName == nameof(InvoiceViewModel.Total) || 
                e.PropertyName == nameof(RoomViewModel.RoomState) || 
                e.PropertyName == nameof(RoomWViewModel.SelectedRoom))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
