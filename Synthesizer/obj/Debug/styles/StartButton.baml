   M S B A M L   `   `   `  ����F  BSynthesizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Synthesizer.ControlsSynthesizer.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   StartButton  �� 
TargetType �� Property �� Value  CheckBoxFocusVisual �� 
TargetType �� 
Background �� Bullet ��Name �� Color �� 
StartPoint	 �� EndPoint
 � Color � Offset'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value  Bulb �� Triggers �� Binding �� ElementName �� Path �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,local"clr-namespace:Synthesizer.Controls  5      %�  &	        &	 �    �� 5      "  ��5      .�5   
   ��  �@J�SnapsToDevicePixels . 5      �� 5	   
    �@�OverridesDefaultStyle . 5
      �� 5   
    �@�FocusVisualStyle# �  5      �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� 
 ����  5      � 5      $��50��6#   $��70��5      .+�5   "   �� $ Border��6,   $��3��5      ��5   &   �� 5   *   $ Black��6:   6J   ��5   &   �� 5   *   $	 0,0&�6>   $		 0,1&�5   (   ��5   2   � � 5   6   $
 #f52100��6C   � 5   6   $
 #720000��6C   $	 1.0Q�5    '   5!   3   5#   +   5%   #   �� 5&   "   $ 	CheckMark��6,   $��3q�5'      $y�	Collapsed=�5(      ��5)   &   �� 5*   *   $	 0,0&�6>   $		 0,1&�5+   (   ��5-   2   � � 5.   6   $
 #720000��6C   � 50   6   $
 #f52100��6C   $	 1.0Q�51   '   52   3   54   +   57   #   58       5:        5;      CommonStates��. 5<   "     
Normal��6.     5?   "   Disabled��5A   #   5B        5C      CheckStates��. 5D   "     Checked��. 5E   &   �� .��5F   *   T� $ (UIElement.Visibility)�6H   $ 	CheckMark��5G   2   ..�5H   .   i� $ 0��6E   # Z 5I   -   5J   +   5K   '   5L   #     5M   "   	Unchecked��6.     5N   "   Indeterminate��6.   5O      ._�5Q      �� $��4,0,0,0q�6+   $��Center=�5R      $
��Left=�5S      ��. 5T      5U      5V      5X      5Y      �� 5\      "  A�6    5^   
   �� 5_       6   �� $ On��$ 	IsChecked� True6L   .a�5`      ��  � �� 5a      
� 5b      .��5c      � $
 #e63635��6+   $ 0Q�6;   6H   � 5d      $
 #970302��6+   $ 1Q�6;   6H   5e      5g      5h      �� 5j       6   �� $ On��$ 	IsChecked�	 False6L   .a�5k      ��  � �� 5l      
� 5m      .��5n      � $
 #a20302��6+   $ 0Q�6;   6H   � 5o      $
 #440302��6+   $ 1Q�6;   6H   5p      5r      5s      5u      5y      