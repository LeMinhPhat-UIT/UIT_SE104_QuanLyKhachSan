   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuanLyKhachSan.UI.ViewsQuanLyKhachSan.UI.Views  5   	   (    "QuanLyKhachSan.UI.Views.RoomWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:QuanLyKhachSan.UI.Views  5   	     � Title$  
RoomWindow��5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�5   	   $	��800��5   	   $
��1280��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   � -   5         �Name$ 
grdSideBar��5   	   $��0q�5   	   $	��800��5   	   $	��256��5   	   $
��Left=�5   	   $	��Top=�5   	    � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $
��Auto �6    .+�5"      �� $��0��5#      $��Center=�5$      $	��Top=�5%      $��Ehotel��5&      $��42(�5'      $5��/pack://application:,,,/Resources/Fonts/#Lobster)�5(      ���#1366D9 � Cursor$
 Hand��5*      $��0, 22, 0, 0q�5+      �� 5-      -   5         ��Name$ spMenu��5.      $��1��5/      $��Center=�50      $	��Top=�51      $	��196��52      $��0q�53      .+�55      d�    SidebarToggleButtonStyle#��[  56      $��Tổng quan��57      
	 � Tag$	 HomeOutline��58      $
 Hand��59      d� 5;      #��[  5<      $��Đặt phòng��5=      $	 ShapePlusOutline��5>      $
 Hand��5?      $��
0, 8, 0, 0q�5@      d� 5B      #��[  5C      $��Phòng��5D      $	 
BedOutline��5E      $
 Hand��5F      
 d� 	IsChecked$

 TrueY�5G      $��
0, 8, 0, 0q�5H      d� 5J      #��[  5K      $��Phiếu thuê��5L      $	 TicketOutline��5M      $
 Hand��5N      $��
0, 8, 0, 0q�5O      d� 5Q      #��[  5R      $��	Doanh thu��5S      $	 ChartBellCurveCumulative��5T      $
 Hand��5U      $��
0, 8, 0, 0q�5V      d� 5X      #��[  5Y      $��Nhân viên��5Z      $	 AccountGroupOutline��5[      $
 Hand��5\      $��
0, 8, 0, 0q�5]      5^      5`      � 5b   
   -   5        $ gridHome��5c   	   $��1��5d   	   $
��Left=�5e   	   $	��Top=�5f   	   $	��800��5g   	   $
��1024��5h   	   $��0q�5i   	    5k      �� 5l      $	��100 �6    �� 5m      $
��Auto �6    .+�5p      � -   5        $ 	grdHeader��5q      $��0��5r      $
��Left=�5s      $	��Top=�5t      $	��100��5u      $
��1024��5v      .+�5x      ��  �� Orientation$ 
Horizontal=�5y      $��Right=�5z      $��Center=�5{      .+�5}      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ BellOutline=�5~      $��32��5      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 14, 0q�5�        5�      $ EmailOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 32, 0q�5�      �� 5�      $��Right=�5�      $��Center=�5�       �� CornerRadius$ 18��5�      ���#A1C7FF$	��320��5�      $��70��5�       �� Padding$
 12,8q�5�      $��0,0,16,0q�5�      $
 Hand��5�      ._�5�      �� $ 
Horizontal=�5�      .+�5�      A� $��52��5�   !   $��52��5�   !   $��Center=�5�   !   ��5�   "   �� 5�   &    �� ImageSource$9 3pack://application:,,,/Resources/Images/meomeo.webp��61   5�      �� 5�      $��Center=�5�   !   $��16, 0, 0, 0q�5�   !   .+�5�   "   �� $��Adminstrator:��5�   %   $��Center=�5�   %   $��14(�5�   %   $��SemiBold"�5�   %   �� 5�   "   $��user@example.com��5�   %   $��Center=�5�   %   $��16(�5�   %   $��SemiBold"�5�   %   5�      5�      5�      5�      5�      � 5�      -   5        $ grdBody��5�      $��1��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      ���#DFDFDF.+�5�      �� -   5        $ spBody��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      .+�5�      �� $	��992��5�      $	��645��5�      ���#FFFFFF$��Center=�5�      $ 12��5�      $ 16q�5�      $��0, 16, 0, 0q�5�      ._�5�      �  5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��* �60   .+�5�      � $��0��5�   !    5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   .+�5�   "   �� $��0��5�   %   $ 
Horizontal=�5�   %   .+�5�   &   d�   OutlinedToggleButtonStyle#���  5�   )   $��Tất cả (200)��5�   )   $

 TrueY�5�   )   $��
0, 0, 8, 0q�5�   )   d� 5�   &   #���  5�   )   $��Phòng trống (200)��5�   )   $��
0, 0, 8, 0q�5�   )   d� 5�   &   #���  5�   )   $��Đã đặt (200)��5�   )   $��
0, 0, 8, 0q�5�   )   5�   #   �� 5�   "   $��1��5�   %     BlueButtonStyle#���  5�   %   $��Thêm phòng��5�   %   $
 Hand��5�   %   $��Right=�5�   %   5�      &   System.Windows.Controls.DataGrid  5      $��1��5  !   ���#F7F9FC-  'MaterialDesignThemes.Wpf.DataGridAssist   CornerRadius$ 12��5  !      SelectionUnit$ FullRow=�5  !      AutoGenerateColumns$ False��5  !      HeadersVisibility$ Column=�5  !      CanUserAddRows$ False��5  !      
IsReadOnly$
 True��5	  !      	RowHeight$ 50Q�5
  !      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5  !   $��0, 24, 0, 0q�5  !   ��5  !   ��    	CellStyle 5  "   �� 5  &    �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6,    �� BasedOn# [B 6F   .�5  *   ��  �� Property � �� �� Value$ 0q�6L   �� 5  *    � ��$ 14(�6E   �� 5  *    � ��
 �   �6G   5  '      Columns 5  "   0  *System.Windows.Controls.DataGridTextColumn  5  &   ,  &System.Windows.Controls.DataGridColumn   Header$ Số phòng��69      Width$ * 6`   1  +System.Windows.Controls.DataGridBoundColumn    Binding  6K   �� 6`     5  &   $ Loại phòng��69   $ * 6b     6M   �� 6b     5  &   $
 Giá��69   $ * 6[     6F   �� 6[     5  &   $ Cơ sở vật chất��69   $ 2* 6f     6Q   �� 6f   4	  .System.Windows.Controls.DataGridTemplateColumn	  5  &   $ Tình trạng��6=   $ * 6Q   !   SortMemberPath$! 	TinhTrang��6[   " 	  CellTemplate" 5  *   �� 5  .   .R�5  2   �� # ��Name$# statusBorder��5  5   $��52��5   5   $��24��5!  5   $ 12��5"  5   $ 4q�5#  5   $
��Left=�5$  5   ��5%  6   �� 5&  :   " ��6@   $ �� Triggers$ 5'  >   �� 5(  B   % �� Binding% 6N   �� & �� Value& Trống6c   .a�5)  F   ��  � �� �#E8F1FD6c   5*  C   �� 5+  B   % 6N   �� & Đã đặt6c   .a�5,  F   ��  � �� �#FEECEB6c   5-  C   5/  ;   ._�52  6   �� $��Center=�54  9   $��Center=�55  9   ' �� TextAlignment$' Center=�56  9   $��12(�57  9   $��Regular"�58  9   ��53  9   �� ��59  :   �� 5:  >   " ��6D   $ 5;  B   �� 5<  F   % 6R   �� & Trống6g   .a�5=  J   ��  � �� �#448DF26g   5>  G   �� 5?  F   % 6R   �� & Đã đặt6g   .a�5@  J   ��  � �� �#F369606g   5A  G   5C  ?   5E  7   5F  3   5G  /   5I  '   	  5K  &   $ 60 6=   " 5L  *   �� 5M  .   .R�5N  2     $��20��5O  5   $��20��5P  5   ���#5D6679$��Center=�5R  5   $��Center=�5S  5   $
 Hand��5T  5   $ DotsVertical=�5U  5   5V  /   5X  '   5Z     5[     5\     5]     5^     5_     5`     5a     