   M S B A M L   `   `   `  ����H  DCRMVersion1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CRMVersion1._0CRMVersion1._0  5   	   X TXceed.Wpf.Toolkit, Version=3.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5      p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5      "    CRMVersion1._0.InvoiceWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CRMVersion1._0     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      htoolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5        � Title$  InvoiceWindow��5   	   $��633.945��6   $��555.619��60    � 	Resources 5         Provider S� 
ObjectType   CRMVersion1._0.Service S� 
MethodName��%F   &	        S� 5   
   "  6.   $ GetServices��5      5      5      .��5      � $��0,0,-6.4,-5.8q�6   .+�5   
   �� -   5         ��Name$ label��5      $��Customer��6   $
��Left=�62   $��	28,66,0,0q�6M   $	��Top=�6`   �� 5   
   -   5        $ label1��5      $��Invoice No.��6    $
��Left=�66   $��	28,23,0,0q�6Q   $	��Top=�6d    J� RenderTransformOrigin$ 0.273,-0.027&�6|   �� 5   
   -   5         ��Name$ InvoiceNoTB��5      $
��Left=�6'   $��23��6B   $��
115,26,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��120��6�   {�.  6�   �� 5   
   -   5        $ label2��5      $
��Date��6    $
��Left=�6/   $��
309,26,0,0q�6J   $	��Top=�6^   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ InvoiceDate��5      $
��Left=�6*   $��
378,27,0,0q�6E   $	��Top=�6Y   $	��120��6q   &   System.Windows.Controls.DataGrid  5   
   -   5        	  Name$	 dataGrid��5      $
��Left=�6&   
   CanUserAddRows
 . $��152,122,0,0q�6W   $	��Top=�6l   $	��220��6�   $	��264��6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5      $ Price��6%    64   �� *Price+  5      $ Quantity��6%    68   �� *
Quantity+  5      $ Total��6?    6%   �� *Total+6?   5!      �� 5"   
   -   5        $ label3��5"      $��Total��6    $
��Left=�60   $��325,499,0,0q�6K   $	��Top=�6`   �� 5#   
   -   5        $ textBox2��5#      $
��Left=�6$   $��23��6?   $��378,499,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5$   
   -	   5         ��Name$ button��5$      $��Cancel��6!   $
��Left=�62   $��341,557,0,0q�6M   $	��Top=�6b   $��75��6z   �� 5%   
   -
   5        $ button1��5%      $
��Save��6"   $
��Left=�61   $��438,557,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5&   
   -   5         ��Name$ 
CustomerCB��5&       �� SelectedValuePath$ Id��5'      $	��120��5)      $
��Left=�5*      $��
115,69,0,0q�5+      $	��Top=�5,      ��5&   '   �� *	Customers+��5.      �� 5/      .R�50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      �� ��6$   ��  �� Path$ 	FirstName��� 52      $	��   ��6$   �� 53      ��6$   �� $ LastName�54      55      57      59      5:      