   M S B A M L   `   `   `  ����P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:StartInventaryControl.Views.WPFStartInventaryControl.Views.WPF  5   	   7    1StartInventaryControl.Views.WPF.EditProductWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:StartInventaryControl.Views.WPF     5   	     � Title$  Start - Produtos��5   	   $	��500��6"   $	��700��6/    � WindowStartupLocation$ CenterScreen=�6;    � WindowState$ 	Maximized=�6`   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��0��6    5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��Descrição��6   $��0��6(   $��0��65   $��
10,10,10,0q�6E   �� 5      -   5         ��Name$ descriptionTextBox��5      $��1��62   $��0��6?   $��	10,0,10,0q�6O    �� TextWrapping$
 Wrap=�6b    �� AcceptsReturn . $��Center=�6�   $��25��6�   $
��Auto��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5      $��Imagem��6   $��2��6%   $��0��62   $��	10,0,10,0q�6B   � 5       $��3��6   $��0��6     5!      �� 5"      $��* �6'   �� 5#      $
��Auto �6'   .+�5%      �� -   5        $ imagePathTextBox��5%      {�.  $��0��6G   $��10,0,5,0q�6W   $
 Wrap=�6i    . $��Center=�6�   $��25��6�   $
��Auto��6�   $
 Auto=�6�   �� 5&      -   5        	 ��Name$	 uploadImageButton��5&      $��1��64   $	��...��6D   $��0,0,10,0q�6R   $��25��6d   $��25��6o   5'      �� 5)      $��
Anotação��6   $��0��6'   $��1��64   $��
10,10,10,0q�6D   �� 5*      -   5        $ annotationTextBox��5*      $��1��61   $��3��6>   $��1��6O   $��	10,0,10,0q�6_   $��75��6r   $
 Wrap=�6~    . $��Center=�6�   $
��Auto��6�   $
 Auto=�6�   5,      � 5.   
   $��1��6   .+�5/      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 variationsGrid��5/      $��0��6/   $��0��6<   $��
10,10,10,0q�6L      SelectionMode$ Single=�6`      EnableRowVirtualization .     HeadersVisibility$	 All=�6�      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .     CanUserReorderColumns .     CanUserSortColumns .     CanUserAddRows .     Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Genero��6y      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3.65* 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Gender+   ClipboardContentBinding 6V   Z� 6�     52       . $	 Cor��6x   $ 3.65* 6�    6)   �� *Color+ 6U   Z� 6�     53       . $ Tamanho��6w   $ 2* 6�    6)   �� *Size+ 6T   Z� 6�     54       .  $ 
Quantidade��6|   $
 0.7* 6�    6)   �� *
Quantity+ 6Y   Z� 6�   56      57      �� 59   
   $��2��6   $��10,10,10,10q�6"    �� Orientation$ 
Horizontal=�67   $��Right=�6P   .+�5:      �� -   5        $	 cancelButton��5:      $
��Sair��6+   $��Right=�6:   $��10,10,10,10q�6V   $	��100��6k   $	��Top=�6z   $	��100��6�   $��25��6�   �� 5;      -   5        $	 updateVariationsButton��5;      $!��Adicionar novas variações��65   $��Right=�6Y   $��10,10,10,10q�6u   $	��150��6�   $	��Top=�6�   $	��100��6�   $��25��6�   �� 5<      -   5        $	 
saveButton��5<      $��Salvar��6)   $��Right=�6:   $��10,10,10,10q�6V   $	��100��6k   $	��Top=�6z   $	��100��6�   $��25��6�   5=      5?      5@      