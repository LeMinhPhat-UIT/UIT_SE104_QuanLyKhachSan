   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:QuanLyKhachSan.UI.Views.SubViews QuanLyKhachSan.UI.Views.SubViews  5   	   :    4QuanLyKhachSan.UI.Views.SubViews.AddUpdateRoomWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   X TXceed.Wpf.Toolkit, Version=4.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   :local.clr-namespace:QuanLyKhachSan.UI.Views.SubViews  5   	   -   5          � Title$  AddRoomWindow��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $	��400��5   	   $	��600��5   	   .��5      � .+�5   
   �� $	��600��5      $	��400��5      ���#FFFFFF �� CornerRadius$ 12��5       �� Padding$ 48, 24q�5      ._�5      �� $}�False��5      .+�5      �� $��22��5      $��22��5       $��Right=�5!       � Cursor$
 Hand��5"      $��0, -8, -24, 0q�5#      $��0q�5$      ��5      �� *Close+.��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeleteOutline=�6.   $��22��6C   $��22��6N   5&      �� 5(      $��Nhập thông tin phòng��5)      $��24(�5*      $��SemiBold"�5+      ���#1570EF$��0, -12, 0, 0q�5-      � 5/      $��0, 24, 0, 0q�50       � ColumnDefinitions 51      �� 52      $��* �6+   �� 53      $��* �6+   .+�56      �� $��0��57      .+�58      �� $��Số phòng:��59      $��14(�5:      $��SemiBold"�5;      �� 5=      $	��230��5>      $��35��5?      ���#DCF1FF$
��Left=�5A      $ 8��5B      $
 8, 0q�5C      $��
0, 8, 0, 0q�5D      ._�5E      �� .  (MaterialDesignThemes.Wpf.TextFieldAssist	   DecorationVisibility$	 	Collapsed=�5G   !   $��0q�5H   !   ��5F   !   �� *Room.RoomNumber+5H   !   5I      5J      �� 5L      $��1��5M      $��Right=�5N      $��22, 0, 0, 0q�5O      .+�5P      �� $��Loại phòng:��5Q      $��14(�5R      $��SemiBold"�5S      �� 5U      $	��230��5V      $��35��5W      ���#DCF1FF$ 8��5Y      $
 8, 0q�5Z      $��
0, 8, 0, 0q�5[      ._�5\      �� 
 �� DisplayMemberPath$
 RoomTierName��5^   !   $	 	Collapsed=�5`   !   $��0q�5a   !   $��35��5b   !   ��5]   !   �� *	RoomTiers+ �� SelectedItem 5_   !   �� *SelectedTier+5c      5d      5e      5f      � 5h      $��0, 24, 0, 0q�5i       5j      �� 5k      $��* �6+   �� 5l      $��* �6+   .+�5o      �� $��0��5p      .+�5q      �� $��Giá (VNĐ):��5r      $��14(�5s      $��SemiBold"�5t      �� 5v      $	��230��5w      $��35��5x      ���#DCF1FF$
��Left=�5z      $ 8��5{      $
 8, 0q�5|      $��
0, 8, 0, 0q�5}      ._�5~      ��  �� 
IsReadOnly$
 True��5   !   $	 	Collapsed=�5�   !   $��0q�5�   !   ��5�   !   �� *Room.PricePerDay+ �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ {0:N0}��5�   !   5�      5�      �� 5�      $��1��5�      $��Right=�5�      .+�5�      �� $��Tình trạng:��5�      $��14(�5�      $��SemiBold"�5�      �� 5�      $	��230��5�      $��35��5�      ���#DCF1FF$
��Left=�5�      $ 8��5�      $
 8, 0q�5�      $��
0, 8, 0, 0q�5�      ._�5�      �� $ 	Available��5�   !    �� 
IsEditable$ False��5�   !   ${�False��5�   !   $	 	Collapsed=�5�   !   $��0q�5�   !   $��35��5�   !   ��5�   !   �� *
RoomStates+5�      5�      5�      5�      �� 5�      $��0��5�      $��0, 24, 0, 0q�5�      .+�5�      �� $��Cơ sở vật chất:��5�      $��14(�5�      $��SemiBold"�5�      �� 5�      $	��504��5�      $��35��5�      ���#DCF1FF$
��Left=�5�      $ 8��5�      $
 8, 0q�5�      $��
0, 8, 0, 0q�5�      ._�5�      %  Xceed.Wpf.Toolkit.CheckComboBox  -   5          Name$ CheckComboBox��5�      $
 AmenityName��5�      $	 	Collapsed=�5�      $��0q�5�      
������ $��35��5�      ��5�      �� *	Amenities++  %Xceed.Wpf.Toolkit.Primitives.Selector   SelectedItemsOverride 5�      �� *SelectedAmenities+5�      5�      5�      �� 5�         BlueButtonStyle#���   5�      $
��Lưu��5�      $��80��5�      $��35��5�      $��Right=�5�      $��4q�5�      $
 Hand��5�      $��0, 24, 0, 0q�5�      ��5�      �� *Save+5�      5�      5�      5�      5�      