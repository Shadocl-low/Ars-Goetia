   M S B A M L   `   `   `  ����C  ?MainMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MainMenuMainMenu  5   	       MainMenu.OptionMenu   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MainMenu     5   	     � Title$  
OptionMenu��5   	   $
��1080��6   $
��1920��6*    � WindowState$ 	Maximized=�67    � WindowStyle$
 None=�6O   
���   �.��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5         ��Name$ GameOptionsUnderline��5      
���   �$��1q�6G    �� CornerRadius$ 50��6[   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      � 	 � Color$	 Black��6'   
 � Offset$	
 0.7Q�65   � 5      $	 	#FF454545��6'   $
 1Q�69   5      ._�5      �� -   5         ��Name$ GameOptions��5      $
��Game��6.   $��80(�6=   $��50,0,50,-20q�6c   $	��350��6x   $��Gabriola)�6�   5      �� 5      -   5        $ WindowOptionsUnderline��5      
������ $��1q�6O   $ 50��6c   ._�5      �� -   5        $ WindowOptions��5      $��Window��60   $��80(�6A   $��50,0,50,-20q�6i   $	��350��6~   $��Gabriola)�6�   6�   5      5       � 5   
   -   5          �Name$ OptionControl��5      $��1��6'   
���iii�  � NavigationUIVisibility$ Hidden=�6I   6k   �� 5   
   -   5        $ QuitBtnOption��5      $��2��6(   $
��Back��65   ���#000000���#000000
�������$��45(�6�   $��Gabriola)�6�   $��Right=�6�   $��0,0,50,0q�6�   5      5       