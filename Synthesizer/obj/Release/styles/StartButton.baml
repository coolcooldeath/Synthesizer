   M S B A M L   `   `   `  ���� F  BSynthesizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Synthesizer.ControlsSynthesizer.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   StartButton  �� 
TargetType �� Property �� Value  CheckBoxFocusVisual �� 
TargetType �� 
Background �� Bullet ��Name �� Color �� 
StartPoint	 �� EndPoint
 � Color � Offset'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible R� Value  Bulb �� Triggers �� Binding �� ElementName �� Path �� Value�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     ,local"clr-namespace:Synthesizer.Controls  %  &	        &	 �    �� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle# �  ��  � �� �� " ��.R��� 
 ����  � $��50��$��70��.+��� $ Border��$��3������ $ Black������ $	 0,0&�$		 0,1&���� � $
 #f52100��� $
 #720000��$	 1.0Q��� $ 	CheckMark��$��3q�$y�	Collapsed=����� $	 0,0&�$		 0,1&���� � $
 #720000��� $
 #f52100��$	 1.0Q�   CommonStates��.   
Normal��  Disabled��  CheckStates��.   Checked��. �� .��T� $ (UIElement.Visibility)�$ 	CheckMark��..�i� $ 0��# Z   	Unchecked��  Indeterminate��._��� $��4,0,0,0q�$��Center=�$
��Left=���. �� "  A� ��  �� $ On��$ 	IsChecked� True.a���  � �� 
� .��� $
 #e63635��$ 0Q�� $
 #970302��$ 1Q���  �� $ On��$ 	IsChecked�	 False.a���  � �� 
� .��� $
 #a20302��$ 0Q�� $
 #440302��$ 1Q�