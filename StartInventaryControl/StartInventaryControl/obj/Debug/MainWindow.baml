   M S B A M L   `   `   `  ����P  LStartInventaryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:StartInventaryControlStartInventaryControl  5   	   &     StartInventaryControl.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:StartInventaryControl     5   	     � Title$  Start��5   	   $	��350��6   $	��525��6$    � WindowStartupLocation$ CenterScreen=�60    � WindowState$ 	Maximized=�6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   o� -   5         o�Name$ mainMenu��5       o� 
IsMainMenu . $��0��63   $��	10,0,10,0q�6@   .@�5      m� $��_Produto��6   .@�5      m� -   5         m�Name$ editProductMenuItem��5      $��
_Cadastrar��68   m� 5      -   5        $ productsMenuItem��5      $��_Listar��65   m� 5      $��_Variações��6   .@�5      m� -   5        $ editVariationTypeMenuItem��5      $��
_Cadastrar��6B   m� 5      -   5        $ variationTypesMenuItem��5      $��_Listar��6?   5      5      m� 5      $��_Estoque��6   .@�5      m� $��_Entrada��6   .@�5      m� -   5        $ editProductEntryMenuItem��5      $��
_Cadastrar��6A   m� 5       -   5        $ productEntryMenuItem��5       $��_Listar��6=   5!      m� 5"      $��_Saida��6   .@�5#      m� -   5        $ editProductIssueMenuItem��5#      $��
_Cadastrar��6A   m� 5$      -	   5        $ productIssueMenuItem��5$      $��_Listar��6=   5%      5&      m� 5(      $��_Fornecedor��6   .@�5)      m� -
   5        $ editSupplierMenuItem��5)      $��
_Cadastrar��69   m� 5*      -   5        $ suppliersMenuItem��5*      $��_Listar��66   5+      5-      5/      50      