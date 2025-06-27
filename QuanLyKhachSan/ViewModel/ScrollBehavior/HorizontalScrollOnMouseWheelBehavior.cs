using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace QuanLyKhachSan.ViewModel.ScrollBehavior
{
    public class HorizontalScrollOnMouseWheelBehavior
    {
        public static bool GetEnableHorizontalScroll(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableHorizontalScrollProperty);
        }

        public static void SetEnableHorizontalScroll(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableHorizontalScrollProperty, value);
        }

        public static readonly DependencyProperty EnableHorizontalScrollProperty =
            DependencyProperty.RegisterAttached("EnableHorizontalScroll", typeof(bool),
                typeof(HorizontalScrollOnMouseWheelBehavior),
                new UIPropertyMetadata(false, OnEnableHorizontalScrollChanged));

        private static void OnEnableHorizontalScrollChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ScrollViewer scrollViewer)
            {
                if ((bool)e.NewValue)
                {
                    scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
                }
                else
                {
                    scrollViewer.PreviewMouseWheel -= ScrollViewer_PreviewMouseWheel;
                }
            }
        }

        private static void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is ScrollViewer scrollViewer)
            {
                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta);
                e.Handled = true;
            }
        }
    }
}
