   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Fault Logger   Fault_Logger.Manage_Jobs   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$ Manage Jobs��5   	   $	��800��6   $
��1100��6*    � WindowStyle$ 
ToolWindow=�67    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ btnHome��5      $
��Home��6&   65   �� 5      -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6x   5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   $	��770��6*   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ txtSearchQuery��5      $
��Left=�6*   $��26��6E   $��	38,31,0,0q�6Q    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��219��6�      ClearTextButton . 6�   1  +MahApps.Metro.IconPacks.PackIconFontAwesome  5   
   �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6(   $��
220,36,0,0q�66   $��14��6J   $��14��6V   �� 5   
   .+�5      9�  9� 
IsExpanded .  $��284,35,19,571q�6*   ���	#CCFFFFFF���	#CCFFFFFF$��Filters��6p   $	��107��6�   .��5      ��  �� Orientation$ 
Horizontal=�6   $��86��66   $��0q�6B   .+�5      �� -   5        $ btnDoingFilter��5      $��Doing��65   $
��Left=�6E   $��33��6`   $��20,5,0,0q�6l   $	��Top=�6~   $	��170��6�   ���	#FF22E25F6�   �� 5      -   5        $ btnWaitingFilter��5      $��Waiting��67   $
��Left=�6I   $��33��6d   $��20,5,0,0q�6p   $	��Top=�6�   $	��170��6�   ���	#FFFFFF4A6�   �� 5      -   5        $ btnUnresolvedFilter��5      $��
Unresolved��6:   $
��Left=�6O   $��33��6j   $��20,5,0,0q�6v   $	��Top=�6�   $	��170��6�   ���	#FFF025256�   �� 5       -	   5        $ btnClear��5       $��Clear Filters��6/   $
��Left=�6G   $��33��6b   $��20,5,0,0q�6n   $	��Top=�6�   $	��170��6�   ���	#FF5B85F76�   5!      5"      5#      &   System.Windows.Controls.DataGrid  5$   
   -
   5          Name$ dgJobs��5$      $
��Left=�6#   $	��650��6>   $��
10,110,0,0q�6K   $	��Top=�6_   $
��1067��6w   |�. 6A  5%      5&      