   M S B A M L   `   `   `  ���� P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:StartInventaryControl.Views.WPFStartInventaryControl.Views.WPF  <    6StartInventaryControl.Views.WPF.EditProductIssueWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ?local-clr-namespace:StartInventaryControl.Views.WPF       � Title$  Start - Saida no estoque��$	��500��$	��700�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���  � RowDefinitions �� $
��Auto ��� �� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+�� $��0��$��1�� �� ��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Data��$��0��$��0��$��	10,0,10,0q�(  "System.Windows.Controls.DatePicker  -     Name$
 date��$��1��$��0��$��	10,0,10,0q� � ForceCursor . �� $��Produto��$��2��$��0��$��	10,0,10,0q��� -    ��Name$ productDescComboBox��$��3��$��0��$��	10,0,10,0q�$��Center=�$��25���� $��
Anotação��$��0��$��1��$��	10,0,10,0q��� -    ��Name$ annotationTextBox��$��1��$��4��$��1��$��	10,0,10,0q�$	��120��	 �� TextWrapping$
	 Wrap=�
 �� AcceptsReturn
 . $��Center=�$
��Auto��" �� VerticalScrollBarVisibility$
 Auto=��� $��1��$��1��$��	10,0,10,0q�$��Variações: ��.��� $��1��$��1��$��10,10,10,10q� �� $
��Auto ��� $��* � �� �� $
��Auto �.+�� $��0��$��0�� �� $��* ��� $��* ��� $��* � �� �� .+��� $��Genero��$��0��$��0��$��0,0,10,0q��� -   $ genderComboBox��$��1��$��0��$��0,0,10,0q�$��Center=�$��25���� $	��Cor��$��0��$��1��$��	10,0,10,0q��� -   $ colorComboBox��$��1��$��1��$��	10,0,10,0q�$��Center=�$��25��&   System.Windows.Controls.DataGrid  -     Name$ 	sizesGrid��$��2��$��2��$��
0,10,10,10q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100    HeadersVisibility$	 All=�   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns .    CanUserAddRows .  ����   -   $ 
IssuesGrid��$��1��$��0��$��0,0,10,0q�   SelectionMode$ Single=�   EnableRowVirtualization .  $	 All=�
 �����
 ����� .     CanUserReorderColumns .     CanUserSortColumns .   .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Genero��   Width$ 3.65* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Gender+   ClipboardContentBinding Z�   $	 Cor��$ 3.65*  �� *Color+ Z�   $ Tamanho��$ 2*  �� *Size+ Z�   $ 
Quantidade��$
 0.7*  �� *
Quantity+ Z� �� $��0��$��1��.+��� -    ��Name$ createEntryButton��$��+��$��0,0,0,10q�$��25��$��25���� -	   $ removeEntryButton��$��-��$��0,0,0,10q�$��25��$��25���� $��2��$��2��$��0q� �� Orientation$ 
Horizontal=�$��Right=�.+��� -
   $ cancelButton��$
��Sair��$��Right=�$��10,10,10,10q�$	��100��$	��Top=�$	��100��$��25���� -   $ 
saveButton��$��Salvar��$��Right=�$��10,10,10,10q�$	��100��$	��Top=�$	��100��$��25��� $��2��$��0��.+��� $��1q����	#FF000000$	��Top=�$��10,10,10,10q�._��� -    ��Name$ productImage��$��0��$��1��$
��Left=�$	��230��$	��200��$	��Top=�