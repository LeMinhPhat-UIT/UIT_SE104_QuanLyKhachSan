using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel.EntityViewModels;
using QuanLyKhachSan.ViewModel.Service;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class BookingCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private BookingViewModel _bookingViewModel;

        public BookingCommand(BookingViewModel bookingViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
            if(bookingViewModel != null)
            {
                _bookingViewModel = bookingViewModel;
                _bookingViewModel.PropertyChanged += OnViewModelPropertyChanged;
                _bookingViewModel.Invoice.PropertyChanged += OnViewModelPropertyChanged;
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
                e.PropertyName == nameof(InvoiceViewModel.Total))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
