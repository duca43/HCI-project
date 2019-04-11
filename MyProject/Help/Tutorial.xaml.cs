using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyProject.Help
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window
    {
        public Tutorial(Window originator)
        {
            InitializeComponent();

            this.Owner = originator;
            this.Top = originator.Top + (originator.Height - this.Height) / 2;
            this.Left = originator.Left + (originator.Width - this.Width);

            JavaScriptHandler javaScriptHandler = new JavaScriptHandler();
            tutorialBrowser.ObjectForScripting = javaScriptHandler;
            Navigate("tutorialMainPage.htm");
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((tutorialBrowser != null) && (tutorialBrowser.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tutorialBrowser.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((tutorialBrowser != null) && (tutorialBrowser.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            tutorialBrowser.GoForward();
        }

        public void Navigate(string htmlFile)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo parentInfo = Directory.GetParent(currentDirectory);
            parentInfo = parentInfo.Parent;
            tutorialBrowser.Navigate(new Uri(String.Format("{0}/Help/htmlResources/{1}", parentInfo.FullName, htmlFile)));
        }
    }
}
