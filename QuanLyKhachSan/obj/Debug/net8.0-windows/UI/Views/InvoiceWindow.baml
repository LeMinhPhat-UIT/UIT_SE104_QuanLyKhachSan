   M S B A M L   `   `   `  ����I  EQuanLyKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:QuanLyKhachSan.UI.ViewsQuanLyKhachSan.UI.Views  5   	   +    %QuanLyKhachSan.UI.Views.InvoiceWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:QuanLyKhachSan.UI.Views  5   	     � Title$  InvoiceWindow��5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	   
������ $
��Auto��5   	   $
��Auto��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� $��1��5      
������� �� CornerRadius$ 12��5      $	��700��5      $	��440��5      $��Center=�5      $��Center=�5      $��0, 24, 16, 0q�5      ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   .+�5$      �� $��0��5%      $	��440��5&      $��56��5'      ���#1570EF$ 	12 12 0 0��5)      ._�5*      �� $��
Hóa Đơn��5+      $��22(�5,      $��SemiBold"�5-      
�������$��Center=�5/      $��Center=�50      51      �� 53      $��1��54      $	��408��55      $��0, 16q�56      $��Center=�57      $��Hidden=�58      .��59      �� .+�5:      �� ��6'   �� ��5;      �� 5<   "   .R�5=   &   �� $��0,0,0,12q�61   .+�5>   *   �� $��22(�6F   $��Medium"�6T   ��64   �� 6T   � 5?   *    � ColumnDefinitions 5@   .   �� 5A   2   $��* �6C   �� 5B   2   $��* �6C   .+�5E   .   �� $��0��5F   )   $
��Left=�5G   )   $��20(�5I   )   $��Medium"�67   ��5H   )   �� 5I   7   �� 5K   .   $��1��5L   )   $��Right=�5M   )   $��20(�5O   )   $��Medium"�67   ��5N   )   �� 5O   7   5P   +   �� 5R   *   $��18(�6F   $��Medium"�6T   ��64   �� 6T   �� 5S   *   $��0 8 0 0q�64   ���#DDD6E   5T   '   5U   #   5W      �� 5Y      ��6'   �� ��5Z      �� 5[   "   .R�5\   &   �� $��0,0,0,12q�61   .+�5]   *   �� $��22(�6F   $��Medium"�6T   ��64   �� 6T   �� 5_   *   $��20(�5a   %   $��Medium"�5b   %   ��5`   %   �� 5b   %   �� 5d   *   $��0 8 0 0q�64   ���#DDD6E   5e   '   5f   #   5h      5i      5j      �� 5l      $��2��5m      $��16,8,0,8q�5n      $
��Left=�5o      .+�5q      �� $"��Phương thức thanh toán:��5r      $��18(�5s      $
��Bold"�5t      �� 5v       �� Orientation$ 
Horizontal=�5w      .+�5x      	� $��Tiền mặt��6&   	 	� 	GroupName$	 PaymentMethod��69   $��20(�6S   $
��10,5q�6a   	� 5y      $��Thẻ��6&   $	 PaymentMethod��64   $��20(�6N   $
��10,5q�6\   5z      5{      �� 5}      $��3��5~      $��	0 0 16 22q�5      $ 
Horizontal=�5�      $��Right=�5�      .+�5�      �� $��Tổng: ��6    $
��Bold"�6.   $��20(�6@   �� 5�      $��20(�62   ��6    �� 62   5�      �� 5�      $��4��5�         BlueButtonStyle#���   5�      $	��200��5�      $��50��5�      
 � Cursor$

 Hand��5�      $��0, 0, 0, 16q�5�      .��5�      �� $ 
Horizontal=�5�      .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��28��5�      $��28��5�      $��Center=�5�         Kind$ CartOutline=�5�      �� 5�      $��Thanh toán��5�      $��20(�5�      $��Center=�5�      $��
4, 0, 0, 0q�5�      5�      5�      5�      5�      5�      5�      