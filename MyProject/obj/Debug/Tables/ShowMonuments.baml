   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyProject.TablesMyProject.Tables  5   	   7 clr-namespace:MyProject.CommandsMyProject.Commands  5   	   /clr-namespace:MyProject.HelpMyProject.Help  5   	   $    MyProject.Tables.ShowMonuments   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MyProject.Tables     5   	   0cmd clr-namespace:MyProject.Commands     5   	   -helpclr-namespace:MyProject.Help     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f43src)http://schemas.xceed.com/wpf/xaml/toolkit  5	   	   -   5          � Title$  Display of the Monuments��5   	   $	��400��6*   $	��670��67   $	��430��6C   $	��750��6S    � WindowStartupLocation$ CenterScreen=�6b    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ cmd:RoutedCommands.Cancel��5      6y     5   
   $ ApplicationCommands.Help��6   -   5        helpCommand��5   <    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value   RowMenu � DataContext	 �� RelativeSource  DefaultRowStyle)  #System.Windows.Controls.DataGridRow��%d  '        &	  L     &	 �     7   �� 5   
   "  6   .�5      ��  � ��$ Center=�6;   5      �� 5   
    6'   �� 	 �� *Self+.@�5      m� -   5        $
��Edit��5      6:   m� 5      -   5        $��Delete��5      6>   5      �� 5   
   "  6(   .�5      ��  �@�ContextMenu8   6,   5      5      .��5      � ���#70fffa!   MyProject.Help.HelpProvider
   HelpKey$
 helpTableMonument��6     � RowDefinitions 5   
   �� 5      $��3* �6   �� 5       � ColumnDefinitions 5!   
   �� 5"      $	��10* �6   �� 5#      $��3* �6   .+�5%   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMonuments��5'      $��0��5%      
�����@�   AutoGenerateColumns .     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$
 TrueY�5*      $
��10 3q�5+      ��.    RowStyle# [ 5-         Columns 52      4  .System.Windows.Controls.DataGridTemplateColumn  53      -   5        colIcon��,  &System.Windows.Controls.DataGridColumn   Header$
 Icon��53   :      CellTemplate 54      �� 55      .R�56      �� $��32��6<   $��32��6K   ��6$   �� *Icon+6K   57      59      0  *System.Windows.Controls.DataGridTextColumn  5:      -   5        	colID��$ ID��5:   4   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6@   �� *ID+  5;      -	   5        colName��$
 Name��5;   6    6D   �� *Name+  5<      -
   5        colDesc��$ Description��5<   6    6K   �� *Description+  5=      -   5        colType��$
 Type��5=   6    6D   �� *Type+  5>      -   5        
colClimate��$ Climate��5>   9    6J   �� *	Climate+  5?      -   5        colTouristStatus��$ Tourist Status��5?   ?    6W   �� *TouristStatus+4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5@      -   5        	colEE��$ EcologicallyEndangered��5@   8    6X   �� *EcologicallyEndangered+5A      
  5B      -   5        	colPR��$ PopulatedRegion��5B   8    6Q   �� *PopulatedRegion+5C      
  5D      -   5        
colHabitat��$ Habitat��5D   =    6N   �� *	Habitat+  5E      -   5        	colIncome��$ Income��5E   8    6H   �� *Income+  5F      -   5        colDiscoveryDate��$ Discovery Date��5F   ?    6W   �� *DiscoveryDate+ �� StringFormat$ 
MM/dd/yyyy��5H      �� 5I   
   $��1��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5J      �� -   5          buttonStyle#��[ 5J   4   $	��120��6Y   $
��0 15q�6e   $
��Left=�6s   ��6�   ��  �� Path$ TableBtnContent�6�   �� 5K      -   5        #��[ 5K   '   $
��0 15q�6L   $
��Left=�6Z   .��6u   Add6z   �� 5L      -   5        #��[ 5L   +   $
��0 15q�6P   $
��Left=�6^   .��6y   Edit6   �� 5M      -   5        $��1��5M      $��0��6"   #��[ 6G   $
��0 15q�6l   $
��Left=�6z   .��6�   Delete6�   5N      �� 5O   
   $��1��6   $��2��6   #��[ 6.   $��cmd:RoutedCommands.Cancel��6S   $
��0 15q�6w   $��Right=�6�   .��6�   OK6�   �� 5P   
   $��0��6   $��2��6"   .+�5Q      �� $
��Tags��6   
����� �$	��Top=�6<   $��0 0 5 0q�6T   .��5R      �� -   5         ��Name$ tagsBox��5R      $��0q�6+   ���#70fffa$
��Auto=�6T   $��80��6�   ��6�   �� *Tags+ �� Mode$ OneWay=���5S      �� 5T      .R�5U      ��  �� Bullet 5V   "   �� 5W   &   $��1q�6-   
���   �._�5X   *   �� $��10��64   $��10��6@   $��Bottom=�6f   ��6K   �� *	ColorCode+6f   5Y   '   ._�5[   "   �� $��12(�6@   $��5 0 0 0q�6N   ��6,   �� *ID+6a   5\      5]      5_      5`      ]� 5a      $��0 5 5 0q�6   .+�5b      �� $
��Bold"�6   $��0 0 5 0q�6.   $��13(�6?   	Search:6V   �� 5c      
���   �$��1q�6-   ._�5d      ]� 
�������.+�5e      �� $%��/MyProject;component/search.png��6    $��20��6I   �� 5f      -   5         ��Name$ tbSearch��5f   "   $��12(�64   $��Stretch=�6B   $��0q�6`   6t   5g      5h      5i      �� 5j      $��0 0 5 0q�6   .+�5k      �� $
��Bold"�6   $��13(�6.   	Filter:6E   � 5l       5m      �� 5n      �� 5o      �� 5p      �� 5q      �� 5r       5t      �� 5u      �� 5v      $��2* �6+   .+�5x      �� $��0��6    $��0��6-   $��Center=�6=   Types:6`   %  Xceed.Wpf.Toolkit.CheckComboBox  5y      -   5          Name$ filterTypes��5y   E   $��0��6(   $��1��65   $	��0 2q�6x   ��6Z   �� *Types+6x   �� 5z      $��1��6    $��0��6-   $��Center=�6=   Tags:6_     5{      -   5        $ 
filterTags��5{   E   $��1��6(   $��1��65   $	��0 2q�6y   ��6Y   �� *	AllTags+6y   �� 5|      $��2��6    $��0��6-   $��Center=�6=   	Climates:6c     5}      -   5        $ filterClimates��5}   E   $��2��6(   $��1��65   $	��0 2q�6~   ��6]   �� *
Climates+6~   �� 5~      $��3��6    $��0��6-    � ToolTip$ Tourist status��6=   	Tur stat:6a     5      -   5        $ filterTouristStatus��5   E   $��3��6(   $��1��65   $	��0 2q�6�   $ Tourist status��6�   ��6b   �� *TouristStatuses+6�   �� 5�      $��4��6!   $��0��6.   $��2��6>   $ 
Horizontal=�6R   $��Center=�6k   .+�5�      �� -   5        $��0q�5�   "   
����� �$
��10 5q�6L   $
��15 2q�6Z   .��6}   Reset6�   �� 5�      -   5        $��0q�5�   "   
����� �$
��10 5q�6L   $
��15 2q�6Z   .��6~   Filter6�   5�      5�      5�      5�      5�      5�      