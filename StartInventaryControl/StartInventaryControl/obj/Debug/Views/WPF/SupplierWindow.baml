   M S B A M L   `   `   `  ����P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StartInventaryControl.ViewsStartInventaryControl.Views  5   	   4    .StartInventaryControl.Views.WPF.SupplierWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:StartInventaryControl.Views     5   	     � Title$  Start - Fornecedores��5   	   $	��300��6&   $	��450��63    � WindowStartupLocation$ CenterScreen=�6?   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ label��5      $��Fornecedores��6   $��0��67   $��5,0,5,0q�6E   $	��0,5q�6V   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ supplierGrid��5      $��1��6)   $��0,0,10,0q�66      EnableRowVirtualization .     AutoGenerateColumns .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����	   HeadersVisibility$	 Column=�6�   
   
IsReadOnly
 .    CanUserSortColumns .    CanUserReorderColumns .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6_      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID+   ClipboardContentBinding 6<   Z� 6k     5      $
 Nome��6a   $ * 6o    6%   �� *Name+ 6>   Z� 6o   5      �� 5   
   $��2��6   $��10,10,10,19q�6"    �� Orientation$ 
Horizontal=�67   $��Bottom=�6Q   $��Right=�6l   .+�5      �� -   5         ��Name$ updateProductButton��5      $��Alterar��62   $��Right=�6D   $��10,5,0,5q�6`   $	��100��6r   $	��100��6�   $��25��6�   �� 5      -   5        $ addProductButton��5      $��	Adicionar��6/   $��Right=�6C   $��10,5,0,5q�6_   $	��100��6q   $	��100��6�   $��25��6�   5      5      5       