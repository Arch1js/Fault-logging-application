   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Fault Logger#   Fault_Logger.technicianReport   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ Technician Report��5   	   $	��700��6#   $
��1000��60    � WindowStyle$ 
ToolWindow=�6=    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ btnHome��5      $
��Home��6&   65   �� 5      -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6l   5      5      .��5      � -   5        
 �Name$
 gridAll��5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgTechnicians��5      $
��Left=�6*   $	��559��6E   $��
10,101,0,0q�6R   $	��Top=�6f   $	��972��6~   6�   �� 5   
   -   5        $ btnPrint��5      $��Print��6#   $��30��6N   $��875,37,23,603q�6Z   ���	#FF5FBEF36q   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Print=�6(   $��
888,47,0,0q�65   $��12��6I   $��12��6U   �� 5   
   -   5        $ btnBack��5      $
��Back��6"   $
��Left=�61   $��13��6L   $��	12,18,0,0q�6X   $	��Top=�6k   $��72��6�   ���	#FF0F9FBF6�     5   
   $ 	CaretLeft=�6(   $��	14,25,0,0q�69   $��12��6L   $��12��6X   9� 5   
    9� 
IsExpanded .  $��99,16,222,547q�6&   ���	#CCFFFFFF���	#CCFFFFFF$��Filters��6l   $	��107��6}   .��5      ��  �� Orientation$ 
Horizontal=�6   $��86��62   $��	0,0,-82,0q�6>   .+�5      �� -	   5        $ 
btnWorking��5      $��	40,0,0,56q�6-   $	��132��6@   ���	#FF3EB8F1.��6|   Working technicians6�   �� 5      -
   5        $ btnAvailable��5      $��	40,0,0,56q�6/   $��82��6B   ���	#FF54CD65.��6   	Available6�   �� 5      -   5        $ btnUnavailable��5      $��	40,0,0,56q�61   $��82��6D   
���  ��.��6}   Unavailable6�   �� 5      -   5        $ btnBreak��5      $��	40,0,0,56q�6+   $��82��6>   ���	#FF38C3F7.��6w   
On-break6�   �� 5      -   5        $ btnClear��5      $��	40,0,0,56q�6+   $��82��6>   ���	#FFF7E638.��6w   Clear6~   5      5       �� 5!   
   -   5         ��Name$ lblTime��5!      $�� ��6!   $
��Left=�6,   $��28��6G   $��	693,9,0,0q�6S   $	��Top=�6f   $	��175��6~   $��16(�6�   5"      5$      