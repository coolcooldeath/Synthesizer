   M S B A M L   `   `   `  ���� F  BSynthesizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SynthesizerSynthesizer  9!clr-namespace:Synthesizer.HelpersSynthesizer.Helpers      Synthesizer.StartWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  %localclr-namespace:Synthesizer  _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  /helpers!clr-namespace:Synthesizer.Helpers  -     �Name$  StartWin�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�
���   �$��6q����#b8b8b8 � WindowStartupLocation$ CenterScreen=� � Title$ StartWindow��$	��350��$	��340�� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       '�� m     �� " ��.���  � ��$! ./resources/#Determination2)���  � ��$ 18(���  � ��$ 0,5,0,5q��� " ��.���  � ��$! ./resources/#Determination2)�.��� 	 � RowDefinitions	 �� $��85 ��� $��85 ��� $��85 ��� $��85 ��� $��30 �
 � ColumnDefinitions
 �� $
��Auto ��� $
��Auto �.+��� $��0��$��2��$��0��$��6��$	��410��$��22,10,0,-40q�.+��� $#��/resources/pixelblacklogo.png��$��50��$��-190,10,0,0q��� $��0��
���   �$��3q�$��Center=�$��Center=�$��ПОЛИВОКС��$��Center=�$��
60,10,10,5q�$��22(�$��./resources/#AA Spaceman)�
���   �$��2��$��	0,-50,0,0q��� -    ��Name$ EnterLoginTextBox��$��10,0,0,0q� � 
InputScope$ 	LogOnName��$��45�����#363535 �� 	MaxLength$ 15��$	��280��$!��./resources/#Determination2)�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��$��1q� %  !MaterialDesignFloatingHintTextBox#��[  $��20(�$��0,20,0,0q����#b8b8b8���� *	LoginName+ �� UpdateSourceTrigger$ PropertyChanged=��� $y�	Collapsed=����� *
Password+�� 
���  ��$��13(����� *LoginValidate+)  #MaterialDesignThemes.Wpf.DialogHost  $��0��$��2��$��4��   IsOpen �� *NetworkError+   DialogContent �� ���#b8b8b8.+��� $4��.Нет интернет-подключения��
���   �$��20(�$!��./resources/#Determination2)�$��10q��� $��50�����#919191$
��Ок��$!��./resources/#Determination2)�$��35��$��10q����� * CloseNetworkErrorWindowCommand+G� -    G�Name$ EnterPasswordTextBox��$��10,0,0,0q� # MaterialDesignFilledPasswordBox#��[ $ Password��$��45�����#363535 G� 	MaxLength$ 15��$	��280��$!��./resources/#Determination2)�$ Пароль��$��1q�$��20(����#b8b8b8*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors *   $Synthesizer.Helpers.PasswordBehavior     Password �� *
Password+ �� Mode$ TwoWay=��� 
���  ��$��13(�$
��Wrap=�$	��280������ *RegisterRepeat+�� -   $
 Name��$��10,0,0,0q�$��45�����#363535$ 15��$	��280��$!��./resources/#Determination2)�$ Имя��$��1q�#��[  $��20(�$��0,0,0,0q����#b8b8b8y��� *RegisterVisibility+���� *
UserName+$ PropertyChanged=��� 
���  ��$��13(�y��� *RegisterVisibility+���� *UserNameValidate+�� $��40��  MaterialDesignRaisedButton#���  ���#363535$��1q����#b8b8b8$!��./resources/#AnotherCastle3)�$��Вход��$��16(�$��0,0,0,10q����� *LoginCommand+����  �� ElementName$ StartWin��y��� *LoginVisibility+�� $��40��#���  ���#363535$��1q����#b8b8b8$!��./resources/#AnotherCastle3)�$��16(�$��Регистрация��$��	0,10,0,10q����� *RegisterCommand+���� $ StartWin��y��� *RegisterVisibility+�� $��24�����#b8b8b8
����  �$!��./resources/#Determination2)�$��
-155,0,0,0q�$��Есть аккаунт��$	��120��$��15(����� *OpenLoginCommand+���� $ StartWin��y��� *RegisterVisibility+�� $��24�����#b8b8b8
����  �$!��./resources/#Determination2)�$��
-155,0,0,0q�$��Нет аккаунта��$	��120��$��15(����� *OpenRegisterCommand+���� $ StartWin��y��� *LoginVisibility+�� $��
Выход��$��15(����#b8b8b8$!��./resources/#Determination2)�
���  ��$��155,-20,0,0q�$��24��$��0,0,0,0q�$	��120������ *CloseLoginWindowCommand+���� $ StartWin��