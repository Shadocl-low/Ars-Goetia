   M S B A M L   `   `   `  ����W  SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ProgressBar.Progress  � Color � Offset  ProgressBar.Background �� Color  ProgressBar.Border  StaminaProgressBar.Progress ! StaminaProgressBar.Background  StaminaProgressBar.Border  StaminaProgressBarStyle �� 
TargetType �� Property �� Value �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard g� RepeatBehavior �� 
TargetName �� TargetProperty9   3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8   2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle  HealthProgressBarStyle�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %K  &	        &	 |     &	 �     &	 �     &	 >    &	 a    &	 �    7  7  7  &	 )    7   7  7  �� 5      .��5   
   � $  	DarkGreen��6   $
 0.25Q�6)   � 5   
   $  Green��6   $
 0.35Q�6%   5      �� 5      $ 	#FFE6E6E6��65   �� 5      $ 	#FFBCBCBC��61   �� 5
      .��5   
   � $  #FDE49E��6   $
 0.85Q�6'   � 5   
   $  #FEB941��6   $
 0.95Q�6'   5      �� 5      $ 	#FFE6E6E6��6<   �� 5      $ 	#FFBCBCBC��68   �� 5      " �6,   .�5   
   ��  � ��8   6'   �� 5   
    � ��8  6'   �� 5   
    � ��8  6(   �� 5   
    � ��$ 1q�6,   �� 5   
    � �� 5      �� 5      " �6"   .R�5      � $ TemplateRoot��6    5        5      CommonStates��.	 5   "     Determinate��6.     5   "   Indeterminate��.
 5   &   �� $ Forever��61   .��5   *   U� $ 	Animation��6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6j   .\�5    .     $ 0��6C   $
 0.25Q�6O     5!   .   $ 0:0:1��6C   $
 0.25Q�6S     5"   .   $ 0:0:2��6C   $
 0.25Q�6S   5#   +   *� 5$   *   $ 	Animation��6G   $' !(UIElement.RenderTransformOrigin)�6i   .'�5%   .     $ 0��6B   $ -0.5,0.5&�6N     5&   .   $ 0:0:1��6B   $ 0.5,0.5&�6R     5'   .   $ 0:0:2��6B   $ 1.5,0.5&�6R   5(   +   5)   '   5*   #   5+      .+�5-      �� #��z��6!   #��z��6K   #��z��6w   �� 5.      $ 
PART_Track��6$   � 5/      $ PART_Indicator��6   $
}�true��67   $
��Left=�6K   .+�50      �� $ 	Indicator��6(   #��z��6;   �� 51      $ 	Animation��6(   #��z��6;   $ 0.5,0.5&�6_   z�52   "   V� 53   &   .~�54   *   �� �� 55   *   �� 56   *   T� 57   *   58   '   5:      5;      5<       5=      P� 5>       �@�Orientation$ Vertical=�69   . �5?      �� $ TemplateRoot��6@    �@�LayoutTransform 5@   "   �� 5A   &   $	 -90Q�66   5C      5D      P� 5E       �@�IsIndeterminate$
 true��6=   . �5F      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5G      5I      5K      5L      �� 5N      " �6+   .�5O   
   ��  � ��8   6'   �� 5P   
    � ��8  6'   �� 5Q   
    � ��8  6(   �� 5R   
    � ��$ 1q�6,   �� 5S   
    � �� 5T      �� 5U      " �6"   .R�5V      � $ TemplateRoot��6    5W        5X      CommonStates��.	 5Y   "     Determinate��6.     5Z   "   Indeterminate��.
 5[   &   �� $ Forever��61   .��5\   *   U� $ 	Animation��6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6j   .\�5]   .     $ 0��6C   $
 0.25Q�6O     5^   .   $ 0:0:1��6C   $
 0.25Q�6S     5_   .   $ 0:0:2��6C   $
 0.25Q�6S   5`   +   *� 5a   *   $ 	Animation��6G   $' !(UIElement.RenderTransformOrigin)�6i   .'�5b   .     $ 0��6B   $ -0.5,0.5&�6N     5c   .   $ 0:0:1��6B   $ 0.5,0.5&�6R     5d   .   $ 0:0:2��6B   $ 1.5,0.5&�6R   5e   +   5f   '   5g   #   5h      .+�5j      �� #��z��6!   #��z��6K   #��z��6w   �� 5k      $ 
PART_Track��6$   � 5l      $ PART_Indicator��6   $
}�true��67   $
��Left=�6K   .+�5m      �� $ 	Indicator��6(   #��z��6;   �� 5n      $ 	Animation��6(   #��z��6;   $ 0.5,0.5&�6_   $��	20,20,0,0q�6   z�5o   "   V� 5p   &   .~�5q   *   �� �� 5r   *   �� 5s   *   T� 5t   *   5u   '   5w      5x      5y       5z      P� 5{       �@�Orientation$ Vertical=�69   . �5|      �� $ TemplateRoot��6@    �@�LayoutTransform 5}   "   �� 5~   &   $	 -90Q�66   5�      5�      P� 5�       �@�IsIndeterminate$
 true��6=   . �5�      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5�      5�      5�      5�      5�      