   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyProject.TablesMyProject.Tables  5   	   7 clr-namespace:MyProject.CommandsMyProject.Commands  5   	   /clr-namespace:MyProject.HelpMyProject.Help  5   	       MyProject.Tables.ShowTags   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyProject.Tables     5   	   0cmd clr-namespace:MyProject.Commands     5   	   -helpclr-namespace:MyProject.Help     5   	     � Title$  Display of the Tags��5
   	   $	��300��6%   $	��420��62   $	��430��6>   $	��750��6N    � WindowStartupLocation$ CenterScreen=�6]    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ cmd:RoutedCommands.Cancel��5      6y     5   
   $ ApplicationCommands.Help��6   -   5        helpCommand��5   <    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value   RowMenu � DataContext	 �� RelativeSource  DefaultRowStyle)  #System.Windows.Controls.DataGridRow��%d  '        &	  L     &	 �     7   �� 5   
   "  6   .�5      ��  � ��$ Center=�6;   5      �� 5   
    6'   �� 	 �� *Self+.@�5      m� -   5        $
��Edit��5      6:   m� 5      -   5        $��Delete��5      6>   5      �� 5   
   "  6(   .�5      ��  �@�ContextMenu8   6,   5      5      .��5      � ���#70fffa!   MyProject.Help.HelpProvider
   HelpKey$
 helpTableTag��6     � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $��3* �6    � ColumnDefinitions 5    
   �� 5!      .+�5#   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrTags��5%      $��0��5#      ���#70fffa   AutoGenerateColumns .     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$
 TrueY�5(      $��0q�5)      ��.    RowStyle# [ 5+         Columns 5,      4  .System.Windows.Controls.DataGridTemplateColumn  5-      -   5        colColor��,  &System.Windows.Controls.DataGridColumn   Header$ Color��5-   ;      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6J      CellTemplate 5.      �� 5/      .R�50      �� $��1q�6%   
���   �$��Center=�6M   ._�51   "   �� $��32��6A   $��32��6P   ��6(   �� *Color+6P   52      53      55      0	  *System.Windows.Controls.DataGridTextColumn	  56      -   5        	colID��$ ID��56   4   $ * 6W   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6@   �� *Id+6W   	  57      -   5        colDesc��$ Description��57   6   $ * 6k    6K   �� *Description+6k   59      �� 5:   
   -	   5        $��1��5:      $��1��6     buttonStyle#��[ 6@   $
��0 10q�6e   $
��Left=�6s   .��6�   Add6�   �� 5;   
   -
   5        $��1��5;      $��1��6   #��[ 6D   $��90 10q�6i   $
��Left=�6y   .��6�   Edit6�   �� 5<   
   -   5        $��1��5<      $��1��6   #��[ 6C   $��180 10 10 10q�6h   $
��Left=�6~   .��6�   Delete6�   �� 5=   
   $��1��6   $��1��6   #��[ 6.   $��cmd:RoutedCommands.Cancel��6S   $
��0 10q�6w   $��Right=�6�   .��6�   OK6�   5>      5?      