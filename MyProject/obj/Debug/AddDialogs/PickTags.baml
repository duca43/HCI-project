   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MyProject.AddDialogsMyProject.AddDialogs  5   	   /clr-namespace:MyProject.HelpMyProject.Help  5   	   #    MyProject.AddDialogs.PickTags   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MyProject.AddDialogs     5   	   -helpclr-namespace:MyProject.Help     5   	     � Title$  Choose Tags��5	   	   $	��300��6   $	��450��6*    � WindowStartupLocation$ CenterOwner=�66    � WindowStyle$
 None=�6Z    � 
ResizeMode$ NoResize=�6m   $��3q�6�    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
      Command$ ApplicationCommands.Help��6   -   5        helpCommand��5   <   .��5      � ���#70fffa!   MyProject.Help.HelpProvider   HelpKey$ helpPickTags��6     � RowDefinitions 5   
   �� 5      �� 5      $��7* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      �� 5      $��5* �6   .+�5   
   �� $��0��6   $��0��6$      headerStyle#��[  61   $��Center=�6V   List of available tags:6�   �� 5   
   $��2��6   $��0��6$   #��[  61   $��Center=�6V   List of chosen tags:6�   �� 5   
   -   5        	 ��Name$	 listViewLeft��5      $��0��6)   $��1��69   ���#70fffa$��2q�6{   
 J� 	AllowDrop
 . ��6F   �� *	AllTags+��5      �� 5      .R�5      � .+�5       �� 
���   �$��1q�65   ._�5!      �� $��     ��6(   $��14(�65   ��6C   �� *	ColorCode+5"      �� 5#      $
��Bold"�68   $��14(�6J   $��5 0 0 0q�6X   ��6$   �� *ID+6X   5$      5%      5'      �� 5)   
   -   5        $	 listViewRight��5)      $��2��6*   $��1��6:   $��2q�6j   ���#70fffa
 . ��6G   �� *
PickedTags+��5,      �� 5-      .R�5.      � .+�5/      �� 
���   �$��1q�65   ._�50      �� $��     ��6(   $��14(�65   ��6C   �� *	ColorCode+51      �� 52      $
��Bold"�68   $��14(�6J   $��5 0 0 0q�6X   ��6$   �� *ID+6X   53      54      56      �� 57   
   -   5        $��1��57      $��1��6!   $	��Top=�6.     buttonStyle#��[ 6F   $��0.4,50.4,199.2,0q�6k   $��13(�6�   $��2��6�   $
��Auto��6�   .��6�   <6�   �� 58   
   -   5        $��1��58      $��1��6!   $��Bottom=�6.   #��[ 6I   $��0.4,0,199.2,50q�6n   $��13(�6�   $��2��6�   $
��Auto��6�   .��6�   >6�   �� 59   
   -   5        $��0��59      $��2��6!   $��3��6.   $��Center=�6B   #��[ 6_   .��6�   Finish6�   5:      5;      