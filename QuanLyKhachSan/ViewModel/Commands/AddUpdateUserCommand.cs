using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.ViewModel.EntityViewModels;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class AddUpdateUserCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private AddUpdateUserViewModel _addUpdateViewModel;

        public AddUpdateUserCommand(AddUpdateUserViewModel addUpdateViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _addUpdateViewModel = addUpdateViewModel;
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;

            addUpdateViewModel.User.PropertyChanged += OnViewModelPropertyChanged;
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
            if (e.PropertyName == nameof(UserViewModel.UserName) ||
                e.PropertyName == nameof(UserViewModel.Identity) ||
                e.PropertyName == nameof(UserViewModel.PhoneNumber) ||
                e.PropertyName == nameof(UserViewModel.Identity) ||
                e.PropertyName == nameof(UserViewModel.WorkingDate) )
            {
                OnCanExecuteChanged();
            }
        }
    }
}
