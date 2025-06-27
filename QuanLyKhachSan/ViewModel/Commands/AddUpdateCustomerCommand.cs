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
    class AddUpdateCustomerCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private AddUpdateCustomerViewModel _addUpdateViewModel;

        public AddUpdateCustomerCommand(AddUpdateCustomerViewModel addUpdateViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _addUpdateViewModel = addUpdateViewModel;
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;

            _addUpdateViewModel.Customer.PropertyChanged += OnViewModelPropertyChanged;
            _addUpdateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CustomerViewModel.IdentityNumber) ||
               e.PropertyName == nameof(CustomerViewModel.CustomerName) ||
               e.PropertyName == nameof(AddUpdateCustomerViewModel.SelectedCustomerTier) ||
               e.PropertyName == nameof(CustomerViewModel.PhoneNumber)
               )
            {
                OnCanExecuteChanged();
            }
        }
    }
}
