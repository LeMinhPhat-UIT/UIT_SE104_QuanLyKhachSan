   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuanLyKhachSan.UI.ViewsQuanLyKhachSan.UI.Views  5   	   /    )QuanLyKhachSan.UI.Views.RentReceiptWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:QuanLyKhachSan.UI.Views  5   	     � Title$  RentReceiptWindow��5	   	    � 
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
 Hand��5F      $��
0, 8, 0, 0q�5G      d� 5I      #��[  5J      $��Phiếu thuê��5K      $	 TicketOutline��5L      $
 Hand��5M      
 d� 	IsChecked$

 TrueY�5N      $��
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
��1024��5�      .+�5�      �� $	��992��5�      $	��668��5�      ���#FFFFFF$��Center=�5�      $ 12��5�      $ 16q�5�      $��0, 16, 0, 0q�5�      ._�5�      �  5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��* �60   .+�5�      �� $��0��5�   !   $	��300��5�   !   $��40��5�   !   $��Center=�5�   !   
������ $��1q�5�   !   ���#D0D3D9$ 12��5�   !   ._�5�   "   �  5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $��* �6;   .+�5�   &     $��0��5�   )   $��28��5�   )   $��28��5�   )   $ Magnify=�5�   )   $��Center=�5�   )   ���#5D6679$��
8, 0, 0, 0q�5�   )   �� 5�   &   $��1��5�   )   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm...��5�   )   $
��Auto��5�   )   $��40��5�   )   
������ $��14(�5�   )   $��
8, 0, 0, 0q�5�   )   $��Center=�5�   )   5�   #   5�      &   System.Windows.Controls.DataGrid  5      $��1��5  !   ���#F7F9FC-  'MaterialDesignThemes.Wpf.DataGridAssist   CornerRadius$ 12��5  !      AutoGenerateColumns$ False��5  !      HeadersVisibility$ Column=�5  !      CanUserAddRows$ False��5  !      
IsReadOnly$
 True��5  !      	RowHeight$ 50Q�5	  !      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5
  !   $��0, 24, 0, 0q�5  !   ��5  !   ��    	CellStyle 5  "   �� 5  &    �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6,    �� BasedOn# [B 6F   .�5  *   ��  �� Property � �� �� Value$ 0q�6L   �� 5  *    � ��$ 14(�6E   �� 5  *    � ��
 �   �6G   5  '      Columns 5  "   0  *System.Windows.Controls.DataGridTextColumn  5  &   ,  &System.Windows.Controls.DataGridColumn   Header$ ID��69      Width$ * 6Z   1	  +System.Windows.Controls.DataGridBoundColumn  	  Binding  6E   �� 6Z     5  &   $ Số phòng��69   $ * 6`     6K   �� 6`     5  &   $ Check in��69   $ * 6`     6K   �� 6`     5  &   $ 	Check out��69   $ * 6a     6L   �� 6a   4
  .System.Windows.Controls.DataGridTemplateColumn
  5  &   $ Trạng thái��6=   $ * 6Q   !   SortMemberPath$! 	TinhTrang��6[   " 
  CellTemplate" 5  *   �� 5  .   .R�5  2   �� # ��Name$# statusBorder��5  5   $��52��5  5   $��24��5   5   $ 12��5!  5   $ 4q�5"  5   $
��Left=�5#  5   ��5$  6   �� 5%  :   " ��6@   $ �� Triggers$ 5&  >   �� 5'  B   % �� Binding% 6N   �� & �� Value& Check in6c   .a�5(  F   ��  � �� �#E8F1FD6c   5)  C   �� 5*  B   % 6N   �� & Pending6c   .a�5+  F   ��  � �� �#FEECEB6c   5,  C   5.  ;   ._�51  6   �� $��Center=�53  9   $��Center=�54  9   ' �� TextAlignment$' Center=�55  9   $��12(�56  9   $��Regular"�57  9   ��52  9   �� ��58  :   �� 59  >   " ��6D   $ 5:  B   �� 5;  F   % 6R   �� & Check in6g   .a�5<  J   ��  � �� �#448DF26g   5=  G   �� 5>  F   % 6R   �� & Pending6g   .a�5?  J   ��  � �� �#F369606g   5@  G   5B  ?   5D  7   5E  3   5F  /   5H  '   
  5J  &   $ 60 6=   " 5K  *   �� 5L  .   .R�5M  2     $��20��5N  5   $��20��5O  5   ���#5D6679$��Center=�5Q  5   $��Center=�5R  5   $
 Hand��5S  5   $ DotsVertical=�5T  5   5U  /   5W  '   5Y     5Z     5[     5\     5]     5^     5_     5`     