   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:QuanLyKhachSan.UI.Views.MainViews!QuanLyKhachSan.UI.Views.MainViews  5   	   2    ,QuanLyKhachSan.UI.Views.MainViews.RoomWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ;local/clr-namespace:QuanLyKhachSan.UI.Views.MainViews  5   	   $	��800��5	   	   $
��1280��5
   	   .��5      �   � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   � -   5         �Name$ 
grdSideBar��5      
�������$��0q�5      $	��800��5      $	��256��5      $
��Left=�5      $	��Top=�5       � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $
��Auto �6    .+�5       �� $��0��5!      $��Center=�5"      $	��Top=�5#      $��Ehotel��5$      $��42(�5%      $5��/pack://application:,,,/Resources/Fonts/#Lobster)�5&      ���#1366D9 � Cursor$
 Hand��5(      $��0, 22, 0, 0q�5)      �� 5+      -   5         ��Name$ spMenu��5,      $��1��5-      $��Center=�5.      $	��Top=�5/      $	��196��50      $��0q�51      .+�53      d�    SidebarToggleButtonStyle#��[  55      $��Tổng quan��56      
 � Tag$ HomeOutline��57      $
 Hand��58      ��54      �� *SidebarCommand.OverviewWindow+58      d� 5:      #��[  5<      $��Đặt phòng��5=      $ ShapePlusOutline��5>      $
 Hand��5?      $��
0, 8, 0, 0q�5@      ��5;      �� *SidebarCommand.BookingWindow+5@      d� 5B      #��[  5C      $��Phòng��5D      $ 
BedOutline��5E      $
 Hand��5F       d� 	IsChecked$
 TrueY�5G      $��
0, 8, 0, 0q�5H      d� 5J      #��[  5L      $��Phiếu thuê��5M      $ TicketOutline��5N      $
 Hand��5O      $��
0, 8, 0, 0q�5P      ��5K      �� *" SidebarCommand.ReservationWindow+5P      d� 5R      #��[  5T      $��	Doanh thu��5U      $ ChartBellCurveCumulative��5V      $
 Hand��5W      $��
0, 8, 0, 0q�5X      ��5S      �� *SidebarCommand.RevenueWindow+5X      d� 5Z      #��[  5\      $��Nhân viên��5]      $ AccountGroupOutline��5^      $
 Hand��5_      $��
0, 8, 0, 0q�5`      ��5[      �� *SidebarCommand.UserWindow+5`      d� 5b      #��[  5d      $��Thiết lập��5e      $ SettingsOutline��5f      $
 Hand��5g      $��
0, 8, 0, 0q�5h      ��5c      �� *SidebarCommand.SettingWindow+5h      5i      5k      � 5m   
   -   5        $ gridHome��5n      $��1��5o      $
��Left=�5p      $	��Top=�5q      $	��800��5r      $
��1024��5s      $��0q�5t       5v      �� 5w      $	��100 �6    �� 5x      $
��Auto �6    .+�5{      � -   5        $ 	grdHeader��5}      
�������$��0��5~      $
��Left=�5      $	��Top=�5�      $	��100��5�      $
��1024��5�      .+�5�      ��  �� Orientation$ 
Horizontal=�5�      $��Right=�5�      $��Center=�5�      .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ BellOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 14, 0q�5�        5�      $ EmailOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 32, 0q�5�      �� 5�      $��Right=�5�      $��Center=�5�      	 �� CornerRadius$	 18��5�      ���#A1C7FF$	��320��5�      $��70��5�      
 �� Padding$

 12,8q�5�      $��0,0,16,0q�5�      $
 Hand��5�       � ContextMenu 5�      �� 5�      .@�5�   "   m� -   5        $��Đăng xuất��5�   +   6>   m� 5�   "   -   5        $��Thay đổi mật khẩu��5�   +   6F   5�      ._�5�      � .+�5�      �� $ 
Horizontal=�5�   !   .+�5�   "   A� $��52��5�   %   $��52��5�   %   $��Center=�5�   %   ��5�   &   �� 5�   *    �� ImageSource$6 0pack://application:,,,/Resources/Images/user.png��65   5�   #   �� 5�   "   $��Center=�5�   %   $��16, 0, 0, 0q�5�   %   .+�5�   &   �� $��Center=�5�   )   $��14(�5�   )   $��SemiBold"�5�   )   ��5�   )   �� *User.UserRole+5�   )   �� 5�   &   $��Center=�5�   )   $��16(�5�   )   $��SemiBold"�5�   )   ��5�   )   �� *User.UserEmail+5�   )   5�   #   5�      � 5�      -   5         �Name$ ChangePasswordPopup��5�   $   $��Bottom=�5�   !    � 	StaysOpen$ False��5�   !    � AllowsTransparency$
 True��5�   !   .��5�   "   �� 
�������
�������$��1q�5�   %   $	 5��5�   %   $
 10q�5�   %     MaterialDesignShadowDepth2 J� Effect# [ 5�   %   ._�5�   &   �� .+�5�   *   �� $ ��Nhập mật khẩu mới:��64   $��SemiBold"�6N   $��0,0,0,5q�6d   G� 5�   *   -   5         G�Name$ NewPasswordBox��5�   6   $	��200��6N   $��0,0,0,10q�6Z   �� 5�   *   -	   5        $��Cập nhật��5�   1   $��Right=�6a   5�   '   5�   #   5�      5�      5�      5�      5�      � 5�      -
   5        $ grdBody��5�      $��1��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      ���#DFDFDF.+�5�      �� -   5        $ spBody��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      .+�5�      �� $	��992��5�      $	��645��5�      ���#FFFFFF$��Center=�5�      $	 12��5�      $
 16q�5�      $��0, 16, 0, 0q�5�      ._�5     �  5     �� 5  "   $
��Auto �60   �� 5  "   $��* �60   .+�5     � $��0��5  !     5	  "   �� 5
  &   $
��Auto �67   �� 5  &   $��* �67   .+�5  "   �� $��0��5  %   $ 
Horizontal=�5  %   .+�5  &   �� ��63   �� *	LoadRooms+��5  *   �� 5  .   .R�5  2   �� $ 
Horizontal=�6=   $
��Left=�6V   5  /   ��5  *   �� 5  .   .R�5  2   d�   OutlinedToggleButtonStyle#��[ 5  5   $��
0, 0, 8, 0q�5  5   ��5  5   �� *Label+ 5  5   �� *	IsChecked+ �� Mode$ TwoWay=���5  5   �� *	Command+5  5   5   /   5"  '   5#  #   �� 5%  "   $��1��5'  %     BlueButtonStyle#���  5(  %   $��Thêm phòng��5)  %   $
 Hand��5*  %   $��Right=�5+  %   ��5&  %   �� *	RoomAdd+5+  %   5,     &   System.Windows.Controls.DataGrid  5.     $��1��5/  !   ���#F7F9FC-  'MaterialDesignThemes.Wpf.DataGridAssist   CornerRadius$ 12��53  !      SelectionUnit$ FullRow=�54  !      AutoGenerateColumns$ False��55  !      HeadersVisibility$ Column=�56  !      CanUserAddRows$ False��57  !      
IsReadOnly$
 True��58  !      MinRowHeight$ 50Q�59  !      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5:  !   $��0, 24, 0, 0q�5;  !   ��51  !   �� *Rooms+ �� SelectedItem 52  !   �� *SelectedRoom+ � 	Resources 5=  "     RowContextMenu m� Command �� RelativeSource �� AncestorType��%  &	       �� 5>  &   .@�5?  *   m� $��Chỉnh sửa phòng��5@  -    5A  -   �� *DataContext.RoomUpdate+ ��  UserControlm� 5B  *   $��Xóa phòng��5C  -    5D  -   �� *DataContext.RoomDelete+ ��  UserControl5I  '   5J  #       RowStyle  5L  "   �� 5M  &   ! �� 
TargetType)  #System.Windows.Controls.DataGridRow"!  6,   .�5N  *   �� " �� Property" �@�ContextMenu# �� Value## [ 6H   $ �� Triggers$ 5O  *   P� 5P  .   % P� Property% �@J�IsMouseOver& P� Value$
& True��6M   . �5Q  2   �� " � ��# �#F0F5FA6O   5R  /   5T  '   '   	CellStyle' 5W  "   �� 5X  &   *  $System.Windows.Controls.DataGridCell"!  6,   ( �� BasedOn#( [B 6F   .�5Y  *   �� " � ��$# 0q�6L   �� 5Z  *   " � ��$# 14(�6E   �� 5[  *   " � ��
# �   �6G   5\  '   )   Columns) 5_  "   0  *System.Windows.Controls.DataGridTextColumn  5`  &   ,  &System.Windows.Controls.DataGridColumn*   Header$* Số phòng��69   +   Width$+ * 6j   1	  +System.Windows.Controls.DataGridBoundColumn, 	  Binding, 6K   �� *
RoomNumber+6j     5a  &   $* Loại phòng��69   $+ * 6n   , 6M   �� *RoomTierName+6n     5b  &   $
* Giá��69   $+ * 6}   , 6F   �� *PricePerDay+- �� StringFormat$- {0:N0}��6}   4
  .System.Windows.Controls.DataGridTemplateColumn
  5c  &   $* Cơ sở vật chất��6=   $+ 2* 6U   . 
  CellTemplate. 5d  *   �� 5e  .   .R�5f  2   �� $
��Wrap=�5h  5   $��Center=�5i  5   $��4q�5j  5   $��14(�5k  5   ��5g  5   �� *	Amenity+5k  5   5l  /   5n  '   
  5o  &   $* Tình trạng��6=   $+ * 6Q   /   SortMemberPath$/ 	TinhTrang��6[   . 5p  *   �� 5q  .   .R�5r  2   �� 0 ��Name$0 statusBorder��5s  5   $	 12��5t  5   $
 4q�5u  5   $
��Left=�5v  5   $��28��5w  5   ��5x  6   �� 5y  :   "! ��6@   $ 5z  >   �� 5{  B   1 �� Binding1 6N   �� *	RoomState+2 �� Value2 	Available6l   .a�5|  F   �� " � ��# �#E8F1FD6c   5}  C   �� 5~  B   1 6N   �� *	RoomState+2 Occupied6l   .a�5  F   �� " � ��# �#FEECEB6c   5�  C   5�  ;   ._�5�  6   �� $��Center=�5�  9   $��Center=�5�  9   3 �� TextAlignment$3 Center=�5�  9   $��12(�5�  9   $��Regular"�5�  9   ��5�  9   �� *	RoomState+��5�  :   �� 5�  >   "! ��6D   $ 5�  B   �� 5�  F   1 6R   �� *	RoomState+2 	Available6p   .a�5�  J   �� " � ��# �#E8F1FD6g   5�  G   �� 5�  F   1 6R   �� *	RoomState+2 Occupied6p   .a�5�  J   �� " � ��# �#FEECEB6g   5�  G   5�  ?   5�  7   5�  3   5�  /   5�  '   
  5�  &   $+ 60 6=   . 5�  *   �� 5�  .   .R�5�  2     $��20��5�  5   $��20��5�  5   ���#5D6679$��Center=�5�  5   $��Center=�5�  5   $
 Hand��5�  5   $ DotsVertical=�5�  5   5�  /   5�  '   5�     5�     5�     5�     5�     5�     5�     5�     