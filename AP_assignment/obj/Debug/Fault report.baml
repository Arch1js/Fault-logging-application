   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Fault Logger   Fault_Logger.FaultReport   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ Fault Report��5   	   $	��700��6   $
��1000��6+    � WindowStyle$ 
ToolWindow=�68    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ btnHome��5      $
��Home��6&   65   �� 5      -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6l   5      5      .��5      � .+�5   
   �� $��
Fault card��6   $
��Left=�6'   $	��590��6B   $��
697,52,0,0q�6O   $	��Top=�6c   $	��275��6{   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dgUsers��5      $
��Left=�6$   $	��579��6?   $��	10,57,0,0q�6L   $	��Top=�6_   $	��676��6w     AzureDataGrid#��[ 6�   6�   �� 5   
   -   5         ��Name$ txtSearchQuery��5      $
��Left=�6*   $��23��6E   $��	13,15,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��244��6�      ClearTextButton . 6�   �� 5   
   -   5        $ txtMachineID��5      $
��Left=�6(   $��29��6C   $��799,142,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��148��6�   �� 5   
   -   5        $ 
txtStaffID��5      $
��Left=�6'   $��29��6B   $��
799,98,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��148��6�   �� 5   
   -	   5        $ txtStaffName��5      $
��Left=�6(   $��29��6C   $��799,223,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��148��6�   �� 5   
   -
   5        $ txtStaffSurname��5      $
��Left=�6+   $��29��6F   $��799,264,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��148��6�   �� 5   
   -   5         ��Name$ 
lblStaffID��5      $��	Staff ID:��6$   $
��Left=�68   $��29��6S   $��
708,98,0,0q�6_   $	��Top=�6s   $��86��6�   �� 5   
   -   5        $ lblMachineID��5      $��Machine ID:��6&   $
��Left=�6<   $��29��6W   $��708,142,0,0q�6c   $	��Top=�6x   $��86��6�   �� 5   
   -   5        $ lblStaffName��5      $��Staff Name:��6&   $
��Left=�6<   $��29��6W   $��708,223,0,0q�6c   $	��Top=�6x   $��86��6�   �� 5   
   -   5        $ lblStaffSurname��5      $��Staff Surname:��6)   $
��Left=�6B   $��29��6]   $��708,264,0,0q�6i   $	��Top=�6~   $��86��6�   �� 5   
   -   5        $ lblComments��5      $��	Comments:��6%   $
��Left=�69   $��23��6T   $��721,307,0,0q�6`   $	��Top=�6u   $	��111��6�   �� 5   
   -   5        $ btnContinue��5      $��Continue��6&   $
��Left=�69   $��23��6T   $��844,600,0,0q�6`   $	��Top=�6u   $��90��6�   ���	#FF15A9EE6�   �� 5    
   -   5        $ btnClear��5       $��Clear��6#   $
��Left=�63   $��728,600,0,0q�6N   $	��Top=�6c   $��88��6{   ���	#FFE0362E6�   �� 5!   
   -   5        $ txtComments��5!      $
��Left=�6'   $	��258��6B   $��721,335,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��226��6�    �� AcceptsReturn .  �� 
AcceptsTab .  �� AutoWordSelection .  �� 	MaxLength$	 200��6�   6�   �� 5"   
   -   5        $ 	txtZoneNo��5"      $
��Left=�6%   $��29��6@   $��799,182,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��148��6�   �� 5#   
   -   5        $ 	lblZoneNo��5#      $��Zone:��6#   $
��Left=�63   $��29��6N   $��713,182,0,0q�6Z   $	��Top=�6o   $��86��6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5$   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6(   $��
220,21,0,0q�66   $��14��6J   $��14��6V     5%   
   $ 
AngleRight=�6(   $��920,607,0,0q�6:   $��12��6O   $��14��6[     5&   
   $ Times=�6(   $��746,609,0,0q�65   $��8��6J   $��8��6U   �� 5'   
   -   5        $ lblTextCount��5'      $�� ��6&   $
��Left=�61   $��23��6L   $��883,307,0,0q�6X   $	��Top=�6m   $��64��6�   5(      5)      