   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuanLyKhachSan.UI.ViewsQuanLyKhachSan.UI.Views  5   	   +    %QuanLyKhachSan.UI.Views.AddRoomWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:QuanLyKhachSan.UI.Views  5   	     � Title$  AddRoomWindow��5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $	��400��5   	   $	��600��5   	   .��5      � .+�5   
   �� $	��600��5      $	��400��5      ���#FFFFFF �� CornerRadius$ 12��5       �� Padding$ 48, 24q�5      ._�5      �� $}�False��5      .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��22��5      $��22��5         Kind$ DeleteOutline=�5      $��Right=�5       � Cursor$
 Hand��5      $��0, -8, -24, 0q�5       �� 5"      $��Nhập thông tin phòng��5#      $��24(�5$      $��SemiBold"�5%      ���#1570EF$��0, -12, 0, 0q�5'      � 5)      $��0, 24, 0, 0q�5*       � ColumnDefinitions 5+      �� 5,      $��* �6+   �� 5-      $��* �6+   .+�50      �� $��0��51      .+�52      �� $��Số phòng:��53      $��14(�54      $��SemiBold"�55      �� 57      $	��230��58      $��35��59      ���#DCF1FF$
��Left=�5;      $ 8��5<      $
 8, 0q�5=      $��
0, 8, 0, 0q�5>      ._�5?      �� .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 	Collapsed=�5@   !   $��0q�5A   !   5B      5C      �� 5E      $��1��5F      $��Right=�5G      $��22, 0, 0, 0q�5H      .+�5I      �� $��Loại phòng:��5J      $��14(�5K      $��SemiBold"�5L      �� 5N      $	��230��5O      $��35��5P      ���#DCF1FF$ 8��5R      $
 8, 0q�5S      $��
0, 8, 0, 0q�5T      ._�5U      �� $	 	Collapsed=�5V   %   $��0q�5W   %   $��35��5X   %   5Y      5Z      5[      5\      � 5^      $��0, 24, 0, 0q�5_       5`      �� 5a      $��* �6+   �� 5b      $��* �6+   .+�5e      �� $��0��5f      .+�5g      �� $��Giá (VNĐ):��5h      $��14(�5i      $��SemiBold"�5j      �� 5l      $	��230��5m      $��35��5n      ���#DCF1FF$
��Left=�5p      $ 8��5q      $
 8, 0q�5r      $��
0, 8, 0, 0q�5s      ._�5t      �� $	 	Collapsed=�5u   !   $��0q�5v   !   5w      5x      �� 5z      $��1��5{      $��Right=�5|      .+�5}      �� $��Tình trạng:��5~      $��14(�5      $��SemiBold"�5�      �� 5�      $	��230��5�      $��35��5�      ���#DCF1FF$
��Left=�5�      $ 8��5�      $
 8, 0q�5�      $��
0, 8, 0, 0q�5�      ._�5�      �� $	 	Collapsed=�5�   !   $��0q�5�   !   $��35��5�   !   5�      5�      5�      5�      �� 5�      $��0��5�      $��0, 24, 0, 0q�5�      .+�5�      �� $��Cơ sở vật chất:��5�      $��14(�5�      $��SemiBold"�5�      �� 5�      $	��504��5�      $��35��5�      ���#DCF1FF$
��Left=�5�      $ 8��5�      $
 8, 0q�5�      $��
0, 8, 0, 0q�5�      ._�5�      �� $	 	Collapsed=�5�      $��0q�5�      $��35��5�      5�      5�      5�      �� 5�         BlueButtonStyle#���   5�      $
��Lưu��5�      $��80��5�      $��35��5�      $��Right=�5�      $��4q�5�      $
 Hand��5�      $��0, 24, 0, 0q�5�      5�      5�      5�      5�      