   M S B A M L   `   `   `  ����  
ETN_Cinema3    -ETN_Cinema.Giao_dien_sua_thong_tin_khach_hang   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Giao diện sửa thông tin khách hàng��5   	   $	��388��64   $	��600��6A    � WindowStartupLocation$ CenterScreen=�6M    � 
ResizeMode$ CanMinimize=�6r   .��5      � 
���   �.+�5   
   �� -   5         ��Name$ lb_Title��5      $��THÔNG TIN KHÁCH HÀNG��6"   $��Center=�6A   $��175,10,118,0q�6^   $	��Top=�6t   $��20(�6�   $	��301��6�   ���	#FFF98800$
��Bold"�6�   �� 5   
   -   5        $ lb_HoTen��5      $��	Họ Tên��6"   $
��Left=�63   $��	48,65,0,0q�6N   $	��Top=�6a   $
��Bold"�6y   ���	#FFF98800$��30��6�   �� 5   
   -   5        $ 	lb_DiaChi��5      $��Địa Chỉ��6#   $
��Left=�65   $��
48,170,0,0q�6P   $	��Top=�6d   $
��Bold"�6|   ���	#FFF98800$��30��6�   �� 5	   
   -   5        $ lb_SDT��5	      $��Số Điện Thoại��6    $
��Left=�68   $��
48,205,0,0q�6S   $	��Top=�6g   $
��Bold"�6   ���	#FFF98800$��30��6�   �� 5
   
   -   5        $ lb_CMND��5
      $
��CMND��6!   $
��Left=�60   $��
48,240,0,0q�6K   $	��Top=�6_   $
��Bold"�6w   ���	#FFF98800$��30��6�   �� 5   
   -   5        $ lb_Email��5      $��Email��6"   $
��Left=�62   $��
48,275,0,0q�6M   $	��Top=�6a   $
��Bold"�6y   ���	#FFF98800$��30��6�   �� 5   
   -   5        $ lb_XuatMaKH��5      $��Label��6%   $
��Left=�65   $��
175,30,0,0q�6P   $	��Top=�6d   $��30��6|   �� 5   
   -   5         ��Name$ lb_XuatHoTen��5      $�� ��6(   $
��Left=�60   $��
175,65,0,0q�6K   $	��Top=�6_   $��20��6w   $	��234��6�   �� 5   
   -	   5        $ lb_XuatDiaChi��5      $�� ��6)   $
��Left=�61   $��175,174,0,0q�6L   $	��Top=�6a   $��20��6y   $	��234��6�   �� 5   
   -
   5        $ 
lb_XuatSDT��5      $�� ��6&   $
��Left=�6.   $��175,209,0,0q�6I   $	��Top=�6^   $��20��6v   $	��146��6�   �� 5   
   -   5        $ lb_XuatCMND��5      $�� ��6'   $
��Left=�6/   $��175,244,0,0q�6J   $	��Top=�6_   $��20��6w   $	��146��6�   �� 5   
   -   5        $ lb_XuatEmail��5      $�� ��6(   $
��Left=�60   $��175,279,0,0q�6K   $	��Top=�6`   $��20��6x   $	��234��6�   �� 5   
   -   5         ��Name$ 	btn_Close��5      $��Close��6$   $
��Left=�64   $��489,316,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ 
btn_Submit��5      $��Submit��6%   $
��Left=�66   $��326,314,0,0q�6Q   $	��Top=�6f   $��75��6~   $��22��6�   �� 5   
   -   5         ��Name$ cb_GioiTinh��5      $
��Left=�6(   $��175,100,0,0q�6C   $	��Top=�6X   $��69��6p   $��24��6{   �� 5   
   -   5        $ lb_GioiTinh��5      $��Giới Tính��6%   $
��Left=�69   $��
48,100,0,0q�6T   $	��Top=�6h   $
��Bold"�6�   ���	#FFF98800$��30��6�   �� 5   
   -   5        $ lb_NgaySinh��5      $��
Ngày Sinh��6%   $
��Left=�69   $��
48,135,0,0q�6T   $	��Top=�6h   $
��Bold"�6�   ���	#FFF98800$��30��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ datepicker_NgaySinh��5      $
��Left=�62   $��175,136,0,0q�6M   $	��Top=�6b   $��28��6z   $	��112��6�   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command$	 ApplicationCommands.Close��5      6=     5   
   -   5        $	 ApplicationCommands.Save��5      6<   
 J� InputBindings
 5      �� 5   
    �� Command$ ApplicationCommands.Close��6   
 �� Key$ Enter��69   �� 5   
   $ ApplicationCommands.Save��6   $ S��68    �� 	Modifiers$ Controlf�6@   5!      