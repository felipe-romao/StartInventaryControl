   M S B A M L   `   `   `  ���� P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:StartInventaryControl.Views.WPFStartInventaryControl.Views.WPF  7    1StartInventaryControl.Views.WPF.EditProductWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?local-clr-namespace:StartInventaryControl.Views.WPF       � Title$  Start - Produtos��$	��500��$	��700�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+�� $��0�� �� �� �� ��  � ColumnDefinitions �� �� .+��� $��Descrição��$��0��$��0��$��
10,10,10,0q��� -    ��Name$ descriptionTextBox��$��1��$��0��$��	10,0,10,0q� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��Center=�$��25��$
��Auto��" �� VerticalScrollBarVisibility$
 Auto=��� $!��Imagem (tamanho 200x230 px)��$��2��$��0��$��	10,0,10,0q�� $��3��$��0�� �� $��* ��� $
��Auto �.+��� -   $ imagePathTextBox��{�.  $��0��$��10,0,5,0q�$
 Wrap=� . $��Center=�$��25��$
��Auto��$
 Auto=��� -   	 ��Name$	 uploadImageButton��$��1��$	��...��$��0,0,10,0q�$��25��$��25���� $��
Anotação��$��0��$��1��$��
10,10,10,0q��� -   $ annotationTextBox��$��1��$��3��$��1��$��	10,0,10,0q�$��75��$
 Wrap=� . $��Center=�$
��Auto��$
 Auto=�� $��1��.+�&   System.Windows.Controls.DataGrid  -   
  Name$
 variationsGrid��$��0��$��0��$��
10,10,10,0q�   SelectionMode$ Single=�   EnableRowVirtualization .     HeadersVisibility$	 All=�   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .     CanUserReorderColumns .     CanUserSortColumns .     CanUserAddRows .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Genero��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 3.65* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Gender+   ClipboardContentBinding Z�    . $	 Cor��$ 3.65*  �� *Color+ Z�    . $ Tamanho��$ 2*  �� *Size+ Z�    .  $ 
Quantidade��$
 0.7*  �� *
Quantity+ Z� �� $��2��$��10,10,10,10q� �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $	 cancelButton��$
��Sair��$��Right=�$��10,10,10,10q�$	��100��$	��Top=�$	��100��$��25���� -   $	 updateVariationsButton��$!��Adicionar novas variações��$��Right=�$��10,10,10,10q�$	��150��$	��Top=�$	��100��$��25���� -   $	 
saveButton��$��Salvar��$��Right=�$��10,10,10,10q�$	��100��$	��Top=�$	��100��$��25��