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
    public class InvoiceCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private InvoiceWViewModel _invoiceWViewModel;

        public InvoiceCommand(InvoiceWViewModel invoiceWViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
            if (invoiceWViewModel != null)
            {
                _invoiceWViewModel = invoiceWViewModel;
                _invoiceWViewModel.Invoice.PropertyChanged += OnViewModelPropertyChanged;
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

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(InvoiceViewModel.PaymentMethod))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
