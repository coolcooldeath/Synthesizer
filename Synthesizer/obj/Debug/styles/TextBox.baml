   M S B A M L   `   `   `  ����F  BSynthesizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Synthesizer.stylesSynthesizer.styles  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� Property �� Value-   'System.Windows.Input.KeyboardNavigation �� 
TargetType �� CornerRadius �� Padding   ControlLightColor �� Color  BorderMediumColor'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime  DisabledControlLightColor �� Value  DisabledControlDarkColor ��Name�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *local clr-namespace:Synthesizer.styles  5      %$  '��       7  7  �� 5      "  ��6&   .�5   
   ��  �@J�SnapsToDevicePixels . 5      �� 5   
    �@�OverridesDefaultStyle . 5      �� 5	   
    �@  TabNavigation$
 None=�5
      �� 5   
    �@�FocusVisualStyle 5      Z� �� 5   
    � ��$	 120��5      �� 5   
    � ��$ 20��5      �� 5   
    �@J�	AllowDrop . 5      �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $��Border��6   $ 2��5      $ 2q�5      $��1q�5      ��5      �� 5      # �   6.   ��5      �� 5      # �  6.    5         5!      CommonStates��. 5"   "     
Normal��6.     5#   "   Disabled��.	 5$   &   �� .��5%   *   �� $
 Border��6G   $E ?(Panel.Background).                     (SolidColorBrush.Color)�5&   1   .g�5(   .     $ 0��6B   8   5)   *   5*   +   5+   '   5,   #     5-   "   ReadOnly��.	 5.   &   �� .��5/   *   �� $
 Border��6G   $E ?(Panel.Background).                     (SolidColorBrush.Color)�50   1   .g�52   .     $ 0��6B   8  53   *   54   +   55   '   56   #     57   "   	MouseOver��6.   58      ._�5:      �� $ PART_ContentHost��5;      $��0q�5:   '   5;      5<      5=      5?      5@      5A      