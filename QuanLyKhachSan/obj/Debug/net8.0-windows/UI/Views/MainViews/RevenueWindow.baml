   M S B A M L   `   `   `  ����[  WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF  5      I EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:QuanLyKhachSan.UI.Views.MainViews!QuanLyKhachSan.UI.Views.MainViews 5	      a5clr-namespace:QuanLyKhachSan.ViewModel.ScrollBehavior'QuanLyKhachSan.ViewModel.ScrollBehavior 5      5   /QuanLyKhachSan.UI.Views.MainViews.RevenueWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      blvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF  5      ;local/clr-namespace:QuanLyKhachSan.UI.Views.MainViews  5	      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a:behavior+http://schemas.microsoft.com/xaml/behaviors  5
      E	behaviors5clr-namespace:QuanLyKhachSan.ViewModel.ScrollBehavior  5      $	��800��5      $
��1280��5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��8* �6   .+�5   
   � -   5         �Name$ 
grdSideBar��5      
�������$��0q�5      $	��800��5      $	��256��5      $
��Left=�5      $	��Top=�5       � RowDefinitions 5      �� 5      $	��100 �6    �� 5       $
��Auto �6    .+�5#      �� $��0��5$      $��Center=�5%      $	��Top=�5&      $��Ehotel��5'      $��42(�5(      $5��/pack://application:,,,/Resources/Fonts/#Lobster)�5)      ���#1366D9 � Cursor$
 Hand��5+      $��0, 22, 0, 0q�5,      �� 5.      -   5         ��Name$ spMenu��5/      $��1��50      $��Center=�51      $	��Top=�52      $	��196��53      $��0q�54      .+�56      d�    SidebarToggleButtonStyle#��[  58      $��Tổng quan��59      
 � Tag$ HomeOutline��5:      $
 Hand��5;      ��57      �� *SidebarCommand.OverviewWindow+5;      d� 5=      #��[  5?      $��Đặt phòng��5@      $ ShapePlusOutline��5A      $
 Hand��5B      $��
0, 8, 0, 0q�5C      ��5>      �� *SidebarCommand.BookingWindow+5C      d� 5E      #��[  5G      $��Phòng��5H      $ 
BedOutline��5I      $
 Hand��5J      $��
0, 8, 0, 0q�5K      ��5F      �� *SidebarCommand.RoomWindow+5K      d� 5M      #��[  5O      $��Phiếu thuê��5P      $ TicketOutline��5Q      $
 Hand��5R      $��
0, 8, 0, 0q�5S      ��5N      �� *" SidebarCommand.ReservationWindow+5S      d� 5U      #��[  5V      $��	Doanh thu��5W      $ ChartBellCurveCumulative��5X      $
 Hand��5Y       d� 	IsChecked$
 TrueY�5Z      $��
0, 8, 0, 0q�5[      d� 5]      #��[  5_      $��Nhân viên��5`      $ AccountGroupOutline��5a      $
 Hand��5b      $��
0, 8, 0, 0q�5c      ��5^      �� *SidebarCommand.UserWindow+5c      d� 5e      #��[  5g      $��Thiết lập��5h      $ SettingsOutline��5i      $
 Hand��5j      $��
0, 8, 0, 0q�5k      ��5f      �� *SidebarCommand.SettingWindow+5k      5l      5n      � 5p   
   -   5        $ gridHome��5q      $��1��5r      $
��Left=�5s      $	��Top=�5t      $	��800��5u      $
��1024��5v      $��0q�5w       5y      �� 5z      $	��100 �6    �� 5{      $
��Auto �6    .+�5~      � -   5        $ 	grdHeader��5�      
�������$��0��5�      $
��Left=�5�      $	��Top=�5�      $	��100��5�      $
��1024��5�      .+�5�      ��  �� Orientation$ 
Horizontal=�5�      $��Right=�5�      $��Center=�5�      .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ iconNotification��5�      	   Kind$	 BellOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      ���#5D6679$
 Hand��5�      $��0, 0, 14, 0q�5�        5�      -   5        $ iconMail��5�      $	 EmailOutline=�5�      $��32��5�      $��32��5�      $��Right=�5�      $��Center=�5�      $
 Hand��5�      ���#5D6679$��0, 0, 32, 0q�5�      �� 5�      $��Right=�5�      $��Center=�5�      
 �� CornerRadius$
 18��5�      ���#A1C7FF$	��320��5�      $��70��5�       �� Padding$
 12,8q�5�      $��0,0,16,0q�5�      $
 Hand��5�       � ContextMenu 5�      �� 5�      .@�5�   "   m� -   5        $��Đăng xuất��5�   +   6>   m� 5�   "   -   5        $��Thay đổi mật khẩu��5�   +   6F   5�      ._�5�      � .+�5�      �� $ 
Horizontal=�5�   !   .+�5�   "   A� $��52��5�   %   $��52��5�   %   $��Center=�5�   %   ��5�   &   �� 5�   *    �� ImageSource$6 0pack://application:,,,/Resources/Images/user.png��65   5�   #   �� 5�   "   $��Center=�5�   %   $��16, 0, 0, 0q�5�   %   .+�5�   &   �� $��Center=�5�   )   $��14(�5�   )   $��SemiBold"�5�   )   ��5�   )   �� *User.UserRole+5�   )   �� 5�   &   $��Center=�5�   )   $��16(�5�   )   $��SemiBold"�5�   )   ��5�   )   �� *User.UserEmail+5�   )   5�   #   5�      � 5�      -	   5         �Name$ ChangePasswordPopup��5�   $   $��Bottom=�5�   !    � 	StaysOpen$ False��5�   !    � AllowsTransparency$
 True��5�   !   .��5�   "   �� 
�������
�������$��1q�5�   %   $
 5��5�   %   $ 10q�5�   %     MaterialDesignShadowDepth2 J� Effect# [ 5�   %   ._�5�   &   �� .+�5�   *   �� $ ��Nhập mật khẩu mới:��64   $��SemiBold"�6N   $��0,0,0,5q�6d   G� 5�   *   -
   5         G�Name$ NewPasswordBox��5�   6   $	��200��6N   $��0,0,0,10q�6Z   �� 5�   *   -   5        $��Cập nhật��5�   1   $��Right=�6a   5�   '   5�   #   5�      5�      5�      5�      5�      � 5�      -   5        $ grdBody��5�      $��1��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      ���#DFDFDF.+�5�      �� -   5        $ spBody��5�      $
��Left=�5�      $	��Top=�5�      $	��700��5�      $
��1024��5�      .+�5�      � $��16, 24, 16, 0q�5�        5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   .+�5     �� $��0��5     $	��440��5     $	��300��5     $
��Left=�5     $
 12��5     $ 16, 32q�5     
�������._�5
     � $��8q�5  !     5  "   �� 5  &   $��* �67   �� 5  &   $��* �67   .+�5  "   � $��0��6'   $��Right=�67   $	��196��6S    5  &   �� 5  *   $
��Auto �68   �� 5  *   $
��Auto �68   �� 5  *   $��* �68   .+�5  &   �� $��0��5  )   $��Doanh thu (%)��5  )   $��20(�5  )   $��SemiBold"�5  )   �� 5  &   $��1��5   )   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ 	Collapsed=�5#  )   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tháng��5$  )   $��80��5%  )   $
��Left=�5&  )   $��16(�5'  )   $��
0, 8, 0, 0q�5(  )   ��5!  )   �� *	ChartView+ �� SelectedItem 5"  )   �� *SelectedPieChartView+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5)  *   +  %Microsoft.Xaml.Behaviors.EventTrigger  5*  .      	EventName$ DropDownClosed��6D   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5+  2   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 5,  5   �� *PieChartViewChanged+5-  /   5/  '   �� 51  &   $��2��52  )   $��Hidden=�53  )   .��54  *   �� $��0,32,0,0q�56  -   ��55  -   �� *PieChartItems+��57  .   �� 58  2   .R�59  6   �� $ 
Horizontal=�6A   $��
0, 8, 0, 0q�6Z   .+�5:  :   �� $��50��5;  =   $��25��5<  =   $
 8��5>  =   ��5=  =   �� *Brush+5>  =   �� 5?  :   $��18(�5A  =   $��Regular"�5B  =   ���#747474$��16, 0, 0, 0q�5D  =   ��5@  =   �� *Tier.RoomTierName+5D  =   5E  7   5F  3   5H  +   5I  '   5J  #   /   )LiveChartsCore.SkiaSharpView.WPF.PieChart  5L  "   $��1��5M  %   ,	   &LiveChartsCore.SkiaSharpView.WPF.Chart 	  LegendPosition$ Hidden=�5O  %      Series 5N  %   �� *
PieChart+5O  %   5P     5Q     �� 5S     $��1��5T     $	��540��5U     $	��300��5V     $��Right=�5W     $
 12��5X     $ 16q�5Y     
�������._�5\     �  5]  "   �� 5^  &   $
��Auto �64   �� 5_  &   $��* �64   �� 5`  &   $
��Auto �64   .+�5c  "   �� $��0��5d  %   $��Doanh thu qua các tháng��5e  %   $��20(�5f  %   $��Medium"�5g  %   $��Center=�5h  %   5
   /LiveChartsCore.SkiaSharpView.WPF.CartesianChart
  5j  "   $��1��5k  %   $��0, 16q�5l  %    	  TooltipPosition$ Hidden=�5p  %   $ Hidden=�5q  %   
������� 
  ZoomMode$
 None=�5s  %    
  Series 5m  %   �� *ColumnChart+ 
  XAxes 5n  %   �� *ColumnXAxis+  
  YAxes  5o  %   �� *ColumnYAxis+! 
  DrawMarginFrame! 5t  %   Z� 5}     5~     5�     � 5�     $��16, 28, 16, 24q�5�       5�     �� 5�     $
��Auto �6/   �� 5�     $��* �6/   .+�5�     �� $��0��5�     $	��640��5�     $	��330��5�     $
��Left=�5�     $	��Top=�5�     $
 12��5�     $ 16q�5�     
�������._�5�     �  5�  "   �� 5�  &   $
��Auto �64   �� 5�  &   $��* �64   �� 5�  &   $
��Auto �64   .+�5�  "   �� $��0��5�  %   .+�5�  &   �� $ 
Horizontal=�5�  )   .+�5�  *   �� $��Doanh thu theo phòng��5�  -   $��18(�5�  -   $��Medium"�5�  -   5�  '   �� 5�  &   $��24(�5�  )   $��Regular"�5�  )   ���#165BAA�� 5�  *   �6.   �� *ReservationCount+ �� 5�  *   $� lượt đặt��6.   5�  '   5�  #   
  5�  "   $��1��5�  %   $ Hidden=�5�  %   
�������$��0, 16q�5�  %   $
 None=�5�  %    5�  %   �� *	LineChart+ 5�  %   �� *	LineXAxis+! 5�  %   Z� 5�  %   � 5�  "   $��2��6'   .+�5�  &   �� $��Hidden=�5�  )   $��Hidden=�5�  )   R  LQuanLyKhachSan.ViewModel.ScrollBehavior.HorizontalScrollOnMouseWheelBehavior"   EnableHorizontalScroll$
" True��5�  )   .��5�  *   �� $��16,0,0,0q�5�  -   ��5�  -   �� *PieChartItems+��5�  .   �� 5�  2   .R�5�  6   �� $ 
Horizontal=�6A   5�  3   ��5�  .   �� 5�  2   .R�5�  6   �� $ 
Horizontal=�6A   $��
0, 8, 0, 0q�6Z   .+�5�  :   �� $��16��5�  =   $��16��5�  =   $
 8��5�  =   ��5�  =   �� *Brush+5�  =   �� 5�  :   $��18(�5�  =   $��Regular"�5�  =   ���#747474$��16, 0, 16, 0q�5�  =   ��5�  =   �� *Tier.RoomTierName+5�  =   5�  7   5�  3   5�  +   5�  '   5�  #   5�     5�     �� 5�     $��1��5�     $	��340��5�     $	��330��5�     $��Right=�5�     $
 12��5�     $ 24q�5�     
�������._�5�     �� .+�5�  "   �� $��Doanh thu (VNĐ)��5�  %   $��22(�5�  %   $��SemiBold"�5�  %   �� 5  "   $ 	Collapsed=�5  %   $ Tháng��5  %   $��80��5  %   $
��Left=�5  %   $��16(�5  %   $��
0, 8, 0, 0q�5	  %   ��5  %   �� *	ChartView+ 5  %   �� *SelectedTotalRevenue+ 5
  &     5  *   $ DropDownClosed��6@   . 5  .      5  1   �� *TotalRevenueViewChanged+5  +   5  #   �� 5  "   $	��250��5  %   $��80��5  %   $
 12��5  %   $��0, 52, 0, 0q�5  %   ��5  &   �� 5  *   # �� 
StartPoint$	# 0,0&�6>   $ �� EndPoint$	$ 1,0&�6O   .��5  .   � % � Color$% #1E74FF��6;   & � Offset$	& 0.2Q�6K   � 5  .   $% #AA94FF��6;   $& 1Q�6K   5  +   ._�5  &   �� $��36(�5!  )   $��Medium"�5"  )   
�������$��Center=�5$  )   $��Center=�5%  )   ��5   )   �� *TotalRevenue+' �� StringFormat$' {0:N0}��5%  )   5&  #   5'     5(     5)     5*     5+     5,     5-     5.     