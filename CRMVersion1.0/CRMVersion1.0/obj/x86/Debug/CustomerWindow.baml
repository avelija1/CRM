   M S B A M L   `   `   `  ����H  DCRMVersion1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CRMVersion1._0CRMVersion1._0  5   	   #    CRMVersion1._0.CustomerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CRMVersion1._0     5   	   -   5          � Title$  CustomerWindow��5   	   $��432.006��6    $��836.771��61   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��399* �6   �� 5      $
��408* �6   �� 5      $��9* �6   �� 5      $	��14* �6   .+�5   
   �� -   5         ��Name$ label��5      $��First name

��6   $
��Left=�6H   $��86.8,116,0,0q�6c   $	��Top=�6y   $��26��6�   $��87��6�   $��1��6�   �� 5   
   -   5         ��Name$ FirstNameTB��5      $
��Left=�6'   $��23��6B   $��200.8,119,0,0q�6N    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��120��6�   $��1��6�   �� 5   
   -   5        $ label1��5      $��	Last name��6    $
��Left=�64   $��86.8,158,0,0q�6O   $	��Top=�6e   $��98��6}   $��1��6�   �� 5   
   -   5        $ 
LastNameTB��5      $
��Left=�6&   $��23��6A   $��200.8,162,0,0q�6M   $
 Wrap=�6d   $	��Top=�6x   $	��120��6�   $��1��6�   �� 5   
   -   5        $ label2��5      $��
��6    $
��Left=�65   $��79.8,81,0,0q�6P   $	��Top=�6e   $	��193��6}   $��1��6�   �� 5   
   -   5         ��Name$ button��5      $
��Save��6!   $
��Left=�60   $��244.8,212,0,0q�6K   $	��Top=�6b   $��75��6z   $��1��6�   �� 5   
   -   5        $ button1��5      $��Cancel��6"   $
��Left=�63   $��134.8,212,0,0q�6N   $	��Top=�6e   $��75��6}   $��1��6�   �� 5   
   -	   5        $ label3��5      $��	Customers��6    $
��Left=�64   $��	38,31,0,0q�6O   $	��Top=�6b   $	��106��6z   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ dataGrid��5      $
��Left=�6%   $��	38,84,0,0q�6@   $	��Top=�6S   $	��222��6k   $	��300��6x    J� RenderTransformOrigin$ 0.5,0.5&�6�      AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
First Name��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	FirstName+6C     5      $
 	Last Name��6B    6%   �� *
LastName+6B   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5       .R�5!      �� -   5        ��5!   =   ��  �� Path$ ID�.��6c   Edit6i   5"      5$        5%       5&      �� 5'      .R�5(      �� -   5        ��5(   ?   �� $ ID�.��6e   Delete6m   5)      5+      z�5/      V� 50      .~�51      �� �� 52      �� 53      T� 54      55      57      59      5:      