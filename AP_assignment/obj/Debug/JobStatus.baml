   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Fault Logger   Fault_Logger.JobStatus   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ 
Job Status��5   	   $	��600��6   $	��450��6)    � WindowStyle$ 
ToolWindow=�65    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6l   5      5      .��5      � .+�5   
   �� -   5        	 ��Name$	 txtJobID��5      $
��Left=�6$   $��23��6?   $��
162,39,0,0q�6K   
 �� TextWrapping$

 Wrap=�6_   $	��Top=�6s   $	��142��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $	 txtZone��5      $
��Left=�6#   $��23��6>   $��
162,87,0,0q�6J   $

 Wrap=�6^   $	��Top=�6r   $	��142��6�    . 6�   �� 5   
   -   5        $ 	cmbStatus��5      $
��Left=�6&   $��25��6A   $��162,139,0,0q�6M   $	��Top=�6b   $	��142��6z   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   $ Please select��6�   .@�5      �� $��
Unresolved��6   $
��Left=�60   $	��146��6K   �� 5      $��Finished��6   $
��Left=�6.   $	��146��6I   5      �� 5   
   -   5        $	 txtComments��5      $
��Left=�6'   $��71��6B   $��
80,260,0,0q�6N   $

 Wrap=�6b   $	��Top=�6v   $	��272��6�    . 6�   �� 5   
   -   5         ��Name$ 
lblSummary��5      $��Job No.��6$   $
��Left=�66   $��	94,39,0,0q�6Q   $	��Top=�6d   �� 5   
   -	   5        $ lblZone��5      $
��Zone��6!   $
��Left=�60   $��
107,87,0,0q�6K   $	��Top=�6_   �� 5   
   -
   5        $ 	lblStatus��5      $��
Job Status��6#   $
��Left=�68   $��
80,139,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ lblComments��5      $��Dispatch Comments��6%   $
��Left=�6A   $��
80,229,0,0q�6\   $	��Top=�6p   $	��143��6�   �� 5   
   -   5         ��Name$ btnSave��5      $
��Save��6#   $
��Left=�62   $��29��6M   $��234,502,0,0q�6Y   $	��Top=�6n   $	��112��6�   $��14(�6�   ���	#FF4F9DDE6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ FloppyOutline=�6(   $��254,512,0,0q�6=   $��12��6R   $��12��6^   �� 5   
   -   5        $ lblTechComments��5      $��Technician Comments��6)   $
��Left=�6G   $��
80,356,0,0q�6b   $	��Top=�6v   $	��143��6�   �� 5    
   -   5        $	 txtTechComments��5       $
��Left=�6+   $��71��6F   $��
80,391,0,0q�6R   $

 Wrap=�6f   $	��Top=�6z   $	��272��6�   �� 5!   
   -   5        $ 	btnCancle��5!      $��Cancle��6$   $
��Left=�65   $��29��6P   $��
95,502,0,0q�6\   $	��Top=�6p   $	��112��6�   $��14(�6�   ���	#FFC50000 �� IsCancel . 6�     5"   
   $	 ban=�6(   $��107,512,0,0q�63   $��12��6H   $��12��6T   �� 5#   
   -   5        $	 txtTime��5#      $
��Left=�6#   $��23��6>   $��162,184,0,0q�6J   $

 Wrap=�6_   $	��Top=�6s   $	��142��6�    . 6�   �� 5$   
   -   5        $ lblTime��5$      $��
Request at��6!   $
��Left=�66   $��
80,184,0,0q�6Q   $	��Top=�6e   5%      5&      