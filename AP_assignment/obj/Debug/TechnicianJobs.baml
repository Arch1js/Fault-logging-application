   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.4.0.9, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    Fault Logger!   Fault_Logger.TechnicianJobs   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NMahApps.Metro.IconPacks, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$	  App��5       � Title$
 Jobs��5   	   $	��600��6   $	��450��6#    � WindowStyle$ 
ToolWindow=�6/    � WindowStartupLocation$ CenterScreen=�5   	      WindowTitleBrush
 �"�"�   AccentColorBrush   	GlowBrush# �   5	   	      RightWindowCommands 5
      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� -   5         ��Name$ cmbUser��5      $��0q�6(   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Account��6R   ��6<   Z� .@�5      �� -   5        $��Logout��5      $
��Left=�60   $	��146��6K   ���	#FF48BBDC6l   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgJobs��5      $��Center=�6#   $��
10,53,10,0q�6@     AzureDataGrid#��[ 6U   $	��422��6�   �� 5   
   -   5        
 ��Name$
 	lblStatus��5      $�� ��6#   $
��Left=�6.   $��27��6I   $��10,3,0,0q�6U   $	��Top=�6g   $	��141��6   �� 5   
   -   5        $
 lblMyStatus��5      $�� ��6%   $
��Left=�60   $��27��6K   $��	10,30,0,0q�6W   $	��Top=�6j   $	��141��6�   �� 5   
   -   5         ��Name$ btnBreak��5      $��I'm on break��6#   $
��Left=�6:   $��18��6U   $��
326,17,0,0q�6a   $	��Top=�6u   $	��106��6�   ���	#FF0AC51B6�   5      5      