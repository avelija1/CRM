   M S B A M L   `   `   `  ����H  DCRMVersion1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CRMVersion1._0CRMVersion1._0  5   	   "    CRMVersion1._0.ServiceWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CRMVersion1._0     5   	   -   5          � Title$  ServiceWindow��5   	   $��459.214��6   $��545.454��60   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Services��6   $
��Left=�62   $��	34,35,0,0q�6M   $	��Top=�6`   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��	18,66,0,0q�6@   $	��Top=�6S   $	��174��6k   $	��217��6x      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Service Name��6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ServiceName+6E     5      $ Price��6@    6%   �� *Price+6@   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� -   5        ��5   =   ��  �� Path$ ID�.��6c   Edit6i   5      5        5       5      �� 5      .R�5      �� -   5        ��5   @   �� $ ID�.��6f   Delete6n   5      5      5      �� 5   
   -   5        $ 
label_Copy��5      $��Service name��6$   $
��Left=�6;   $��
263,89,0,0q�6V   $	��Top=�6j   $��26��6�   $��87��6�   �� 5    
   -   5        	 ��Name$	 ServiceNameTB��5       $
��Left=�6)   $��23��6D   $��377,92,-54.6,0q�6P   
 �� TextWrapping$

 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5!   
   -   5        $ label1��5!      $��Price��6    $
��Left=�60   $��263,131,0,0q�6K   $	��Top=�6`   $��98��6x   �� 5"   
   -	   5        $	 PriceTB��5"      $
��Left=�6#   $��23��6>   $��377,134,-54.6,0q�6J   $

 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5#   
   -
   5        $ label2��5#      $��
��6    $
��Left=�60   $��256,54,-6.6,0q�6K   $	��Top=�6b   $	��193��6z   �� 5$   
   -   5         ��Name$ button��5$      $
��Save��6!   $
��Left=�60   $��421,185,-53.6,0q�6K   $	��Top=�6d   $��75��6|   6�   �� 5%   
   -   5        $ button1��5%      $��Cancel��6"   $
��Left=�63   $��311,185,0,0q�6N   $	��Top=�6c   $��75��6{   6�   5'      5(      