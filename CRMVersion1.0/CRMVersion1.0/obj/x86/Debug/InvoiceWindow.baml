   M S B A M L   `   `   `  ����H  DCRMVersion1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CRMVersion1._0.ValidatorsCRMVersion1._0.Validators  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    CRMVersion1._0.InvoiceWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:CRMVersion1._0.Validators     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  InvoiceWindow��5	   	   $��542.443��6   $��712.588��60    � 	Resources 5         validationErrorTemplate �� Orientation �� TextAlignment � ToolTip �� ElementName �� Path ��Name��%�  &	        �� 5   
   .R�5      ]� .+�5      �� $ 
Horizontal=�6   $��Bottom=�66   .+�5      � $��12��6   $��12��6&   .+�5      A� $��12��6"   $��12��6-   
���  ��$��Center=�6D   $��Center=�6a   5   !   �� 5      
�������$��Heavy"�67   $��8(�6J   $��Center=�6W   $��Center=�6t   $ Center=�6�    5       �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�X5   $   5      �� 5      
���  ��$��2,0,0,0q�61   ��5      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      5      �� 5      $ ErrorAdorner��6,   6E   5      5      5       .��5"      � $	��514��6   $��0,0,0.4,-1.2q�6   $	��Top=�6.   .+�5#   
   �� -   5         ��Name$ 
CustomerTB��5#      $
��Left=�6&   $��23��6A   $��	97,74,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6t   $	��120��6�   {�.  6�   �� 5$   
   -   5        
 ��Name$
 label��5$      $��Customer��6   $
��Left=�62   $��	22,71,0,0q�6M   $	��Top=�6`   (  "System.Windows.Controls.DatePicker  5%   
   $
��Left=�6   $��
445,38,0,0q�62   $	��Top=�6F    =� ErrorTemplate# [  6_      Text 5&      �� 5'      $ InvoiceDate�6    �� Mode$ TwoWay=�6-    �� UpdateSourceTrigger$ PropertyChanged=�6;    �� ValidationRules 5(      3   -CRMVersion1._0.Validators.DatePickerValidator  5)      66   5+      5-      �� 5.   
   -   5        $
 label1��5.      $��Invoice date��6    $
��Left=�67   $��
357,38,0,0q�6R   $	��Top=�6f   �� 5/   
   -   5        $
 label2��5/      $��Invoice No.��6    $
��Left=�66   $��	22,34,0,0q�6Q   $	��Top=�6d   �� 50   
   -   5        $ InvoiceNoTB��50      $
��Left=�6'   $��23��6B   $��	97,38,0,0q�6N   $
	 Wrap=�6a   $	��Top=�6u   $	��120��6�   {�.  6�   &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ dataGrid��51      $
��Left=�6%   $��
34,113,0,0q�6@   $	��Top=�6T   $	��163��6l   $	��552��6y      AutoGenerateColumns .     Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6E      CanUserResize .     MinWidth$ 30Q�6h      CanUserSort .     CanUserReorder .     
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
LineNumber+6�     54      $ Id��6=    .  $ 30Q�6_    .   .   .  6%   �� *Id+6�     55      $ Service Name��6F    .  $	 150Q�6r    .   .   6%   �� *ServiceName+6�     56      $ Price��6@    .     MaxWidth$	 200Q�6e   $ 80Q�6t    .   .   .  6%   �� *Price+6�     57      $ Quantity��6C    .   .   .   6%   �� *
Quantity+6�     58      $ Total��6@    .  $ 80Q�6e    .   .   .  6%   �� *Total+6�   4  .System.Windows.Controls.DataGridTemplateColumn  59         CellTemplate 5:      �� 5;      .R�5<      �� -   5        ��5<   =   �� $ Id�.��6c   Edit6i   5=      5?        5@       5A      �� 5B      .R�5C      �� -   5        ��5C   @   �� $ Id�.��6f   Delete6n   5D      5F      5H      �� 5I   
   -	   5        $
 label3��5I      $��Service Name��6    $
��Left=�67   $��
22,292,0,0q�6R   $	��Top=�6f   �� 5J   
   -
   5         ��Name$ ServiceNameCB��5J       �� 
IsEditable .  �� IsTextSearchEnabled . # [  6X   $
��Left=�6�   $��
22,325,0,0q�6�   $	��Top=�6�   $	��109��6�    �� DisplayMemberPath$
 Name��69    �� SelectedValuePath$  Id��6R  ��6�   �� *
Services+! �� SelectedIndex! 5L      �� 5M      $ Services�6   $ TwoWay=�6*   $ PropertyChanged=�68    5N      4   .CRMVersion1._0.Validators.ServiceNameValidator  5O      67   5Q      5U      �� 5V   
   -   5        $
 label4��5V      $��Quantity��6    $
��Left=�63   $��253,292,0,0q�6N   $	��Top=�6c   �� 5Z   
   -   5        $ 
QuantityTB��5Z      # [  6'   $
��Left=�6k   $��23��6�   $��259,325,0,0q�6�   $
	 Wrap=�6�   $	��Top=�6�   $��60��6�   .��6  ��5[      �� 5\      $ Quantity�6   $ TwoWay=�6*   $ PropertyChanged=�68    5]      1	   +CRMVersion1._0.Validators.QuantityValidator	  5^      64   5`      .��5a      5b      �� 5f   
   -   5        $
 label5��5f      $��Total��6    $
��Left=�60   $��357,292,0,0q�6K   $	��Top=�6`   �� 5g   
   -   5        $ TotalTB��5g      $
��Left=�6#   $��23��6>   $��357,325,0,0q�6J   $
	 Wrap=�6_   $	��Top=�6s   $	��120��6�   {�.  6�   �� 5h   
   -   5        " ��Name$" AddItemButton��5h      $��Add Item��6(   $
��Left=�6;   $��503,325,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5i   
   -   5        $
 label6��5i      $��Price��6    $
��Left=�60   $��160,292,0,0q�6K   $	��Top=�6`   �� 5j   
   -   5        $ PriceTB��5j      $
��Left=�6#   $��23��6>   $��168,323,0,0q�6J   $
	 Wrap=�6_   $	��Top=�6s   $��64��6�   {�.  6�   �� 5k   
   -   5        $" SaveInvoiceButton��5k      $
��Save��6,   $
��Left=�6;   $��503,460,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5l   
   -   5        $" CancelInvoiceAddButton��5l      $��Cancel��61   $
��Left=�6B   $��402,460,0,0q�6]   $	��Top=�6r   $��75��6�   # J� RenderTransformOrigin$# 0.909,1.026&�6�   �� 5m   
   -   5        $" SaveItemChangesButton��5m      $��Save Changes��60   $
��Left=�6G   $��503,349,0,0q�6b   $	��Top=�6w   $��75��6�   6�   �� 5n   
   -   5        $" CancelEditButton��5n      $��Cancel��6+   $
��Left=�6<   $��601,349,0,0q�6W   $	��Top=�6l   $��75��6�   6�   5p      5q      