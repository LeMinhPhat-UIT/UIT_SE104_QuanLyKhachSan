   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuanLyKhachSan.UI.ViewsQuanLyKhachSan.UI.Views  5   	   .    (QuanLyKhachSan.UI.Views.RoomDetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:QuanLyKhachSan.UI.Views  5   	     � Title$  RoomDetailWindow��5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $	��400��5   	   $	��600��5   	   .��5      � .+�5   
   �� $	��600��5      $	��400��5      ���#FFFFFF �� CornerRadius$ 12��5       �� Padding$ 48, 24q�5      ._�5      �� $}�False��5      .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��22��5      $��22��5         Kind$ DeleteOutline=�5      $��Right=�5       � Cursor$
 Hand��5      $��0, -8, -24, 0q�5       �� 5"      $#��Nhập thông tin nhân viên��5#      $��24(�5$      $��SemiBold"�5%      ���#1570EF$��0, -12, 0, 0q�5'      � 5)      $��0, 24, 0, 0q�5*       � ColumnDefinitions 5+      �� 5,      $��* �6+   �� 5-      $��* �6+   .+�50      �� $��0��51      .+�52      �� $��	Check in:��53      $��14(�54      $��SemiBold"�55      �� 57      $	��230��58      $��35��59      ���#DCF1FF$
��Left=�5;      $ 8��5<      $
 8, 0q�5=      $��
0, 8, 0, 0q�5>      ._�5?      (  "System.Windows.Controls.DatePicker  .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 	Collapsed=�5@   !   $��0q�5A   !   $��Center=�5B   !   5C      5D      �� 5F      $��1��5G      $��Right=�5H      .+�5I      �� $��
Check out:��5J      $��14(�5K      $��SemiBold"�5L      �� 5N      $	��230��5O      $��35��5P      ���#DCF1FF$
��Left=�5R      $ 8��5S      $
 8, 0q�5T      $��
0, 8, 0, 0q�5U      ._�5V        $	 	Collapsed=�5W   !   $��0q�5X   !   $��Center=�5Y   !   5Z      5[      5\      �� 5`      $��0��5a      $��0, 18, 0, 0q�5b      .+�5c      �� $��Khách hàng:��5d      $��14(�5e      $��SemiBold"�5f      &   System.Windows.Controls.DataGrid  5h      $��1��5i   !   $	��504��5j   !   $	��130��5k   !   ���#F7F9FC-  'MaterialDesignThemes.Wpf.DataGridAssist
   CornerRadius$
 12��5n   !      SelectionUnit$ FullRow=�5o   !      AutoGenerateColumns$ False��5p   !      HeadersVisibility$ Column=�5q   !      CanUserAddRows$ False��5r   !      
IsReadOnly$
 True��5s   !      	RowHeight$ 50Q�5t   !      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5u   !   $��
0, 8, 0, 0q�5v   !   ��5m   !   ��    	CellStyle 5x      �� 5y       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$    �� BasedOn# [B 6>   .�5z   "   ��  �� Property � �� �� Value$ 0q�6D   �� 5{   "    � ��$ 14(�6=   �� 5|   "    � ��
 �   �6?   5}         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Họ và tên��61    	  Width$ * 6`   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6D   �� *	SoPhong+6`     5�      $
 CCCD��61   $ * 6]    6?   �� *	LoaiPhong+6]     5�      $ Ghi chú��61   $ * 6k    6B   �� *Gia+ �� StringFormat$ N0��6k   5�      5�      �� 5�         BlueButtonStyle#���   5�      $
��Lưu��5�      $��80��5�      $��35��5�      $��Right=�5�      $��4q�5�      $
 Hand��5�      $��0, 18, 0, 0q�5�      5�      5�      5�      5�      