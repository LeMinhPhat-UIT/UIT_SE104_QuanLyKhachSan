   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:QuanLyKhachSan.UI.Views.SubViews QuanLyKhachSan.UI.Views.SubViews  5   	   C&clr-namespace:QuanLyKhachSan.ViewModelQuanLyKhachSan.ViewModel  5   	   4    .QuanLyKhachSan.UI.Views.SubViews.InvoiceWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :local.clr-namespace:QuanLyKhachSan.UI.Views.SubViews  5   	   .i&clr-namespace:QuanLyKhachSan.ViewModel  5   	   -   5          � Title$  InvoiceWindow��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $
��Auto��5   	   $
��Auto��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      :   4QuanLyKhachSan.ViewModel.RadioButtonCheckedConverter   RadioButtonCheckedConverter��%   &	          5   
   6(   5      .��5      � .+�5   
   �� 
������� �� CornerRadius$ 12��5      $
��Auto��5      $	��440��5      $
��Left=�5      $	��Top=�5      $��0,0,0,0q�5       ._�5!      �  � RowDefinitions 5"      �� 5#      $
��Auto �6$   �� 5$      $��* �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   .+�5*      �� $��0��5+      $	��440��5,      $��56��5-      ���#1570EF$ 	12 12 0 0��5/      ._�50      �� $��
Hóa Đơn��51      $��22(�52      $��SemiBold"�53      
�������$��Center=�55      $��Center=�56      57      �� 59      $��1��5:      $	��408��5;      $��0, 16q�5<      $��Center=�5=      $��Hidden=�5>      .��5?      �� .+�5@      �� $��0,0,0,12q�6%   .+�5B      �� $��Phòng ��5C   !   $��22(�5D   !   $��Medium"�5E   !   �� 5F   "   $��22(�6G   $��Medium"�6U   �6&   �� *Room.RoomNumber+6U   5G      � 5I       � ColumnDefinitions 5J   "   �� 5K   &   $��2* �67   �� 5L   &   $��* �67   .+�5O   "   �� $��0��5P   %   $
��Left=�5Q   %   $��Loại phòng: ��5R   %   $��20(�5S   %   $��Medium"�63   �� 5T   &   $��20(�6M   $��Medium"�6[   �6*   �� *Room.RoomTierName+6[   5U   #   �� 5W   "   $��1��5X   %   $��Right=�5Y   %   $��20(�5Z   %   $��Medium"�63   �� 5[   &   $��20(�5\   )   $��Medium"�67   �5]   )   �� *
OldPrice+	 �� StringFormat$	 {0:N0}��5a   #   5b      �� 5d      $��18(�6(   $��Medium"�66   �� 5e   "   �6&   �� *CustomersCount+
 �� Mode$
 OneWay=�6U    �� 5f   "   $�
người, ��6&   67    �� 5g   "   �6&   �� *Reservation.Nights+$
 OneWay=�6Y    �� 5h   "   $�đêm��6&   63   5i      �� 5k      $��0 8 0 0q�6(   ���#DDD69   5m      � 5o       5p      �� 5q   "   $��2* �63   �� 5r   "   $��* �63   .+�5t      �� $��Khách ��5u   !   $��0��5v   !   $��22(�5w   !   $��Medium"�6/   5x      �� 5y      ��6'   �� *Reservation.Customers+��5z      �� 5{   "   .R�5|   &   � $��0,0,0,12q�6+    5}   *   �� 5~   .   $��* �6?   �� 5   .   $��* �6?   .+�5�   *   �� $��0��5�   -   $��22(�5�   -   $��Medium"�5�   -   ��5�   -   �� *CustomerName+5�   -   �� 5�   *   $��1��5�   -   $��Right=�5�   -   $��20(�5�   -   $��Medium"�5�   -   ��5�   -   �� *IdentityNumber+5�   -   5�   '   5�   #   5�      �� 5�      $��0 8 0 0q�6$   ���#DDD65   � 5�       5�      �� 5�   "   $��* �63   �� 5�   "   $��* �63   .+�5�      �� $��0��5�   !   $��Phụ thu: ��5�   !   $��20(�5�   !   $��Medium"�5�   !   �� 5�      $��1��5�   !   $��Right=�5�   !   $��20(�5�   !   $��Medium"�5�   !   ��5�   !   �� *Invoice.SurchargeRate+5�   !   5�      �� 5�      $��0 8 0 0q�6$   ���#DDD65   � 5�       5�      �� 5�   "   $��* �63   �� 5�   "   $��* �63   .+�5�      �� $��0��5�   !   $��Hệ số: ��5�   !   $��20(�5�   !   $��Medium"�5�   !   �� 5�      $��1��5�   !   $��Right=�5�   !   $��20(�5�   !   $��Medium"�5�   !   ��5�   !   �� *Invoice.Coef+5�   !   5�      5�      5�      �� 5�      $��2��5�      $��16,8,0,8q�5�      $
��Left=�5�      .+�5�      �� $"��Phương thức thanh toán:��5�      $��18(�5�      $
��Bold"�5�      �� 5�       �� Orientation$ 
Horizontal=�5�      .+�5�      	� $��Tiền mặt��5�      
 � Tag$
 Cash��5�       	� 	GroupName$ PaymentMethod��5�      $��20(�5�      $
��10,5q�5�       d� 	IsChecked 5�      �� *Invoice.PaymentMethod+ �� 	Converter# [   �� ConverterParameter$
 Cash��	� 5�      $��Thẻ��5�      $ Credit card��5�      $ PaymentMethod��5�      $��20(�5�      $
��10,5q�5�       5�      �� *Invoice.PaymentMethod+# [  $ Credit card��5�      5�      �� 5�      $��3��5�      $��	0 0 16 22q�5�      $ 
Horizontal=�5�      $��Right=�5�      .+�5�      �� $��Tổng: ��6    $
��Bold"�6.   $��20(�6@   �� 5�      $��20(�6V   ��6    �� *Invoice.Total+$	 {0:N0}��6V   5�      �� 5�      $��4��5�        BlueButtonStyle#���  5�      $	��200��5�      $��50��5�       � Cursor$
 Hand��5�      $��0, 0, 0, 16q�5�      ��5�      �� *Pay+.��5�      �� $ 
Horizontal=�5�      .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��28��5�      $��28��5�      $��Center=�5�         Kind$ CartOutline=�5�      �� 5�      $��Thanh toán��5�      $��20(�5�      $��Center=�5�      $��
4, 0, 0, 0q�5�      5�      5�      5�      5�      5�      5�      