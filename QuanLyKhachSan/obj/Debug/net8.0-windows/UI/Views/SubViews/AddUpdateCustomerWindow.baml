   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:QuanLyKhachSan.UI.Views.SubViews QuanLyKhachSan.UI.Views.SubViews  5   	   O,clr-namespace:QuanLyKhachSan.ValidationRulesQuanLyKhachSan.ValidationRules  5   	   >    8QuanLyKhachSan.UI.Views.SubViews.AddUpdateCustomerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :local.clr-namespace:QuanLyKhachSan.UI.Views.SubViews  5   	   =
validation,clr-namespace:QuanLyKhachSan.ValidationRules  5   	   -   5          � Title$  AddCustomerWindow��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $	��400��5   	   $	��600��5   	   .��5      � .+�5   
   �� $	��600��5      $	��316��5      ���#FFFFFF �� CornerRadius$ 12��5       �� Padding$ 48, 24q�5      ._�5      �� $}�False��5      .+�5      �� $��22��5      $��22��5       $��Right=�5!       � Cursor$
 Hand��5"      $��0, -8, -24, 0q�5#      $��0q�5$      ��5      �� *Close+.��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeleteOutline=�6.   $��22��6C   $��22��6N   5&      �� 5(      $$��Nhập thông tin khách hàng��5)      $��24(�5*      $��SemiBold"�5+      ���#1570EF$��0, -12, 0, 0q�5-      � 5/      $��0, 24, 0, 0q�50       � ColumnDefinitions 51      �� 52      $��* �6+   �� 53      $��* �6+   .+�56      �� $��0��57      .+�58      �� $��Họ và tên:��59      $��14(�5:      $��SemiBold"�5;      �� 5=      $	��230��5>      $��35��5?      ���#DCF1FF$
��Left=�5A      $ 8��5B      $
 8, 0q�5C      $��
0, 8, 0, 0q�5D      ._�5E      �� .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 	Collapsed=�5G   !   $��0q�5H   !   ��5F   !   �� *Customer.CustomerName+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=�5H   !   5I      5J      �� 5L      $��1��5M      $��Right=�5N      .+�5O      �� $��Loại khách hàng:��5P      $��14(�5Q      $��SemiBold"�5R      �� 5S      $	��230��5T      $��35��5U      ���#DCF1FF$
��Left=�5W      $ 8��5X      $
 8, 0q�5Y      $��
0, 8, 0, 0q�5Z      ._�5[      ��  �� DisplayMemberPath$ CustomerTierName��5]   !   $	 	Collapsed=�5_   !   $��0q�5`   !   $��35��5a   !   ��5\   !   �� *CustomerTiers+ �� SelectedItem 5^   !   �� *SelectedCustomerTier+$
 PropertyChanged=�5b      5c      5d      5e      � 5g      $��0, 24, 0, 0q�5h       5i      �� 5j      $��* �6+   �� 5k      $��* �6+   .+�5n      �� $��0��5o      .+�5p      �� $��CCCD:��5q      $��14(�5r      $��SemiBold"�5s      �� 5u      $	��230��5v      $��35��5w      ���#DCF1FF$
��Left=�5y      $ 8��5z      $
 8, 0q�5{      $��
0, 8, 0, 0q�5|      ._�5}      ��  �� 
IsEditable$
 True��5~   !    �� StaysOpenOnEdit$
 True��5   !    �� IsTextSearchEnabled$
 True��5�   !   $ IdentityNumber��5�   !   $	 	Collapsed=�5�   !   $��0q�5�   !   ��5�   !   �� *Suggestions+ 5�   !   �� *SelectedCustomer+$
 PropertyChanged=� �� Text 5�   "   �� 5�   &    �� Path$ Customer.IdentityNumber�6.   $ TwoWay=�6M   $
 PropertyChanged=�6[    �� ValidationRules 5�   *   7   1QuanLyKhachSan.ValidationRules.CCCDValidationRule  5�   .   5�   '   5�      5�      5�      �� 5�      $��1��5�      $��Right=�5�      .+�5�      �� $��Số điện thoại:��5�      $��14(�5�      $��SemiBold"�5�      �� 5�      $	��230��5�      $��35��5�      ���#DCF1FF$
��Left=�5�      $ 8��5�      $
 8, 0q�5�      $��
0, 8, 0, 0q�5�      ._�5�      �� $	 	Collapsed=�5�   !   $��0q�5�   !   .��65   ��5�   "   �� 5�   &   $ Customer.PhoneNumber�6.   $ TwoWay=�6J   $
 PropertyChanged=�6X    5�   *   >   8QuanLyKhachSan.ValidationRules.PhoneNumberValidationRule  5�   .   5�   '   .��5�   0   5�      5�      5�      5�      �� 5�         BlueButtonStyle#���   5�      $
��Lưu��5�      $��80��5�      $��35��5�      $��Right=�5�      $��4q�5�      $
 Hand��5�      $��0, 24, 0, 0q�5�      ��5�      �� *Save+5�      5�      5�      5�      5�      