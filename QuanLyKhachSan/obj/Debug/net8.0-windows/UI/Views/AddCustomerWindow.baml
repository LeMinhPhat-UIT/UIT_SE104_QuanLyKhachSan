   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuanLyKhachSan.UI.ViewsQuanLyKhachSan.UI.Views  5   	   /    )QuanLyKhachSan.UI.Views.AddCustomerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:QuanLyKhachSan.UI.Views  5   	     � Title$  AddCustomerWindow��5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $	��400��5   	   $	��600��5   	   .��5      � .+�5   
   �� $	��600��5      $	��316��5      ���#FFFFFF �� CornerRadius$ 12��5       �� Padding$ 48, 24q�5      ._�5      �� $}�False��5      .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��22��5      $��22��5         Kind$ DeleteOutline=�5      $��Right=�5       � Cursor$
 Hand��5      $��0, -8, -24, 0q�5       �� 5"      $$��Nhập thông tin khách hàng��5#      $��24(�5$      $��SemiBold"�5%      ���#1570EF$��0, -12, 0, 0q�5'      � 5)      $��0, 24, 0, 0q�5*       � ColumnDefinitions 5+      �� 5,      $��* �6+   �� 5-      $��* �6+   .+�50      �� $��0��51      .+�52      �� $��Họ và tên:��53      $��14(�54      $��SemiBold"�55      �� 57      $	��230��58      $��35��59      ���#DCF1FF$
��Left=�5;      $ 8��5<      $
 8, 0q�5=      $��
0, 8, 0, 0q�5>      ._�5?      �� .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 	Collapsed=�5@   !   $��0q�5A   !   5B      5C      �� 5E      $��1��5F      $��Right=�5G      .+�5H      �� $��Loại khách hàng:��5I      $��14(�5J      $��SemiBold"�5K      �� 5L      $	��230��5M      $��35��5N      ���#DCF1FF$
��Left=�5P      $ 8��5Q      $
 8, 0q�5R      $��
0, 8, 0, 0q�5S      ._�5T      �� $	 	Collapsed=�5U   "   $��0q�5V   "   $��35��5W   "   5X      5Y      5Z      5[      � 5]      $��0, 24, 0, 0q�5^       5_      �� 5`      $��* �6+   �� 5a      $��* �6+   .+�5d      �� $��0��5e      .+�5f      �� $��CCCD:��5g      $��14(�5h      $��SemiBold"�5i      �� 5k      $	��230��5l      $��35��5m      ���#DCF1FF$
��Left=�5o      $ 8��5p      $
 8, 0q�5q      $��
0, 8, 0, 0q�5r      ._�5s      �� $	 	Collapsed=�5t   !   $��0q�5u   !   5v      5w      �� 5y      $��1��5z      $��Right=�5{      .+�5|      �� $��Số điện thoại:��5}      $��14(�5~      $��SemiBold"�5      �� 5�      $	��230��5�      $��35��5�      ���#DCF1FF$
��Left=�5�      $ 8��5�      $
 8, 0q�5�      $��
0, 8, 0, 0q�5�      ._�5�      �� $	 	Collapsed=�5�   !   $��0q�5�   !   5�      5�      5�      �� 5�         BlueButtonStyle#���   5�      $
��Lưu��5�      $��80��5�      $��35��5�      $��Right=�5�      $��4q�5�      $
 Hand��5�      $��0, 24, 0, 0q�5�      5�      5�      5�      5�      