   M S B A M L   `   `   `  ����H  DCRMVersion1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CRMVersion1._0.ValidatorsCRMVersion1._0.Validators  5   	   "    CRMVersion1._0.CompanyWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:CRMVersion1._0.Validators     5   	     � Title$  CompanyWindow��5	   	   $��402.258��6   $��547.241��60   
������� � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $	��Top=�66   .+�5      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   5   !   �� 5      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5   $   5      �� 5      
���  ��$��2,0,0,0q�61   ��5      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      5      �� 5      $ ErrorAdorner��6,   6E   5      5      5      .��5       � $��0,2,4,-2q�6    � ColumnDefinitions 5!   
   �� 5"      $
��379* �6   �� 5#      $
��157* �6   .+�5%   
   �� ���	#FFFFD595$	��174��6%   $��-6,67,-10,0q�62   ���	#FFFFD595$	��Top=�6Z   $��2��6r   �� 5&   
   -   5        	 ��Name$	 button��5&      $
��Save��6!   $
��Left=�60   $��302,290,0,0q�6K   $	��Top=�6`   $��91��6x   
����������	#FFFF8A84$��Roboto)�6�   $��39��6�   $��16(�6�   
�������$��2��6  �� 5'   
   -   5        $	 button1��5'      $��Cancel��6"   $
��Left=�63   $��190,290,0,0q�6N   $	��Top=�6c   $��92��6{   ���	#FFFF8A84
�������$��16(�6�   $��Roboto)�6�   
�������$��39��6�   �� 5(   
   -   5        $	 button2��5(      $��Select logo��6"   $
��Left=�68   $��
23,208,0,0q�6S   $	��Top=�6g   $	��104��6   ���	#FFFF8A84
�������$��Roboto)�6�   $��16(�6�   ���	#FFFF8A846�   �� 5)   
   -   5        
 ��Name$
 
label_Copy��5)      $��Company name��6$   $
��Left=�6;   $��	23,10,0,0q�6V   $	��Top=�6i   $��	Kollektif)�6�   $	��423��6�   $��52��6�   $��36(�6�   ���	#FFFFD595$��2��6�   �� 5*   
   -   5         ��Name$ image��5*      $
��Left=�6   $	��110��6:   $��	23,93,0,0q�6G   $	��Top=�6Z   $	��153��6r    J� OpacityMask �	#FFB019196~   �� 5+   
   $
��Left=�6   $	��155��60   $��
302,76,0,0q�6=   $	��Top=�6Q   $	��233��6i   $��2��6u   .+�5,      �� -   5         ��Name$ CompanyNameTB��5,       =� ErrorTemplate# [  6.   $
��Left=�6s   $��23��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��215��6�   ���	#FFFFD595
�������$��1q�6�   $��Roboto)�6  $��16(�6%  $��8,10,0,0q�63  .��6F  ��5-      �� 5.      $ CompanyName�6    �� Mode$ TwoWay=�61    �� UpdateSourceTrigger$ PropertyChanged=�6?    �� ValidationRules 5/      4   .CRMVersion1._0.Validators.CompanyNameValidator  50      6;   52      .��53       54      �� 55      -   5        $ AdressTB��55      $��Adress��6(   $
��Left=�66   $��23��6Q   $
 Wrap=�6]   $	��Top=�6q   $	��215��6�   ���	#FFFFD595
�������$��1q�6�   $��Roboto)�6�   $��16(�6�   $��8,10,0,0q�6�   �� 56      -   5        $ TelephoneTB��56      $��	Telephone��6+   $
��Left=�6<   $��23��6W   $
 Wrap=�6c   $	��Top=�6w   $	��215��6�   ���	#FFFFD595
�������$��1q�6�   $��Roboto)�6�   $��16(�6�   $��8,10,0,0q�6�   �� 57      -	   5        $ 	WebSiteTB��57      $��Website��6)   $
��Left=�68   $��23��6S   $
 Wrap=�6_   $	��Top=�6s   $	��215��6�   ���	#FFFFD595
�������$��1q�6�   $��Roboto)�6�   $��16(�6�   $��8,10,0,0q�6�    59       �� 
TargetType �� Property �� Value��%X   '��       �� 5:      " ��6   .�5;      ��  � ��$ 0,10,0,0q�6/   5<      5=      5?      5@      5A      