   M S B A M L   `   `   `  ����P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:StartInventaryControl.Views.WPFStartInventaryControl.Views.WPF  5   	   <    6StartInventaryControl.Views.WPF.EditProductIssueWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:StartInventaryControl.Views.WPF     5   	     � Title$  Start - Saida no estoque��5   	   $	��500��6*   $	��700��67    � WindowStartupLocation$ CenterScreen=�6C    � WindowState$ 	Maximized=�6h   .��5	      �  � RowDefinitions 5   
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
 date��5"      $��1��6'   $��0��64   $��	10,0,10,0q�6D    � ForceCursor . 6W   �� 5$      $��Produto��6   $��2��6&   $��0��63   $��	10,0,10,0q�6C   �� 5%      -   5         ��Name$ productDescComboBox��5%      $��3��64   $��0��6A   $��	10,0,10,0q�6Q   $��Center=�6d   $��25��6   �� 5'      $��
Anotação��6   $��0��6'   $��1��64   $��	10,0,10,0q�6D   �� 5(      -   5         ��Name$ annotationTextBox��5(      $��1��61   $��4��6>   $��1��6O   $��	10,0,10,0q�6_   $	��120��6r   	 �� TextWrapping$
	 Wrap=�6   
 �� AcceptsReturn
 . $��Center=�6�   $
��Auto��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   5*      �� 5,   
   $��1��6   $��1��6    $��	10,0,10,0q�60   $��Variações: ��6C   .��5-      � $��1��6   $��1��6    $��10,10,10,10q�60    5.      �� 5/      $
��Auto �6$   �� 50      $��* �6$    52      �� 53      �� 54      $
��Auto �6'   .+�57      � $��0��6   $��0��6$    58      �� 59      $��* �6(   �� 5:      $��* �6(   �� 5;      $��* �6(    5=      �� 5>      �� 5?      .+�5B      �� $��Genero��6   $��0��6-   $��0��6:   $��0,0,10,0q�6J   �� 5C      -   5        $ genderComboBox��5C      $��1��67   $��0��6D   $��0,0,10,0q�6T   $��Center=�6f   $��25��6�   �� 5E      $	��Cor��6   $��0��6*   $��1��67   $��	10,0,10,0q�6G   �� 5F      -   5        $ colorComboBox��5F      $��1��66   $��1��6C   $��	10,0,10,0q�6S   $��Center=�6f   $��25��6�   &   System.Windows.Controls.DataGrid  5I      -   5          Name$ 	sizesGrid��5I      $��2��6J   $��2��6W   $��
0,10,10,10q�6k      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6      HeadersVisibility$	 All=�6�      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .    CanUserAddRows .  ��62   �� 5J      5K        5M      -   5        $ 
IssuesGrid��5M      $��1��6/   $��0��6<   $��0,0,10,0q�6L      SelectionMode$ Single=�6^      EnableRowVirtualization .  $	 All=�6�   
 �����
 ����� .     CanUserReorderColumns .     CanUserSortColumns .   .     Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ Genero��6l      Width$ 3.65* 6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Gender+   ClipboardContentBinding 6I   Z� 6}     5P      $	 Cor��6k   $ 3.65* 6y    6-   �� *Color+ 6H   Z� 6y     5Q      $ Tamanho��6j   $ 2* 6|    6-   �� *Size+ 6G   Z� 6|     5R      $ 
Quantidade��6n   $
 0.7* 6�    6-   �� *
Quantity+ 6K   Z� 6�   5T      �� 5U      $��0��6   $��1��6*   .+�5V      �� -   5         ��Name$ createEntryButton��5V      $��+��68   $��0,0,0,10q�6D   $��25��6V   $��25��6a   �� 5W      -	   5        $ removeEntryButton��5W      $��-��68   $��0,0,0,10q�6D   $��25��6V   $��25��6a   5X      5Y      5Z      �� 5\   
   $��2��6   $��2��6"   $��0q�67    �� Orientation$ 
Horizontal=�6B   $��Right=�6[   .+�5]      �� -
   5        $ cancelButton��5]      $
��Sair��6+   $��Right=�6:   $��10,10,10,10q�6V   $	��100��6k   $	��Top=�6z   $	��100��6�   $��25��6�   �� 5^      -   5        $ 
saveButton��5^      $��Salvar��6)   $��Right=�6:   $��10,10,10,10q�6V   $	��100��6k   $	��Top=�6z   $	��100��6�   $��25��6�   5_      � 5a   
   $��2��6   $��0��6    .+�5b      �� $��1q�6   ���	#FF000000$	��Top=�6A   $��10,10,10,10q�6Y   ._�5c      �� -   5         ��Name$ productImage��5c      $��0��6.   $��1��6;   $
��Left=�6K   $	��230��6f   $	��200��6s   $	��Top=�6   5d      5e      5g      5h      