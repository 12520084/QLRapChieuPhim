   M S B A M L   `   `   `  ����  
ETN_Cinema$    ETN_Cinema.Giao_dien_dang_nhap   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Giao diện đăng nhập��5   	   $	��300��6%   $	��500��62    � WindowStartupLocation$ CenterScreen=�6>   ���	#FF000204.��5      �  � ColumnDefinitions 5   
   �� 5      $	��43* �6   �� 5      $
��188* �6   �� 5	      $	��15* �6   .+�5   
   �� $��Mã Đăng Nhập��6   $
��Left=�6'   $��	21,98,0,0q�6B   $	��Top=�6U   $��2��6m   $��Segoe WP Black)�6�   $��15(�6�   $
��Bold"�6�   ���	#FFF98800��6�   Z� 6�   �� 5   
   $��Mật Khẩu��6   $
��Left=�6#   $��
21,146,0,0q�6>   $	��Top=�6R   $��2��6j   $��Segoe WP Black)�6~   $��15(�6�   ���	#FFF988006�   �� 5   
   $ ��Hệ Thống Đăng Nhập��6   $
��Left=�6-   $��	65,10,0,0q�6H   $	��Top=�6[   $	��230��6s   $��1��6   $��Segoe WP Black)�6�   $��20(�6�   ���	#FFF988006�   �� 5   
   -   5        $��Đăng Nhập��5      $
��Left=�6&   $��
54,209,0,0q�6A   $	��Top=�6U   $	��120��6m   $��36��6�   $��1��6�    � Cursor$
 Hand��6�   
����������	#FFF98800 � ForceCursor . $��Segoe WP Black)�6�   $��15(�6  5      �� 5   
   -   5        $��tb_MaNV��5      $
��Left=�6!   $��30��6<   $��	54,98,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��139��6�   $��1��6�    J� 	AllowDrop .  $��1q�6�   $ �� HorizontalScrollBarVisibility$ Visible=�6�   $��15(�6�   G� 5   
   -   5        $��pass_MK��5      $
��Left=�6%   $��
54,146,0,0q�6@   $	��Top=�6T   $	��139��6l   $��30��6x   $��1��6�   $��15(�6�   �� 5   
   -   5        $��image_login��5      $
��Left=�6#   $	��100��6>   $��
229,88,0,0q�6K   $	��Top=�6_   $	��100��6w    � UseLayoutRounding .  $��1��6�   ��5      �� 5      	 �� DecodePixelWidth$		 200��6   
 �� 	UriSource$#
 ..\resource\login\btn_Key.png?�5      5      �� 5   
   -   5        $��Nhập Lại��5      $��1��6$   $
��Left=�64   $��195,209,0,0q�6O   $	��Top=�6d   $	��100��6|   $��36��6�   ���	#FFF98800$��15(�6�   $��Segoe WP Black)�6�   6�   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      6<    J� InputBindings 5      �� 5   
    �� Command$ ApplicationCommands.Open��6   
 �� Key$ Enter��5       5"      