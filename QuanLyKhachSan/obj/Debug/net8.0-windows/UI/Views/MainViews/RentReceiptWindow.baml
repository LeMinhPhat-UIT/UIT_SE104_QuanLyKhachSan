   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:QuanLyKhachSan.UI.Views.MainViews!QuanLyKhachSan.UI.Views.MainViews  5   	   C&clr-namespace:QuanLyKhachSan.ViewModelQuanLyKhachSan.ViewModel  5   	   9    3QuanLyKhachSan.UI.Views.MainViews.RentReceiptWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ;local/clr-namespace:QuanLyKhachSan.UI.Views.MainViews  5   	   0vms&clr-namespace:QuanLyKhachSan.ViewModel  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a:behavior+http://schemas.microsoft.com/xaml/behaviors  5	   	   $	��800��5   	   $
��1280��5   	     � 	Resources  5      :   4QuanLyKhachSan.ViewModel.StatusToBackgroundConverter   StatusToBackgroundConverter��%   &	          5   
   6*   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   � -   5         �Name$ 
grdSideBar��5      
�������$��0q�5      $	��800��5      $	��256��5      $
��Left=�5      $	��Top=�5       � RowDefinitions 5!      �� 5"      $	��100 �6    �� 5#      $
��Auto �6    .+�5&      �� $��0��5'      $��Center=�5(      $	��Top=�5)      $��Ehotel��5*      $��42(�5+      $5��/pack://application:,,,/Resources/Fonts/#Lobster)�5,      ���#1366D9 � Cursor$
 Hand��5.      $��0, 22, 0, 0q�5/      �� 51      -   5         ��Name$ spMenu��52      $��1��53      $��Center=�54      $	��Top=�55      $	��196��56      $��0q�57      .+�59      d�   SidebarToggleButtonStyle#��[ 5;      $��Tổng quan��5<      
 � Tag$ HomeOutline��5=      $
 Hand��5>      ��5:      �� *SidebarCommand.OverviewWindow+5>      d� 5@      #��[ 5B      $��Đặt phòng��5C      $ ShapePlusOutline��5D      $
 Hand��5E      $��
0, 8, 0, 0q�5F      ��5A      �� *SidebarCommand.BookingWindow+5F      d� 5H      #��[ 5J      $��Phòng��5K      $ 
BedOutline��5L      $
 Hand��5M      $��
0, 8, 0, 0q�5N      ��5I      �� *SidebarCommand.RoomWindow+5N      d� 5P      #��[ 5Q      $��Phiếu thuê��5R      $ TicketOutline��5S      $
 Hand��5T       d� 	IsChecked$
 TrueY�5U      $��
0, 8, 0, 0q�5V      d� 5X      #��[ 5Z      $��	Doanh thu��5[      $ ChartBellCurveCumulative��5\      $
 Hand��5]      $��
0, 8, 0, 0q�5^      ��5Y      �� *SidebarCommand.RevenueWindow+5^      d� 5`      #��[ 5b      $��Nhân viên��5c      $ AccountGroupOutline��5d      $
 Hand��5e      $��
0, 8, 0, 0q�5f      ��5a      �� *SidebarCommand.UserWindow+5f      d� 5h      #��[ 5j      $��Thiết lập��5k      $ SettingsOutline��5l      $
 Hand��5m      $��
0, 8, 0, 0q�5n      ��5i      �� *SidebarCommand.SettingWindow+5n      5o      5q      � 5s   
   -   5        $ gridHome��5t      $��1��5u      $
��Left=�5v      $	��Top=�5w      $	��800��5x      $
��1024��5y      $��0q�5z       5|      �� 5}      $	��100 �6    �� 5~      $
��Auto �6    .+�5�      � -   5        $ 	grdHeader��5�      
�������$��0��5�      $
��Left=�5�      $	��Top=�5�      $	��100��5�      $
��1024��5�      .+�5�      ��  �� Orientation$ 
Horizontal=�5�      $��Right=�5�      $��Center=�5�      .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 BellOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 14, 0q�5�        5�      $	 EmailOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 32, 0q�5�      �� 5�      $��Right=�5�      $��Center=�5�      
 �� CornerRadius$
 18��5�      ���#A1C7FF$	��320��5�      $��70��5�       �� Padding$
 12,8q�5�      $��0,0,16,0q�5�      $
 Hand��5�       � ContextMenu 5�      �� 5�      .@�5�   "   m� -   5        $��Đăng xuất��5�   +   6>   m� 5�   "   -   5        $��Thay đổi mật khẩu��5�   +   6F   5�      ._�5�      � .+�5�      �� $ 
Horizontal=�5�   !   .+�5�   "   A� $��52��5�   %   $��52��5�   %   $��Center=�5�   %   ��5�   &   �� 5�   *    �� ImageSource$6 0pack://application:,,,/Resources/Images/user.png��65   5�   #   �� 5�   "   $��Center=�5�   %   $��16, 0, 0, 0q�5�   %   .+�5�   &   �� $��Center=�5�   )   $��14(�5�   )   $��SemiBold"�5�   )   ��5�   )   �� *User.UserRole+5�   )   �� 5�   &   $��Center=�5�   )   $��16(�5�   )   $��SemiBold"�5�   )   ��5�   )   �� *User.UserEmail+5�   )   5�   #   5�      � 5�      -   5         �Name$ ChangePasswordPopup��5�   $   $��Bottom=�5�   !    � 	StaysOpen$ False��5�   !    � AllowsTransparency$
 True��5�   !   .��5�   "   �� 
�������
�������$��1q�5�   %   $
 5��5�   %   $ 10q�5�   %     MaterialDesignShadowDepth2 J� Effect# [ 5�   %   ._�5�   &   �� .+�5�   *   �� $ ��Nhập mật khẩu mới:��64   $��SemiBold"�6N   $��0,0,0,5q�6d   G� 5�   *   -   5         G�Name$ NewPasswordBox��5�   6   $	��200��6N   $��0,0,0,10q�6Z   �� 5�   *   -	   5        $��Cập nhật��5�   1   $��Right=�6a   5�   '   5�   #   5�      5�      5�      5�      5�      � 5�      -
   5        $ grdBody��5�      $��1��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      ���#DFDFDF.+�5�      �� -   5        $ spBody��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      .+�5�      �� $	��992��5�      $	��668��5�      ���#FFFFFF$��Center=�5�      $
 12��5      $ 16q�5     $��0, 16, 0, 0q�5     ._�5     �  5     �� 5  "   $
��Auto �60   �� 5  "   $��* �60   .+�5
     �� $��0��5  !   $	��300��5  !   $��40��5  !   $��Center=�5  !   
������ $��1q�5  !   ���#D0D3D9$
 12��5  !   ._�5  "   �  5  &   �� 5  *   $
��Auto �6;   �� 5  *   $��* �6;   .+�5  &     $��0��5  )   $��28��5  )   $��28��5  )   $	 Magnify=�5  )   $��Center=�5  )   ���#5D6679$��
8, 0, 0, 0q�5!  )   �� 5#  &   $��1��5%  )   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$% Tìm kiếm theo số phòng...��5&  )   $
��Auto��5'  )   $��40��5(  )   
������ $��14(�5*  )   $��
8, 0, 0, 0q�5+  )   $��Center=�5,  )   ��5$  )   �� *SearchingRoomNumber+ �� UpdateSourceTrigger$ PropertyChanged=�.��5,  K   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5-  *   +  %Microsoft.Xaml.Behaviors.EventTrigger  5.  .      	EventName$ TextChanged��6D   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5/  2   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 50  5   �� *Search+51  /   .��52  I   53  '   54  #   55     &   System.Windows.Controls.DataGrid  57     $��1��59  !   ���#F7F9FC-	  'MaterialDesignThemes.Wpf.DataGridAssist 	  CornerRadius$ 12��5<  !      AutoGenerateColumns$ False��5=  !      HeadersVisibility$ Column=�5>  !      CanUserAddRows$ False��5?  !      
IsReadOnly$
 True��5@  !      	RowHeight$ 50Q�5A  !      ColumnWidth5
  /System.Windows.Controls.DataGridLengthConverter$ *
 5B  !   $��0, 24, 0, 0q�5C  !     �� SelectedItem  58  !   �� *SelectedReservation+��5;  !   �� *Reservations+  5E  "     RowContextMenu! m� Command" �� RelativeSource# �� AncestorType��%�   &	       �� 5F  &   .@�5G  *   m� $��
Chi tiết��5H  -   ! 5I  -   �� *DataContext.ShowDetail+" �� # UserControl5J  '   5K  #   $   RowStyle$ 5M  "   �� 5N  &   % �� 
TargetType)  #System.Windows.Controls.DataGridRow"%  6,   .�5O  *   �� & �� Property& �@�ContextMenu' �� Value#' [ 6H   ( �� Triggers( 5P  *   P� 5Q  .   ) P� Property) �@J�IsMouseOver* P� Value$
* True��6M   . �5R  2   �� & � ��' �#F0F5FA6O   5S  /   5U  '   +   	CellStyle+ 5X  "   �� 5Y  &   *  $System.Windows.Controls.DataGridCell"%  6,   , �� BasedOn#, [B 6F   .�5Z  *   �� & � ��$' 0q�6L   �� 5[  *   & � ��$' 14(�6E   �� 5\  *   & � ��
' �   �6G   5]  '   -   Columns- 5`  "   0  *System.Windows.Controls.DataGridTextColumn  5a  &   ,  &System.Windows.Controls.DataGridColumn.   Header$. ID��69   /   Width$/ *
 6g   1  +System.Windows.Controls.DataGridBoundColumn0   Binding0 6E   �� *ReservationID+6g     5b  &   $. Số phòng��69   $/ *
 6j   0 6K   �� *
RoomNumber+6j     5c  &   $. Check in��69   $/ *
 6�   0 6K   �� *	CheckIn+1 �� StringFormat$1 
dd/MM/yyyy��6�     5d  &   $. 	Check out��69   $/ *
 6�   0 6L   �� *
CheckOut+$1 
dd/MM/yyyy��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5e  &   $. Trạng thái��6=   $/ *
 6Q   2   SortMemberPath$2 Status��6[   3   CellTemplate3 5f  *   �� 5g  .   .R�5h  2   �� 4 ��Name$4 statusBorder��5i  5   $
 12��5j  5   $ 4q�5k  5   $
��Left=�5l  5   ��5m  5   �� *Status+5 �� 	Converter#5 [  ��5n  6   �� 5o  :   "% ��6@   ( 5p  >   �� 5q  B   6 �� Binding6 6N   �� *Status+7 �� Value7 CheckIn6i   .a�5r  F   �� & � ��' �#E8F1FD6c   5s  C   �� 5t  B   6 6N   �� *Status+7 Pending6i   .a�5u  F   �� & � ��' �#FEECEB6c   5v  C   5x  ;   ._�5�  6   �� 8 ��Name$8 StatusComboBox��5�  9   .  (MaterialDesignThemes.Wpf.TextFieldAssist9   DecorationVisibility$9 	Collapsed=�5�  9   $��0q�5�  9   
������ $
��Left=�5�  9   $��Center=�5�  9   
������ 
���   �$	��4,0q�5�  9   : � FocusVisualStyle: 5�  9   Z� ��5�  9   �� *AvailableStatusValues+  5�  9   �� *Status+; �� Mode$; TwoWay=�$ PropertyChanged=� 5�  :     5�  >   $ DropDownClosed��6T   . 5�  B      5�  E   �� " �� *FindAncestor+"#  < �� Path$!< DataContext.SelectedChanged�5�  ?   5�  7   5�  3   5�  /   5�  '     5�  &   $/ 60
 6=   3 5�  *   �� 5�  .   .R�5�  2     $��20��5�  5   $��20��5�  5   ���#5D6679$��Center=�5�  5   $��Center=�5�  5   $
 Hand��5�  5   $	 DotsVertical=�5�  5   5�  /   5�  '   5�     5�     5�     5�     5�     5�     5�     5�     