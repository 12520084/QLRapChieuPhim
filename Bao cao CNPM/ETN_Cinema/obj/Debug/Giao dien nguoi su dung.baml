   M S B A M L   `   `   `  ����  
ETN_Cinema(    "ETN_Cinema.Giao_dien_nguoi_su_dung   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Thông tin khách hàng��5   	   $	��600��6&   $
��1095��63    � WindowStartupLocation$ CenterScreen=�6@    � 
ResizeMode$ CanMinimize=�6e   .��5      � $��	0,0,4,-98q�6   $	��364��6   $��Bottom=�6+   .+�5   
   o� -   5        $��mn_QuanLiNhanSu��5   "    o� 
IsMainMenu . $��84��69   $	��Top=�6E   ���	#FF000204$��-6,-305,-4,0q�6t   .@�5      m� -   5         m�Name$ mn_XemThongTin��5      $��82��6/   $	��158��6;    m� Icon 5      �� 5	      $-��'resource\people_manage\view_profile.png��6   $��40��6O   $��0,0,-12,-24q�6[    J� RenderTransformOrigin$ 0.638,-0.295&�6p   ��5      �� 5      $��Xem Thông Tin��6    $��
10,0,-45,0q�65   $
��Left=�6I   $	��111��6d   ���	#FFF98800$��15(�6�   $
��Bold"�6�   5      m� 5      -   5        $ mn_SuaThongTin��5      $��85��6/   $	��147��6;    5      �� 5      $%��resource\people_manage\edit.png��6   $��40��6G   $��0,0,-12,-24q�6S   $ 0.638,-0.295&�6h   ��5      �� 5      $��Sửa Thông Tin��6    $��
10,0,-55,0q�65   ���	#FFF98800$��15(�6`   $
��Bold"�6n   5      m� 5      -   5        $ mn_XemThongTinDatVe��5      $��85��64   $	��196��6@    5      �� 5      $*��$resource\customer_manage\tickeet.png��6   $��40��6L   $��0,0,-12,-24q�6X   $ 0.638,-0.295&�6m   ��5      �� 5      $��Xem thông tin đặt vé��6    ���	#FFF98800$��15(�6S   $
��Bold"�6a   $��
10,0,-10,0q�6s   5      m� 5      -   5        $ mn_SuaThongTinDatVe��5      $��85��64   $	��192��6@    5       �� 5!      $.��(resource\customer_manage\edit_ticket.png��6   $��40��6P   $��0,0,-12,-24q�6\   $ 0.638,-0.295&�6q   ��5#      �� 5$      $!��Sửa thông tin đặt vé��6    ���	#FFF98800$��15(�6S   $
��Bold"�6a   $��
10,0,-10,0q�6s   5&      m� 5'      -   5        $ mn_DatVe��5'      $��85��6)   $��96��65    5(      �� 5)      $.��(resource\customer_manage\book_ticket.png��6   $��40��6P   $��0,0,-12,-24q�6\   $ 0.638,-0.295&�6q   ��5+      �� 5,      $��
Đặt Vé��6    ���	#FFF98800$��15(�6E   $
��Bold"�6S   $��
10,0,-10,0q�6e   5.      m� 5/      -   5        $ mn_DoiMatKhau��5/      $��84��6.   $	��142��6:   $��Center=�6F    50      �� 51      $&�� resource\people_manage\chage.png��6   $��40��6H   $��0,0,-12,-24q�6T   $ 0.638,-0.295&�6i   ��53      �� 54      $��Đổi Mật Khẩu��6    $��	10,0,-9,0q�64   $ 0.753,3.557&�6G   ���	#FFF98800$��15(�6�   $
��Bold"�6�   56      m� 57      -   5        $ mn_Xuat��57      $��84��6(   $	��126��64   $��Center=�6@    58      �� 59      $'��!resource\people_manage\logout.png��6   $��40��6I   $��0,0,-12,-24q�6U   $ 0.638,-0.295&�6j   ��5;      �� 5<      $��Đăng Xuất��6    $��	10,0,-9,0q�61   $ 0.753,3.557&�6D   ���	#FFF98800$��15(�6   $
��Bold"�6�   5>      5?      5@       J� CommandBindings 5A      )  #System.Windows.Input.CommandBinding  5B   
   -	   5           Command$ ApplicationCommands.Open��5B      6<   	 J� InputBindings	 5D      �� 5E   
   
 �� Command$
 ApplicationCommands.Open��6   
 �� Key$ Q��5F      5H      