   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   D @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MyProject.ValidationMyProject.Validation 5   	   7 clr-namespace:MyProject.CommandsMyProject.Commands 5   	   /clr-namespace:MyProject.HelpMyProject.Help 5
   	   &    MyProject.AddDialogs.AddMonument   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   2vld"clr-namespace:MyProject.Validation     5   	   0cmd clr-namespace:MyProject.Commands     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	   	   'helpclr-namespace:MyProject.Help  5
   	     � Title$  Add Monument��5   	   $	��425��6   $	��550��6+   $	��430��67   $	��750��6G    � WindowStartupLocation$ CenterScreen=�6V    +� FocusedElement 6{   ��  �� ElementName$
 tbID�� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
addCommand��   Command$ cmd:RoutedCommands.Add��5   -   6�     5   
   -   5        $ cmd:RoutedCommands.Cancel��5      6y     5   
   $ ApplicationCommands.Help��6   -   5        helpCommand��5   <   .��5      � ���#70fffa!  MyProject.Help.HelpProvider   HelpKey$ helpAddEditMonument��6     � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��9* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��7* �6    � ColumnDefinitions 5!   
   �� 5"      $��3* �6   �� 5#      $��5* �6   �� 5$      $��2* �6   �� 5%      $��3* �6   .+�5'   
   ]� $��0��6   $��0��6!   $��4��61   .+�5(      �� -   5        	 ��Name$	 headline��5(      $	��Top=�6*      headerStyle#��[  6?   %#Please enter data for new monument:6�   �� 5)      $��Bottom=�6   62   5*      �� 5+   
   $��1��6   $��0��6!     textBlockAddDialogs#��[ 61   *ID:6e   �� 5,   
   $��2��6   $��0��6!   #��[ 61   *Name:6f   �� 5-   
   $��3��6   $��0��6!   #��[ 61   Description:6l   �� 5.   
   $��4��6   $��0��6!   #��[ 61   Type:6e   �� 5/   
   $��5��6   $��0��6!   #��[ 61   
Climate:6h   �� 50   
   $��6��6   $��0��6!   #��[ 61   Icon:6e   �� 51   
   $��7��6   $��0��6!   #��[ 61   Tourist status:6o   �� 52   
   $��8��6   $��0��6!   #��[ 61   	Income:6g   �� 53   
   $��9��6   $��0��6!   #��[ 61   Discovery date:6o   �� 54   
   $��11��6   $��0��6"   $
��Bold"�62   $��Italic$�6D   
���  ��$��Bottom=�6h   $
��5 10q�6�   * reqired field6�   �� 55   
   $��8��6   $��2��6"   $��2��62   $��2��6C   $��Center=�6W   $��Bottom=�6t   .+�56      �� -   5        
 ��Name$
 chcbxEcoEndangered��56       d� 	IsChecked 63   ��  �� Path$ EcologicallyEndangered�.��6e   Ecologically endangered6~   �� 57      -   5        $
 chcbxHabitat��57       6-   �� $ Habitat�.��6P   Habitat of endangered species6o   �� 58      -   5        $
 chcbxPopulatedRegion��58       65   �� $ PopulatedRegion�.��6`   In a populated region6w   59      �� 5:   
   $��10��6   $��0��6"   $��4��62   $��0 10 0 0q�6F   �� 5;   
   $��11��6   $��0��6#   $��4��63    �� Orientation$ 
Horizontal=�6G   $��Right=�6`   $��Bottom=�6|   .+�5<      �� -   5         ��Name$ confirmButton��5<      $��cmd:RoutedCommands.Add��6,   .��6M   Add��5=      �� 5>       �� 
TargetType" ��6   .�5?      ��  �� Property � �� �� Value$ DemiBold"�67   �� 5@       � ��$	 100��62   �� 5A       � �� 5B      �� 5C   "    �� 
TargetType" ��62   .R�5D   &   ��  ��Name$ border��6-   $��10q�6=    �� CornerRadius$ 20��6I   
����� � �� Padding$ 5q�6q   ._�5E   *   �� $��Center=�6;   $��Center=�6X   5F   '    �� Triggers 5G   &   P� 5H   *    P� Property �@J�IsMouseOver P� Value . . �5I   .   ��  �� 
TargetName$ border��65    � ��
 �����6_   5J   +   5L   #   5N      �� 5O       � {� .  66    �� Triggers 5P      ^� 5Q       ^� 
Conditions 5R   "   �� 5S   &    �� Binding 60   �� $ (Validation.HasError)�$
 tbID�� �� Value	 False6q   �� 5T   &    60   �� $ (Validation.HasError)�$ tbName��	 False6s   �� 5U   &    60   �� $ (Validation.HasError)�$ tbIncome��	 False6u   .0�5W   "   ��  � {� . 6>   5X      5Z      5\      �� 5]        buttonStyle#��[ 6   $��cmd:RoutedCommands.Cancel��6:   .��6^   Cancel6f   5^      �� 5_   
   -	   5         ��Name$
 tbID��5_      $��1��6    $��1��6-   $��2��6=   $��0 5 5 5q�6Q    �� 	MaxLength$ 16��6b     � ToolTip$,  &Maximum length of ID is 16 characters.��6q   .��6�   ��5`      �� 5a      $ ID�6   ! �� UpdateSourceTrigger$! PropertyChanged=�6$   " �� ValidationRules" 5b      '  !MyProject.Validation.EmptyTextBox  5c      ,  &System.Windows.Controls.ValidationRule#   ValidationStep$# RawProposedValue=�6+   5e      .��5f      $ =� ErrorTemplate$ 5g      �� 5h      .R�5i      �  5j      �� 5k       5m      �� 5n      �� 5o      .+�5q      �� $��0��64   �� 5r      $��1��6$   $��5 0 0 0q�6V   
���  ��$
��Bold"�6x   $��11(�6�   ��64   �� *[0].ErrorContent+6�   5s      5t      .��5u   (   5v      �� 5w   
   -
   5        $ tbName��5w      $��2��6"   $��1��6/   $��2��6?   $��0 5 5 5q�6S   $ 50��6d   $.  (Maximum length of Name is 50 characters.��6s   .��6�   ��5x      �� 5y      $
 Name�6   $! PropertyChanged=�6&   " 5z        5{      $# RawProposedValue=�6+   5}      .��5~      $ 5      �� 5�      .R�5�      �  5�      �� 5�       5�      �� 5�      �� 5�      .+�5�      �� $��0��64   �� 5�      $��1��6$   $��5 0 0 0q�6V   
���  ��$
��Bold"�6x   $��11(�6�   ��64   �� *[0].ErrorContent+6�   5�      5�      .��5�   (   5�      �� 5�   
   $��3��6   $��1��6$   $��2��64   $
��Auto=�6H   .��5�      �� -   5        $ tbDesc��5�      $��0 5 5 5q�6&   % �� AcceptsReturn% . & �� TextWrapping$
& Wrap=�6L   "' �� VerticalScrollBarVisibility$
' Auto=�6`   $	 250��6�   $6  0Maximum length of Description is 250 characters.��6�   ��6�   �� $ Description�6�   5�      �� 5�   
   -   5        ( ��Name$( cbType��5�      $��4��6#   $��1��60   $��2��6@   $��0 3 5 5q�6T   ) �� 
IsEditable) . * �� SelectedIndex$* 0��6�   ��6w   �� $ types�+ �� SelectedItem+ 6�   �� $
 Type��� 5�   
   -   5        $( 	cbClimate��5�      $��5��6&   $��1��63   $��2��6C   $��0 0 5 5q�6W   $* 0��6h   , �� SelectedValuePath$, Content��6z   + 6�   �� $ Climate�� 5�   
   $��6��6   $��1��6   $��2��6,    5�      �� 5�       5�      �� 5�      $��2* �6#   �� 5�      $��* �6#   .+�5�      �� -   5        $ tbIcon��5�      $��0��6&   $��	0 15 5 15q�66   - ^� ShowDuration$- 12000��6g   ��6I   �� *ImagePreview+.��6�     5�      �� 5�      .+�5�      �� $ 
Horizontal=�6%   .+�5�      �� QOEnter file path in format: [Disk letter]:\\[Folder name]\\[File name].extension6y   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� _]Backslash can be replaced with 2 backslashes. There can be more than one folder (Folder name)6�   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� Extension is JPG or PNG.6B   5�      5�      .��5�   #   5�      �� 5�      -   5        $��1��5�      #��[ 6%   $7  1Click to open file chooser and pick desired icon.��6_   .��6�   Browse6�   5�      �� 5�   
   $��Icon Preview��6   
����� �$��0 0 5 3q�6@   $��4��6Q   $��4��6^   $��3��6o   .��5�      �� $	��100��6   $	��100��6%   $��Center=�64   $��Center=�6Q   ��6l   �� *ImagePreview+. �� Mode$. OneWay=�5�      �� 5�   
   -   5        $( cbTouristStatus��5�      $��7��6,   $��1��69   $��2��6I   $��0 0 5 5q�6]   $* 0��6n   $, Content��6�   + 6�   �� $ TouristStatus��� 5�   
   $��8��6   $��1��6"   $ 
Horizontal=�62   .+�5�      �� $��0 5 5 5q�6   $��14(�6)   $6:   �� 5�      -   5        $ tbIncome��5�      $��0 5 5 5q�6(   $	��150��69   ��6E   �� $ Income�$! PropertyChanged=�5�      (  "System.Windows.Controls.DatePicker  5�   
   -   5        /  Name$/ 
datePicker��5�      $��9��6)   $��1��66   0 �� Today1   DisplayDateEnd#1 Z0 6F   2   SelectedDate2 6u   �� $ DiscoveryDate��� 5�   
   -   5        $��3��5�      $��3��6   $-  'Click to open dialog for choosing tags.��6E   ��5�      �� 5�      .R�5�      �� 3 ��Name$3 panel��6!   $��5q�60   $ 
Horizontal=�6;   $��Center=�6T   .+�5�      �� $*��$/MyProject;component/pickTagIcon.png��6    $��22��6N   �� 5�      $��Center=�6$   $��Center=�6A   $��5 0 0 0q�6\   #��[ 6m   Choose Tags6�   5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ panel��6%    � ��
 �����6N   5�      5�      5�      5�      5�      