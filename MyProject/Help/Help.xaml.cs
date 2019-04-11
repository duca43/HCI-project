using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        private bool _enableHome = true;

        public bool EnableHome
        {
            get
            {
                return _enableHome;
            }
            set
            {
                if (value != _enableHome)
                {
                    _enableHome = value;
                    OnPropertyChanged("EnableHome");
                }
            }
        }

        public Help(string helpKey)
        {
            InitializeComponent();

            this.DataContext = this;

            Navigate(helpKey);

            JavaScriptHandler javaScriptHandler = new JavaScriptHandler();
            helpBrowser.ObjectForScripting = javaScriptHandler;
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((helpBrowser != null) && (helpBrowser.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            helpBrowser.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((helpBrowser != null) && (helpBrowser.CanGoForward));
        }
        
        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            helpBrowser.GoForward();
        }

        private void BrowseHome_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (helpBrowser != null);
        }
        private void BrowseHome_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Navigate("helpMainPage");
        }

        private void Navigate(string helpKey)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo parentInfo = Directory.GetParent(currentDirectory);
            parentInfo = parentInfo.Parent;
            string path = String.Format("{0}/Help/htmlResources/{1}.htm", parentInfo.FullName, helpKey);

            if (!File.Exists(path))
            {
                helpKey = "error";
            }

            helpBrowser.Navigate(new Uri(String.Format("{0}/Help/htmlResources/{1}.htm", parentInfo.FullName, helpKey)));
        }

        private void HelpBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            string navigatedPath = e.Uri.LocalPath;
            string navigatedHtml = navigatedPath.Substring(navigatedPath.LastIndexOf('\\') + 1);
            if (navigatedHtml.Equals("helpMainPage.htm"))
            {
                EnableHome = false;
            }
            else
            {
                EnableHome = true;
            }
        }
    }
}