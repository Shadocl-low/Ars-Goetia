   M S B A M L   `   `   `  ����W  SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   StaminaProgressBar.Progress  � Color � Offset ! StaminaProgressBar.Background �� Color  StaminaProgressBar.Border  BossProgressBarStyle �� 
TargetType �� Property �� Value �� 
TargetType �Name'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard g� RepeatBehavior �� 
TargetName �� TargetProperty9   3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8   2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        &	 �     &	     &	 $    7   7  7  �� 5      .��5   
   � $  #872341��6   $
 0.20Q�6'   � 5   
   $  #F05941��6   $
 0.25Q�6'   � 5   
   $  #F05941��6   $
 0.75Q�6'   � 5   
   $  #872341��6   $
 0.80Q�6'   5      �� 5	      $ 	#FFE6E6E6��6<   �� 5
      $ 	#FFBCBCBC��68   �� 5      " �6)   .�5   
   ��  � ��8   6'   �� 5   
    � ��8  6'   �� 5   
    � ��8  6(   �� 5   
    � ��$ 1q�6,   �� 5   
    � �� 5      �� 5      " �6"   .R�5      � $ TemplateRoot��6    5        5      CommonStates��.	 5   "     Determinate��6.     5   "   Indeterminate��.
 5   &   �� $ Forever��61   .��5   *   U� $ 	Animation��6H   $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6j   .\�5   .     $ 0��6C   $
 0.25Q�6O     5   .   $ 0:0:1��6C   $
 0.25Q�6S     5   .   $ 0:0:2��6C   $
 0.25Q�6S   5   +   *� 5   *   $ 	Animation��6G   $' !(UIElement.RenderTransformOrigin)�6i   .'�5    .     $ 0��6B   $ -0.5,0.5&�6N     5!   .   $ 0:0:1��6B   $ 0.5,0.5&�6R     5"   .   $ 0:0:2��6B   $ 1.5,0.5&�6R   5#   +   5$   '   5%   #   5&      .+�5(      �� #��z��6!   #��z��6K   #��z��6w   �� 5)      $ 
PART_Track��6$   � 5*      $ PART_Indicator��6   $
}�true��67   $
��Left=�6K   .+�5+      �� $ 	Indicator��6(   #��z��6;   �� 5,      $ 	Animation��6(   #��z��6;   $ 0.5,0.5&�6_   z�5-   "   V� 5.   &   .~�5/   *   �� �� 50   *   �� 51   *   T� 52   *   53   '   55      56      57       58      P� 59       �@�Orientation$ Vertical=�69   . �5:      �� $ TemplateRoot��6@    �@�LayoutTransform 5;   "   �� 5<   &   $	 -90Q�66   5>      5?      P� 5@       �@�IsIndeterminate$
 true��6=   . �5A      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5B      5D      5F      5G      5H      