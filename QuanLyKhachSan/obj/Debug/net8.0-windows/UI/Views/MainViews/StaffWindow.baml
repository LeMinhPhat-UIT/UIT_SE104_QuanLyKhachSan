   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:QuanLyKhachSan.UI.Views.MainViews!QuanLyKhachSan.UI.Views.MainViews  5      3    -QuanLyKhachSan.UI.Views.MainViews.StaffWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ;local/clr-namespace:QuanLyKhachSan.UI.Views.MainViews  5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a:behavior+http://schemas.microsoft.com/xaml/behaviors  5	      $	��800��5      $
��1280��5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   � -   5         �Name$ 
grdSideBar��5      
�������$��0q�5      $	��800��5      $	��256��5      $
��Left=�5      $	��Top=�5       � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $
��Auto �6    .+�5!      �� $��0��5"      $��Center=�5#      $	��Top=�5$      $��Ehotel��5%      $��42(�5&      $5��/pack://application:,,,/Resources/Fonts/#Lobster)�5'      ���#1366D9 � Cursor$
 Hand��5)      $��0, 22, 0, 0q�5*      �� 5,      -   5         ��Name$ spMenu��5-      $��1��5.      $��Center=�5/      $	��Top=�50      $	��196��51      $��0q�52      .+�54      d�    SidebarToggleButtonStyle#��[  56      $��Tổng quan��57      
 � Tag$ HomeOutline��58      $
 Hand��59      ��55      �� *SidebarCommand.OverviewWindow+59      d� 5;      #��[  5=      $��Đặt phòng��5>      $ ShapePlusOutline��5?      $
 Hand��5@      $��
0, 8, 0, 0q�5A      ��5<      �� *SidebarCommand.BookingWindow+5A      d� 5C      #��[  5E      $��Phòng��5F      $ 
BedOutline��5G      $
 Hand��5H      $��
0, 8, 0, 0q�5I      ��5D      �� *SidebarCommand.RoomWindow+5I      d� 5K      #��[  5M      $��Phiếu thuê��5N      $ TicketOutline��5O      $
 Hand��5P      $��
0, 8, 0, 0q�5Q      ��5L      �� *" SidebarCommand.ReservationWindow+5Q      d� 5S      #��[  5U      $��	Doanh thu��5V      $ ChartBellCurveCumulative��5W      $
 Hand��5X      $��
0, 8, 0, 0q�5Y      ��5T      �� *SidebarCommand.RevenueWindow+5Y      d� 5[      #��[  5\      $��Nhân viên��5]      $ AccountGroupOutline��5^      $
 Hand��5_       d� 	IsChecked$
 TrueY�5`      $��
0, 8, 0, 0q�5a      d� 5c      #��[  5e      $��Thiết lập��5f      $ SettingsOutline��5g      $
 Hand��5h      $��
0, 8, 0, 0q�5i      ��5d      �� *SidebarCommand.SettingWindow+5i      5j      5l      � 5n   
   -   5        $ gridHome��5o      $��1��5p      $
��Left=�5q      $	��Top=�5r      $	��800��5s      $
��1024��5t      $��0q�5u       5w      �� 5x      $	��100 �6    �� 5y      $
��Auto �6    .+�5|      � -   5        $ 	grdHeader��5~      
�������$��0��5      $
��Left=�5�      $	��Top=�5�      $	��100��5�      $
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
��1024��5�      ���#DFDFDF.+�5�      �� -   5        $ spBody��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      .+�5�      �� $	��992��5�      $	��668��5�      ���#FFFFFF$��Center=�5�      $��Center=�5�      $	 12��5�      $
 16q�5�      $��0, 16, 0, 0q�5�      ._�5      �  5     �� 5  "   $
��Auto �60   �� 5  "   $��* �60   .+�5     � $��0��5  !   .+�5	  "   �� $	��300��5
  !   $��40��5  !   $��Center=�5  !   
������ $��1q�5  !   ���#D0D3D9$	 12��5  !   ._�5  &   �   5  *   �� 5  .   $
��Auto �6?   �� 5  .   $��* �6?   .+�5  *     $��0��5  -   $��28��5  -   $��28��5  -   $ Magnify=�5  -   $��Center=�5  -   ���#5D6679$��
8, 0, 0, 0q�5  -   �� 5!  *   $��1��5#  -   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm theo CCCD...��5$  -   $
��Auto��5%  -   $��40��5&  -   
������ $��14(�5(  -   $��
8, 0, 0, 0q�5)  -   $��Center=�5*  -   ��5"  -   �� *SearchingIdentity+ �� UpdateSourceTrigger$ PropertyChanged=�.��5*  O   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5+  .   +  %Microsoft.Xaml.Behaviors.EventTrigger  5,  2      	EventName$ TextChanged��6H   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5-  6   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 5.  9   �� *Search+5/  3   .��50  M   51  +   52  '   53  #   �� 55  "     BlueButtonStyle#���  57  %   $��Thêm nhân viên��58  %   $
 Hand��59  %   $��Right=�5:  %   ��56  %   �� *	UserAdd+5:  %   5;     &   System.Windows.Controls.DataGrid  5>     $��1��5?  !   ���#F7F9FC-  'MaterialDesignThemes.Wpf.DataGridAssist   CornerRadius$ 12��5C  !      AutoGenerateColumns$ False��5D  !      HeadersVisibility$ Column=�5E  !      CanUserAddRows$ False��5F  !      
IsReadOnly$
 True��5G  !      	RowHeight$ 50Q�5H  !      ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$ *	 5I  !   $��0, 24, 0, 0q�5J  !   ��5A  !   �� *Users+ �� SelectedItem 5B  !   �� *SelectedUser+  � 	Resources  5L  "     RowContextMenu! m� Command" �� RelativeSource# �� AncestorType��%�   &	       �� 5M  &   .@�5Q  *   m� $��Xóa nhân viên��5R  -   ! 5S  -   �� *DataContext.UserDelete+" �� # UserControl5T  '   5U  #   $   RowStyle$ 5W  "   �� 5X  &   % �� 
TargetType)
  #System.Windows.Controls.DataGridRow"% 
 6,   .�5Y  *   �� & �� Property& �@�ContextMenu' �� Value#' [ 6H   ( �� Triggers( 5Z  *   P� 5[  .   ) P� Property) �@J�IsMouseOver* P� Value$
* True��6M   . �5\  2   �� & � ��' �#F0F5FA6O   5]  /   5_  '   +   	CellStyle+ 5b  "   �� 5c  &   *  $System.Windows.Controls.DataGridCell"%  6,   , �� BasedOn#, [B 6F   .�5d  *   �� & � ��$' 0q�6L   �� 5e  *   & � ��$' 14(�6E   �� 5f  *   & � ��
' �   �6G   5g  '   -   Columns- 5j  "   0  *System.Windows.Controls.DataGridTextColumn  5k  &   ,  &System.Windows.Controls.DataGridColumn.   Header$. ID��69   /   Width$/ SizeToCells	 6\   1  +System.Windows.Controls.DataGridBoundColumn0   Binding0 6E   �� *ID+6\     5l  &   $
. Tên��69   $/ SizeToCells	 6c   0 6F   �� *
UserName+6c     5m  &   $
. CCCD��69   $/ SizeToCells	 6d   0 6G   �� *
Identity+6d     5n  &   $. Email��69   $/ SizeToCells	 6f   0 6H   �� *	UserEmail+6f     5o  &   $. Số điện thoại��69   $/ SizeToCells	 6p   0 6P   �� *PhoneNumber+6p     5p  &   $. Chức vụ��69   $/ SizeToCells	 6g   0 6J   �� *
UserRole+6g     5q  &   $. Ngày vào làm��69   $/ SizeToCells	 6�   0 6O   �� *WorkingDate+1 �� StringFormat$1 
dd/MM/yyyy��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5r  &   $/ 60	 6=   2   CellTemplate2 5s  *   �� 5t  .   .R�5u  2     $��20��5v  5   $��20��5w  5   $ DotsVertical=�5x  5   ���#5D6679$��Center=�5z  5   $��Center=�5{  5   $
 Hand��5|  5   5}  /   5  '   5�     5�     5�     5�     5�     5�     5�     5�     