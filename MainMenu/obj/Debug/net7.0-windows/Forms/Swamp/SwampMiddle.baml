   M S B A M L   `   `   `  ����C  ?MainMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MainMenuMainMenu  5   	   ;"clr-namespace:MainMenu.Forms.SwampMainMenu.Forms.Swamp  5   	   &     MainMenu.Forms.Swamp.SwampMiddle   5      gameclr-namespace:MainMenu  5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MainMenu.Forms.Swamp     5   	      MainMenu.GameWindow    KeyDown$  ShowMenu��5	   L    � Title$ SwampMiddle��6	   $	��865��6   $
��1540��6*   ���#0A6847 � WindowState$ 	Maximized=�6_   .��5
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
Horizontal=�6   .+�5      �� $��/Images/SoulCoins.png��6   $��25��6;   $��25��6F   �� 5      -   5        $	 	RestCoins��5      $��Center=�6/   $��10,0,0,0q�6J   $��20(�6\   ���#6DC5D16�   5      5      5       � 5   
   -   5          �Name$ EscMenuFrame��5        � NavigationUIVisibility$ Hidden=�6&    K� ZIndex$ 6��6F   $ 0��6W   $
��1920��6g   $��Center=�6t   $��	0,0,350,0q�6�    J� Opacity$	 0.5Q�6�   �� 5   
   $��48��6   $	��212��6   ���#6F4E37
���   �
 � Tag$
 wall��6J   $	 637��6U   $
��Left=�6f   $��Center=�6�   $
 1492��6�   �� 5   
   $��10��6   $	��425��6   ���#EEEEEE
���   �$
 door��6J   $
 1530��6U   $
��Left=�6h   $��Center=�6�   $	 212��6�   �� 5   
   $��48��6   $	��207��6   ���#6F4E37
���   �$
 wall��6J   $
 1492��6U   $��Center=�6h   $	��Top=�6�   $ 5��6�   5!      5"      