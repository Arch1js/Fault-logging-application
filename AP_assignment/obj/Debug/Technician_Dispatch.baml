   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Fault Logger&    Fault_Logger.Technician_Dispatch   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ Dispatch��5   	   $	��600��6   $	��800��6'    � WindowStyle$ 
ToolWindow=�63    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6l   5      5      .��5      � .+�5   
   �� -   5        	 ��Name$	 btnFault��5      $��User reported fault��6#   $
��Left=�6A   $��45��6\   $��
90,235,0,0q�6h   $	��Top=�6|   $	��258��6�   +   %MahApps.Metro.Controls.ControlsHelper
   ContentCharacterCasing$
 Upper=�6�   ���	#FF2294E4$��14.667(�6  $
��Bold"�6  �� 5   
   -   5        $	 btnMaintenance��5      $��Maintenance Job��6)   $
��Left=�6C   $��45��6^   $��
83,333,0,0q�6j   $	��Top=�6~   $	��258��6�   ���	#FF4DAA62$��14.667(�6�   �� 5   
   -   5        $	 	btnReport��5      $��Reports��6$   $
��Left=�66   $��46��6Q   $��426,235,0,0q�6]   $	��Top=�6r   $	��266��6�   ���	#FFD34D00$��16(�6�   �� 5   
   $��Technician Dispatch��6   $
��Left=�6.   $��75��6I   $��217,127,0,0q�6U   $	��Top=�6j   $	��447��6�   $��36(�6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$
 Book=�6(   $��108,247,0,0q�64   $��21��6I   $��21��6U     5   
   $ Wrench=�6(   $��108,345,0,0q�66   $��21��6K   $��21��6W     5   
   $ BarChart=�6(   $��490,247,0,0q�68   $��21��6M   $��22��6Y   �� 5   
   -   5        $	 	btnManage��5      $��Manage Jobs��6$   $
��Left=�6:   $��45��6U   $��426,332,0,0q�6a   $	��Top=�6v   $	��266��6�   ���	#FF737E87$��16(�6�     5   
   $ Users=�6(   $��465,345,0,0q�65   $��21��6J   $��21��6V   5      5      