   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyProject.HelpMyProject.Help  5   	       MyProject.Help.Help   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyProject.Help     5   	     � Title$  Online Help��5   	   $	��350��6   $	��470��6*   $	��400��66   $	��600��6F    � WindowStartupLocation$ CenterScreen=�6U    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$# NavigationCommands.BrowseBack��5
      6d     5   
   -   5        $&  NavigationCommands.BrowseForward��5      6j     5   
   -   5        $# NavigationCommands.BrowseHome��5      6d   .��5      ]� .+�5   
   c� $	��Top=�6   
�����@�.@�5      �� $#��NavigationCommands.BrowseHome��6   $��24��6=   $��24��6L    � ToolTip$ 	Home page��6Z   {�6n   �� *
EnableHome+.��5      �� $'��!/MyProject;component/homePage.png��6   5      �� 5      �� 5      $#��NavigationCommands.BrowseBack��6   .��6>   
◀ Back6F   �� 5      �� 5      $&�� NavigationCommands.BrowseForward��6   .��6@   Forward ▶6K   5      (  "System.Windows.Controls.WebBrowser  5   
   -   5        $��helpBrowser��5      6L   5      5      