   M S B A M L   `   `   `  ����  DatabaseManager     DatabaseManager.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $
��this��5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ DatabaseManager��5	   	   $	��350��6!   $	��600��6.    � DataContext 5
   	   %  System.Windows.Markup.Reference     Name$
 this����5      �� 5   
    �� ImageSource$ /Images/main_bg.png��6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��DatabaseManager��6   $��50(�6+   $��Center=�69   $��Center=�6V   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   $��1��6f   .+�5      �� $��Connection String:    ��6   �� 5      -   5        $��
txtAddress��5      $��20��6(   $	��350��64   ��6@   �� *MainWindowVM.Address+5      �� 5   
   -   5         ��Name$ 
btnConnect��5      $��_Connect��6>   $��25��6Q   $	��100��6]   $��2��6i   5      5      