   M S B A M L   `   `   `  ����F  BSynthesizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SynthesizerSynthesizer  5   	   9!clr-namespace:Synthesizer.HelpersSynthesizer.Helpers  6g       Synthesizer.StartWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   %localclr-namespace:Synthesizer  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  61   /helpers!clr-namespace:Synthesizer.Helpers  6g   -   5          �Name$  StartWin��5	   
    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
���   �$��6q�5      ���#b8b8b8 � WindowStartupLocation$ CenterScreen=�5   
    � Title$ StartWindow��5   	   $	��380��6   $	��340��6*    � 	Resources 5       �� 
TargetType �� Property �� Value��%!  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$  /Resources/#Determination2)�6+   �� 5       � ��$ 18(�6)   �� 5       � ��$ 0,5,0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$  /Resources/#Determination2)�6+   5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5!      $��20 �6   6*   �� 5"      $��80 �6   6*   �� 5#      $	��100 �6   6+   �� 5$      $	��100 �6   6+   �� 5%      $	��100 �6   6+   �� 5&      $	��100 �6   6+   
 � ColumnDefinitions
 5,   
   �� 5-      $
��Auto �6   �� 5.      $
��Auto �6   .+�50      �� $��0��6   $��2��6)   $��0��6>   $��6��6K   $	��550��6\   $��
22,0,0,-40q�6i   .+�51      �� $#��/Resources/pixelblacklogo.png��6   $��50��6<   $��-190,10,0,0q�6G   �� 52      $��0��6   
���   �$��3q�54      $��Center=�55      $��Center=�57         m_Title#���   58      $��Center=�64   $��
60,10,10,5q�6X   $��22(�6o   $��/Resources/#AA Spaceman)�6}   
���   �$��2��6�   $��	0,-50,0,0q�6�   �� 5:      -   5         ��Name$ EnterLoginTextBox��5:   �   $��10,0,0,0q�6    � 
InputScope$ 	LogOnName��6)   $��45��6A   ���#363535 �� 	MaxLength$ 15��6c   $	��280��6r   $ ��/Resources/#Determination2)�6     m_login)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�   $��1q�6�    % !MaterialDesignFloatingHintTextBox#��[ 6  $��20(�6L  $��0,20,0,0q�6Z  ���#b8b8b8��6�  �� *	LoginName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5<      
���  ��$��13(�6)   ��67   �� *LoginValidate+6X   )  #MaterialDesignThemes.Wpf.DialogHost  5@      $��0��6)   $��2��69   $��4��6N      IsOpen 6_   �� *NetworkError+   DialogContent 5A      �� 5B      ���#b8b8b8.+�5D      ��   m_network_error#���  6    
���   �$��20(�6_   $ ��/Resources/#Determination2)�6m   $��10q�6�   6�   �� 5E      $��50��6"   ���#919191$
��Ок��6B   $ ��/Resources/#Determination2)�6O   $��35��6w   $��10q�6�   ��6�   �� * CloseNetworkErrorWindowCommand+6�   5F      5J        5L      $��0��6(   $��2��68   $��6��6M    6_   �� *RestoreVisibility+ 5M      �� 5N      ���#b8b8b8.+�5O      �� $��12(�6    $��
20,10,0,10q�6.     
m_waitpass#���  6B   $ ��/Resources/#Determination2)�6i   6�   �� 5Q      -   5        $ EnterLoginTextBoxRestore��5Q   �   $��10,0,0,0q�6"   $ 	LogOnName��65   $��45��6M   ���#363535$ 15��6o   $	��280��6~   $ ��/Resources/#Determination2)�6�   # �  6�   $��1q�6  #��[ 6$  $��20(�6_  $��	20,0,20,0q�6m  ���#b8b8b8��6�  �� *	LoginName+$ PropertyChanged=��� 5R      
���  ��$��13(�65   $	��280��6C   ��6O   �� *LoginValidate+6p   �� 5S      -   5        $ GmailRestore��5S   u   $��10,0,0,0q�6"   $��45��66   ���#363535$ 35��6X   $	��280��6g   $ ��/Resources/#Determination2)�6�    
 m_mail# �  6�   $��1q�6�   #��[ 6  $��20(�6>  $��	20,0,20,0q�6L  ���#b8b8b8��6v  �� *Gmail+$ PropertyChanged=��� 5T      
���  ��$��13(�65   $��20,5,0,5q�6C   ��6W   �� *MailValidate+6w   �� 5V      $	��120��6"   ���#919191  m_close#���  6C   $ ��/Resources/#Determination2)�6g   $��35��6�   $��	160,0,0,0q�6�   ��6�   �� *#!CloseRestorePasswordWindowCommand+6�   �� 5W      $	��120��6"   ���#919191  	m_restore#���  6C   $ ��/Resources/#Determination2)�6j   $��35��6�   $��0,-35,160,30q�6�   ��6�   �� *SendPasswordCommand+6�   5X      5\      G� 5_      -   5         G�Name$ EnterPasswordTextBox��5_   �   $��10,0,0,0q�6    # MaterialDesignFilledPasswordBox#��[ 6.   $ Password��6g   $��45��6}   ���#363535 G� 	MaxLength$ 15��6�   $	��280��6�   $ ��/Resources/#Determination2)�6�    	 
m_password# � 	 6  $��1q�6?  $��20(�6T  ���#b8b8b8*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5`      *   $Synthesizer.Helpers.PasswordBehavior  5a         Password 6/   �� *
Password+ �� Mode$ TwoWay=�5c      �� 5d      
���  ��$��13(�6)   $
��Wrap=�67   $	��280��6K   ��6W   �� *RegisterRepeat+6z   �� 5e      -   5        $
 Name��5e   i   $��10,0,0,0q�6   $��45��6*   ���#363535$ 15��6L   $	��280��6[   $ ��/Resources/#Determination2)�6w    

 m_name# � 
 6�   $��1q�6  #��[ 6  $��20(�6S  $��0,0,0,0q�6a  ���#b8b8b8y�6�   �� *RegisterVisibility+��6�  �� *
UserName+$ PropertyChanged=��� 5f      
���  ��$��13(�6)   y�67   �� *RegisterVisibility+��6c   �� *UserNameValidate+6�   �� 5g      -   5        $ Gmail��5g   i   $��10,0,0,0q�6   $��45��6*   ���#363535$ 25��6L   $	��280��6[   $ ��/Resources/#Determination2)�6x   # �  6�   $��1q�6  #��[ 6  $��20(�6T  $��0,0,0,0q�6b  ���#b8b8b8y�6�   �� *RegisterVisibility+��6�  �� *Gmail+$ PropertyChanged=��� 5h      
���  ��$��13(�6)   y�67   �� *RegisterVisibility+��6c   �� *MailValidate+6�   �� 5i      $��40��6     MaterialDesignRaisedButton#���  6!   ���#363535$��1q�5j   &   ���#b8b8b8$ ��/Resources/#AnotherCastle3)�6�     	m_loginin#���  6�   $��16(�6  $��0,0,0,10q�6'  ��6O   �� *LoginCommand+��6p   ��  �� ElementName$ StartWin��y�6�   �� *LoginVisibility+6'  �� 5k      $��40��6   #���  6!   ���#363535$��1q�6k   ���#b8b8b8$ ��/Resources/#AnotherCastle3)�6�   $��16(�6=    
m_register#���  6K  $��0,0,0,10q�6s  ��6�   �� *RegisterCommand+��6�   �� $ StartWin��y�6  �� *RegisterVisibility+6s  �� 5m      $��24��6   ���#b8b8b8
����  �$ ��/Resources/#Determination2)�6�   $��
-155,0,0,0q�6�     	m_account#���  6	  $	��125��6/  $��15(�6<  ��6J   �� *OpenLoginCommand+��6o   �� $ StartWin��y�6�   �� *RegisterVisibility+6<  �� 5n      $��24��6   ���#b8b8b8
����  �$ ��/Resources/#Determination2)�6�   $��
-155,0,0,0q�6�     m_noaccount#���  6	  $	��125��61  $��15(�6>  ��6J   �� *OpenRegisterCommand+��6r   �� $ StartWin��y�6�   �� *LoginVisibility+6>  �� 5o       
 m_exit#���  6   $��15(�69   ���#b8b8b8$ ��/Resources/#Determination2)�6�   
���  ��$��155,-24,0,0q�6�   $��24��6
  $��0,0,0,0q�6  $	��125��6*  ��6\   �� *CloseLoginWindowCommand+��6�   �� $ StartWin��68  �� 5p        m_switch_lang#���  6   $��15(�6A   ���#b8b8b8$ ��/Resources/#Determination2)�6�   
����  �$��-155,10,0,0q�6�   $��24��6�   $��0,0,0,0q�6�   $	��125��6�   ��6d   �� *SwitchLangCommand+6  �� 5q        m_forgetpass#���  6   $��15(�6@   ���#b8b8b8$ ��/Resources/#Determination2)�6�   
����  �$��155,-24,0,0q�6�   $��24��6�   $��0,0,0,0q�6�   $	��125��6  ��6c   �� *OpenRestorePasswordCommand+6  5s      5u      5v      