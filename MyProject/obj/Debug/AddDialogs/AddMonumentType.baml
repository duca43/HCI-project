   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MyProject.AddDialogsMyProject.AddDialogs  5   	   ;"clr-namespace:MyProject.ValidationMyProject.Validation  5   	   7 clr-namespace:MyProject.CommandsMyProject.Commands  5   	   /clr-namespace:MyProject.HelpMyProject.Help  5	   	   *    $MyProject.AddDialogs.AddMonumentType   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MyProject.AddDialogs     5   	   2vld"clr-namespace:MyProject.Validation     5   	   0cmd clr-namespace:MyProject.Commands     5   	   -helpclr-namespace:MyProject.Help     5	   	     � Title$  Add Monument Type��5   	   $	��320��6#   $	��520��60   $	��430��6<   $	��750��6L    � WindowStartupLocation$ CenterScreen=�6[    +� FocusedElement 6�   ��  �� ElementName$
 tbID�� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
addCommand��   Command$ cmd:RoutedCommands.Add��5   -   6�     5   
   -   5        $ cmd:RoutedCommands.Cancel��5      6y     5   
   $ ApplicationCommands.Help��6   -   5        helpCommand��5   <   .��5      � -   5         �Name$
 grid��5      ���#70fffa!   MyProject.Help.HelpProvider   HelpKey$ helpAddEditMonumentType��6.    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��5* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��3* �6   	 � ColumnDefinitions	 5   
   �� 5      $��3* �6   �� 5      $	��10* �6   �� 5      $��4* �6   .+�5    
   ]� $��0��6   $��0��6!   $��3��61   .+�5!      �� $	��Top=�6      headerStyle#��[  6-   *(Please enter data for new monument type:6|   �� 5"      $��Bottom=�6   62   5#      �� 5$   
   $��1��6   $��0��6!     textBlockAddDialogs#��[ 61   *ID:6d   �� 5%   
   $��2��6   $��0��6!   #��[ 61   *Name:6f   �� 5&   
   $��3��6   $��0��6!   #��[ 61   Description:6l   �� 5'   
   $��4��6   $��0��6!   #��[ 61   *Icon:6f   �� 5(   
   $��5��6   $��0��6!   $��3��61   $��0 15 0 0q�6E   6Y   �� 5)   
   $��6��6   $��0��6!   $
��Bold"�61   $��Italic$�6C   
���  ��$��Bottom=�6g   $
��5 10q�6�   * reqired field6�   �� 5*   
   $��6��6   $��0��6"   $��3��62   
 �� Orientation$
 
Horizontal=�6F   $��Right=�6_   $��Bottom=�6{   .+�5+      �� $��cmd:RoutedCommands.Add��6   .��66   Add��5,      �� 5-       �� 
TargetType" ��6   .�5.      ��  �� Property � �� �� Value$ DemiBold"�67   �� 5/       � ��$	 100��62   �� 50       � �� 51      �� 52   "    �� 
TargetType" ��62   .R�53   &   ��  ��Name$ border��6-   $��10q�6=    �� CornerRadius$ 20��6I   
����� � �� Padding$ 5q�6q   ._�54   *   �� $��Center=�6;   $��Center=�6X   55   '    �� Triggers 56   &   P� 57   *    P� Property �@J�IsMouseOver P� Value . . �58   .   ��  �� 
TargetName$ border��65    � ��
 �����6_   59   +   5;   #   5=      �� 5>       � {� .  66    �� Triggers 5?      ^� 5@       ^� 
Conditions 5A   "   �� 5B   &    �� Binding 60   ��  �� Path$ (Validation.HasError)�$
 tbID�� �� Value	 False6q   �� 5C   &    60   �� $ (Validation.HasError)�$ tbName��	 False6s   �� 5D   &    60   �� $ (Validation.HasError)�$ tbIcon��	 False6s   .0�5F   "   ��  � {� . 6>   5G      5I      5K      �� 5L        buttonStyle#��[ 6   $��cmd:RoutedCommands.Cancel��6:   .��6^   Cancel6f   5M      �� 5N   
   -   5         ��Name$
 tbID��5N      $��1��6    $��1��6-   $��0 5 5 5q�6=    �� 	MaxLength$ 16��6N    � ToolTip$, &Maximum length of ID is 16 characters.��6]   .��6�   ��5O      �� 5P      $ ID�6    �� UpdateSourceTrigger$ PropertyChanged=�6$    �� ValidationRules 5Q      '   !MyProject.Validation.EmptyTextBox  5R      ,  &System.Windows.Controls.ValidationRule    ValidationStep$  RawProposedValue=�6+   5T      .��5U      ! =� ErrorTemplate! 5V      �� 5W      .R�5X      �  5Y      �� 5Z      	 5\      �� 5]      �� 5^      .+�5`      �� $��0��64   �� 5a      $��1��6$   $��5 0 0 0q�6V   
���  ��$
��Bold"�6x   $��11(�6�   ��64   �� *[0].ErrorContent+6�   5b      5c      .��5d   (   5e      �� 5f   
   -   5        $ tbName��5f      $��2��6"   $��1��6/   $��0 5 5 5q�6?   $ 50��6P   $. (Maximum length of Name is 50 characters.��6_   .��6�   ��5g      �� 5h      $
 Name�6   $ PropertyChanged=�6&    5i        5j      $  RawProposedValue=�6+   5l      .��5m      ! 5n      �� 5o      .R�5p      �  5q      �� 5r      	 5t      �� 5u      �� 5v      .+�5x      �� $��0��64   �� 5y      $��1��6$   $��5 0 0 0q�6V   
���  ��$
��Bold"�6x   $��11(�6�   ��64   �� *[0].ErrorContent+6�   5z      5{      .��5|   (   5}      �� 5~   
   $��3��6   $��1��6$   $
��Auto=�64   .��5      �� -   5        $ tbDesc��5      $��0 5 5 5q�6&   " �� AcceptsReturn" . # �� TextWrapping$
# Wrap=�6L   $	 250��6�   $6 0Maximum length of Description is 250 characters.��6�   ��6`   �� $ Description�6�   5�      � 5�   
   $��4��6   $��1��6    5�      �� 5�      	 5�      �� 5�      $��2* �6#   �� 5�      $��* �6#   .+�5�      �� -   5        $ tbIcon��5�      $��0��6&   $��	0 15 5 15q�66   $ ^� ShowDuration$$ 12000��6I   .��6m    5�      �� 5�      .+�5�      �� $
 
Horizontal=�6%   .+�5�      �� QOEnter file path in format: [Disk letter]:\\[Folder name]\\[File name].extension6y   5�      �� 5�      $
 
Horizontal=�6%   .+�5�      �� _]Backslash can be replaced with 2 backslashes. There can be more than one folder (Folder name)6�   5�      �� 5�      $
 
Horizontal=�6%   .+�5�      �� Extension is JPG or PNG.6B   5�      5�      .��5�   #   ��5�      �� 5�      $ IconPath�6   $ PropertyChanged=�6.    5�        5�      $  RawProposedValue=�6/   5�      .��5�       ! 5�      �� 5�      .R�5�      �  5�      �� 5�   "   �� 5�   "   	 5�      �� 5�   "   .+�5�      �� $��0��68   �� 5�      $��1��6(   $��0 5 0 0q�6W   
���  ��$
��Bold"�6y   $��11(�6�   ��65   �� *[0].ErrorContent+6�   5�      5�      .��5�   ,   5�      �� 5�      -	   5        % ��Name$% 	browseBtn��5�      $��1��6(   #��[ 68   $7 1Click to open file chooser and pick desired icon.��6r   .��6�   Browse6�   5�      �� 5�   
   $��Icon Preview��6   
����� �$��0 0 5 3q�6@   $��3��6Q   $��3��6^   $��2��6o   .��5�      �� $��64��6   $��64��6#   $��Center=�61   $��Center=�6N   ��6i   �� *
IconPath+& �� Mode$& OneWay=�5�      5�      5�      