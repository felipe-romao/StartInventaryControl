   M S B A M L   `   `   `  ����P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:StartInventaryControl.Views.WPFStartInventaryControl.Views.WPF  5   	   <    6StartInventaryControl.Views.WPF.EditProductEntryWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:StartInventaryControl.Views.WPF     5   	     � Title$   Start - Entrada no estoque��5   	   $	��500��6,   $	��700��69    � WindowStartupLocation$ CenterScreen=�6E    � WindowState$ 	Maximized=�6j   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��1��6    5      �� 5      �� 5       5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5!      �� $
��Data��6   $��0��6#   $��0��60   $��	10,0,10,0q�6@   (  "System.Windows.Controls.DatePicker  5"      -   5          Name$
 date��5"      $��1��6'   $��0��64   $��	10,0,10,0q�6D    � ForceCursor . 6W   �� 5$      $��
Fornecedor��6   $��2��6)   $��0��66   $��	10,0,10,0q�6F   �� 5%      -   5         ��Name$ supplierComboBox��5%      $��3��61   $��0��6>   $��	10,0,10,0q�6N   $��Center=�6a   $��25��6|   �� 5'      $��Produto��6   $��4��6&   $��0��63   $��	10,0,10,0q�6C   �� 5(      -   5        $ productDescComboBox��5(      $��5��64   $��0��6A   $��	10,0,10,0q�6Q   $��Center=�6d   $��25��6   �� 5*      $��
Anotação��6   $��0��6'   $��1��64   $��	10,0,10,0q�6D   �� 5+      -   5         ��Name$ annotationTextBox��5+      $��1��61   $��5��6>   $��1��6O   $��	10,0,10,0q�6_   $	��120��6r   	 �� TextWrapping$
	 Wrap=�6   
 �� AcceptsReturn
 . $��Center=�6�   $
��Auto��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   5-      �� 50   
   $��1��6   $��1��6    $��	10,0,10,0q�60   $��Variações: ��6C   .��51      � $��1��6   $��1��6    $��10,10,10,10q�60    52      �� 53      $
��Auto �6$   �� 54      $��* �6$    56      �� 57      �� 58      $
��Auto �6'   .+�5;      � $��0��6   $��0��6$    5<      �� 5=      $��* �6(   �� 5>      $��* �6(   �� 5?      $��* �6(    5A      �� 5B      �� 5C      .+�5F      �� $��Genero��6   $��0��6-   $��0��6:   $��0,0,10,0q�6J   �� 5G      -   5        $ genderComboBox��5G      $��1��67   $��0��6D   $��0,0,10,0q�6T   $��Center=�6f   $��25��6�   �� 5I      $	��Cor��6   $��0��6*   $��1��67   $��	10,0,10,0q�6G   �� 5J      -   5        $ colorComboBox��5J      $��1��66   $��1��6C   $��	10,0,10,0q�6S   $��Center=�6f   $��25��6�   &   System.Windows.Controls.DataGrid  5M      -   5          Name$ 	sizesGrid��5M      $��2��6J   $��2��6W   $��
0,10,10,10q�6k      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6      HeadersVisibility$	 All=�6�      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .    CanUserAddRows .  ��62   �� 5N      5O        5Q      -   5        $ EntriesGrid��5Q      $��1��60   $��0��6=   $��0,0,10,0q�6M      SelectionMode$ Single=�6_      EnableRowVirtualization .  $	 All=�6�   
 �����
 ����� .     CanUserReorderColumns .     CanUserSortColumns .   .     Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ Genero��6l      Width$ 3.65* 6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Gender+   ClipboardContentBinding 6I   Z� 6}     5T      $	 Cor��6k   $ 3.65* 6y    6-   �� *Color+ 6H   Z� 6y     5U      $ Tamanho��6j   $ 2* 6|    6-   �� *Size+ 6G   Z� 6|     5V      $ 
Quantidade��6n   $
 0.7* 6�    6-   �� *
Quantity+ 6K   Z� 6�   5X      �� 5Y      $��0��6   $��1��6*   .+�5Z      �� -	   5         ��Name$ createEntryButton��5Z      $��+��68   $��0,0,0,10q�6D   $��25��6V   $��25��6a   �� 5[      -
   5        $ removeEntryButton��5[      $��-��68   $��0,0,0,10q�6D   $��25��6V   $��25��6a   5\      5]      5^      �� 5`   
   $��2��6   $��2��6"   $��0q�67    �� Orientation$ 
Horizontal=�6B   $��Right=�6[   .+�5a      �� -   5        $ cancelButton��5a      $
��Sair��6+   $��Right=�6:   $��10,10,10,10q�6V   $	��100��6k   $	��Top=�6z   $	��100��6�   $��25��6�   �� 5b      -   5        $ 
saveButton��5b      $��Salvar��6)   $��Right=�6:   $��10,10,10,10q�6V   $	��100��6k   $	��Top=�6z   $	��100��6�   $��25��6�   5c      � 5e   
   $��2��6   $��0��6    .+�5f      �� $��1q�6   ���	#FF000000$	��Top=�6A   $��10,10,10,10q�6Y   ._�5g      �� -   5         ��Name$ productImage��5g      $��0��6.   $��1��6;   $
��Left=�6K   $	��230��6f   $	��200��6s   $	��Top=�6   5h      5i      5k      5l      