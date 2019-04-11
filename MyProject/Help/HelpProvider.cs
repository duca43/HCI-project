using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyProject.Help
{
    public class HelpProvider
    {
        public static string GetHelpKey(DependencyObject obj)
        {
            return obj.GetValue(HelpKeyProperty) as string;
        }

        public static void SetHelpKey(DependencyObject obj, string value)
        {
            obj.SetValue(HelpKeyProperty, value);
        }
        private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e) {}

        public static readonly DependencyProperty HelpKeyProperty = DependencyProperty.RegisterAttached("HelpKey", typeof(string), typeof(HelpProvider), new PropertyMetadata("_DefaultValue", HelpKey));

        public static void ShowHelp(string helpKey)
        {
            Help helpWindow = new Help(helpKey);
            helpWindow.Show();
        }
    }
}
