using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyKhachSan.UI.Utilities
{
    public class DeleteDialogHelper
    {
        public static MessageBoxResult Warning()
        {
            return MessageBox.Show(
                @"This may cause null values or cascade deletions in tables that reference this table.
Are you sure you want to delete this record?
                ", 
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
        public static void RestrictWarning()
        {
            MessageBox.Show(
                @"Cannot delete this record because it is referenced by another record.",
                "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
    }
}
