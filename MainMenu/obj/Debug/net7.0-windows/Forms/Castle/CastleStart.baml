   M S B A M L   `   `   `  ����C  ?MainMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MainMenuMainMenu  5   	       MainMenu.CastleStart   5       localclr-namespace:MainMenu  5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	      MainMenu.GameWindow    KeyDown$  ShowMenu��5   _    � Title$ Castle��6	   $	��865��6   $
��1540��6%   ���#535C91 � WindowState$ 	Maximized=�6G   .��5
      �� -   5         ��Name$ 
GameScreen��5
      $
|�True��6!   .+�5   
   � -   5         �Name$ PlayerHealthBar��5   G      HealthProgressBarStyle#���   6   $��15��6`    � Value$ 10Q�6l    � Maximum$ 10Q�6w    �� Left$ 16��6�   
 �� Top$ 16��6�   $	��250��6�   � 5   
   -   5        $ PlayerStaminaBar��5   H     StaminaProgressBarStyle#���  6   $��15��6b   $	 100Q�6n   $	 100Q�6z   $ 16��6�   $ 32��6�   $	��200��6�   ]� 5   
   $ 16��6   $ 64��6%   .+�5      �� $#��/Images/Potions/hp_potion.png��6   $��75��6;   $��75��6F   �� 5      -   5        	 ��Name$	 	RestEstus��5      $��50��6'   $��25��62   $��22(�6>   ���#FC4100$��Bottom=�6a   $��	-25,0,0,0q�6|   $��0,0,0,0q�6�   $
��Left=�6�   �� 5      .��5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5      �� $��/Images/SoulCoins.png��6   $��25��6;   $��25��6F   �� 5      -   5        $	 	RestCoins��5      $��Center=�6/   $��10,0,0,0q�6J   $��20(�6\   ���#6DC5D16�   5      5      5      �� 5   
   $��
Замок��6   $	��100(�6!   $	 676��60   $	 102��6B   $��Gabriola)�6S    J� Opacity$ 0Q�6i    � Triggers 5      :� 5       :� RoutedEvent$ Loaded��6   .[�5      �� .��5      ��  g� AutoReverse$
 True��6%    g� 	BeginTime 0:0:1.568   .��5      W�  �� TargetProperty$ Opacity�6.    g� Duration$ 0:0:3D�6R    W� From 06c   	 W� To 16l   5       5!      5"      5$       � 5&   
   -   5          �Name$ EscMenuFrame��5&        � NavigationUIVisibility$ Hidden=�6&    K� ZIndex$ 6��6F   $ 0��6W   $
��1920��6g   $��Center=�6t   $��	0,0,350,0q�6�   $	 0.5Q�6�   �� 5(   
   $��10��6   $	��425��6   ���#EEEEEE
���   �
 � Tag$
 door��6J   $
 1530��6U   $
��Left=�6h   $��Center=�6�   $	 212��6�   �� 5)   
   $��80��6   $	��300��6   ���#1B1A55
���   �$
��Left=�6J   $	��Top=�6e   $
 wall��6}   $	 539��6�   $	 384��6�   �� 5*   
   $��80��6   $	��300��6   ���#1B1A55
���   �$
 wall��6J   $ 5��6U   $	 384��6d   $��Center=�6v   $��Center=�6�   �� 5+   
   $��42��6   $	��222��6   ���#1B1A55
���   �$
 wall��6J   $
 1498��6U   $
��Left=�6h   $��Center=�6�   �� 5,   
   $��42��6   $	��212��6   ���#1B1A55
���   �$
 wall��6J   $
 1498��6U   $
��Left=�6h   $��Center=�6�   $	 637��6�   �� 5-   
   $��60��6   $	��300��6   ���#1B1A55
���   �$
 wall��6J   $	 424��6U   $
 1250��6f   $��Center=�6y   $	��Top=�6�   �� 5.   
   $��60��6   $	��300��6   ���#1B1A55
���   �$
 wall��6J   $	 124��6U   $
 1250��6f   $��Center=�6y   $	��Top=�6�   5/      50      