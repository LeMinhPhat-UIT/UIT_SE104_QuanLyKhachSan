using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewModel.Commands
{
    public class RevenueCommand : BaseCommand
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;
        private RevenueViewModel _revenueViewModel;

        public RevenueCommand(RevenueViewModel revenueViewModel, Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
            if (revenueViewModel != null)
            {
                _revenueViewModel = revenueViewModel;
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
    }
}
