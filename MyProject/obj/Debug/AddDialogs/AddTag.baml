   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MyProject.AddDialogsMyProject.AddDialogs  5   	   ;"clr-namespace:MyProject.ValidationMyProject.Validation  5   	   7 clr-namespace:MyProject.CommandsMyProject.Commands  5	   	   /clr-namespace:MyProject.HelpMyProject.Help  5
   	   !    MyProject.AddDialogs.AddTag   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   .local"clr-namespace:MyProject.AddDialogs  5   	   ,vld"clr-namespace:MyProject.Validation  5   	   *cmd clr-namespace:MyProject.Commands  5	   	   'helpclr-namespace:MyProject.Help  5
   	     � Title$  Add Tag��5   	   $	��300��6   $	��480��6&   $	��430��62   $	��750��6B    � WindowStartupLocation$ CenterScreen=�6Q    +� FocusedElement 6v   ��  �� ElementName$
 tbID�� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
addCommand��   Command$ cmd:RoutedCommands.Add��5   -   6�     5   
   -   5        $ cmd:RoutedCommands.Cancel��5      6y     5   
   $ ApplicationCommands.Help��6   -   5        helpCommand��5   <   .��5      � ���#70fffa!   MyProject.Help.HelpProvider   HelpKey$ helpAddEditTag��6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $	��10* �6   �� 5      $��5* �6   .+�5    
   ]� $��0��6   $��0��6!   $��3��61   .+�5!      �� $	��Top=�6      headerStyle#��[  6-    Please enter data for new tag:6r   �� 5"      $��Bottom=�6   62   5#      �� 5$   
   $��1��6   $��0��6!     textBlockAddDialogs#��[ 61   *ID:6d   �� 5%   
   $��2��6   $��0��6!   #��[ 61   Description:6l   �� 5&   
   $��3��6   $��0��6!   #��[ 61   Color:6f   �� 5'   
   $��4��6   $��0��6!   $��3��61   $��0 15 0 0q�6E   6Y   �� 5(   
   $��5��6   $��0��6!   $
��Bold"�61   $��Italic$�6C   
���  ��$��Bottom=�6g   $
��5 10q�6�   * reqired field6�   �� 5)   
   $��5��6   $��0��6"   $��3��62   	 �� Orientation$	 
Horizontal=�6F   $��Right=�6_   $��Bottom=�6{   .+�5*      �� $��cmd:RoutedCommands.Add��6   .��66   Add��5+      �� 5,      
 �� 
TargetType"
 ��6   .�5-      ��  �� Property � �� �� Value$ DemiBold"�67   �� 5.       � ��$	 100��62   �� 5/       � �� 50      �� 51   "    �� 
TargetType" ��62   .R�52   &   ��  ��Name$ border��6-   $��10q�6=    �� CornerRadius$ 20��6I   
����� � �� Padding$ 5q�6q   ._�53   *   �� $��Center=�6;   $��Center=�6X   54   '    �� Triggers 55   &   P� 56   *    P� Property �@J�IsMouseOver P� Value . . �57   .   ��  �� 
TargetName$ border��65    � ��
 �����6_   58   +   5:   #   5<      �� 5=       � {� .  66    �� Triggers 5>      ^� 5?       ^� 
Conditions 5@   "   �� 5A   &    �� Binding 60   ��  �� Path$ (Validation.HasError)�$
 tbID�� �� Value	 False6q   .0�5C   "   ��  � {� . 6>   5D      5F      5H      �� 5I        buttonStyle#��[ 6   $��cmd:RoutedCommands.Cancel��6:   .��6^   Cancel6f   5J      �� 5K   
   -   5         ��Name$
 tbID��5K      $��1��6    $��1��6-   $��0 5 5 5q�6=    �� 	MaxLength$ 16��6N    � ToolTip$, &Maximum length of ID is 16 characters.��6]   .��6�   ��5L      �� 5M      $ ID�6    �� UpdateSourceTrigger$ PropertyChanged=�6$    �� ValidationRules 5N      '   !MyProject.Validation.EmptyTextBox  5O      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6+   5Q      .��5R        =� ErrorTemplate  5S      �� 5T      .R�5U      �  5V      �� 5W       5Y      �� 5Z      �� 5[      .+�5]      �� $��0��64   �� 5^      $��1��6$   $��5 0 0 0q�6V   
���  ��$
��Bold"�6x   $��11(�6�   ��64   �� *[0].ErrorContent+6�   5_      5`      .��5a   (   5b      �� 5c   
   $��2��6   $��1��6$   $��2��64   $
��Auto=�6H   .��5d      �� -   5        $ tbDesc��5d      $��0 5 5 5q�6&   ! �� AcceptsReturn! . " �� TextWrapping$
" Wrap=�6L   $	 250��6�   $6 0Maximum length of Description is 250 characters.��6�   ��6`   �� $ Description�6�   5e      #  Xceed.Wpf.Toolkit.ColorPicker  5f   
   -   5        $��tagColor��5f      $��3��6,   $��1��69   $��2��6I   $��0 0 5 0q�6]   $F @Choose color you want from color picker. Default color is white.��6�   #   SelectedColor# 6n   �� $ Color�6�   5g      5h      