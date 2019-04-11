using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace MyProject.AddDialogs
{
    /// <summary>
    /// Interaction logic for AddMonumentType.xaml
    /// </summary>
    public partial class AddMonumentType : Window
    {
        private MonumentType monumentType;
        private bool tutorialMode;
        private bool tutorialFinished = true;
        private bool windowClosing = false;

        public AddMonumentType()
        {
            InitializeComponent();

            this.monumentType = new MonumentType();
            this.DataContext = this.monumentType;

            this.tutorialMode = ((MainWindow)Application.Current.MainWindow).TutorialMode;

            if (!tutorialMode)
            {
                tutorialFinished = false;
                tbDesc.IsEnabled = false;
                tbIcon.IsEnabled = false;
                browseBtn.IsEnabled = false;

                tbID.LostFocus += TbID_LostFocus;
                tbName.LostFocus += TbName_LostFocus;
                tbDesc.LostFocus += TbDesc_LostFocus;
                this.Closing += AddMonumentType_Closing;
            }

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }

        private void AddMonumentType_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            windowClosing = true;
            ((MainWindow)Application.Current.MainWindow).tutorialWindow.Close();
        }

        private void TbID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!windowClosing)
            {
                if (string.IsNullOrWhiteSpace(tbID.Text))
                {
                    MainWindow.FollowInstructionsMessage();
                }
                else
                {
                    tbID.IsEnabled = false;
                    tbDesc.IsEnabled = true;
                }
            }
        }
        private void TbName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!tbID.IsEnabled && !windowClosing)
            {
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    MainWindow.FollowInstructionsMessage();
                }
                else
                {
                    tbName.IsEnabled = false;
                    browseBtn.IsEnabled = true;
                }
            }
        }

        private void TbDesc_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!tbName.IsEnabled && !windowClosing)
            {
                if (string.IsNullOrWhiteSpace(tbDesc.Text))
                {
                    MainWindow.FollowInstructionsMessage();
                }
                else
                {
                    tbDesc.IsEnabled = false;
                }
            }
        }
        
        private void AddMonumentType_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = tutorialFinished;
        }

        private void AddMonumentType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(tbID.Text) || string.IsNullOrEmpty(tbName.Text) || string.IsNullOrWhiteSpace(tbIcon.Text)))
            {
                //manually fire the bindings to get the initial validation
                tbID.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                tbName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                tbIcon.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                return;
            }
            MainWindow.connection.Open();

            string select = "SELECT * FROM MonumentType WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(select, MainWindow.connection);
            cmd.Parameters.Add(new SqlParameter("@id", monumentType.ID));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show(this, "Monument type with ID '" + monumentType.ID + "' already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MainWindow.connection.Close();
                    return;
                }
            }

            try
            {
                monumentType.Image = System.Drawing.Image.FromFile(monumentType.IconPath);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Unsupported image file!\r\n" + monumentType.IconPath, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow.connection.Close();
                return;
            }

            string query = "INSERT INTO MonumentType (ID,Name,Description,Icon,IconPath) VALUES (@id,@name,@description,@icon,@iconPath)";
            SqlCommand command = new SqlCommand(query, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", monumentType.ID));
            command.Parameters.Add(new SqlParameter("@name", monumentType.Name));
            command.Parameters.Add(new SqlParameter("@description", monumentType.Description + ""));
            command.Parameters.Add(new SqlParameter("@icon", File.ReadAllBytes(monumentType.IconPath)));
            command.Parameters.Add(new SqlParameter("@iconPath", monumentType.IconPath));
            command.ExecuteNonQuery();

            MainWindow.connection.Close();

            Monument.types.Add(monumentType.ID);
            
            this.Close();
            if (!tutorialMode)
            {
                MessageBox.Show("You have finished tutorial successfully!", "Tutorial", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            if (tbDesc.IsEnabled && !tutorialMode)
            {
                MainWindow.FollowInstructionsMessage();
                return;
            }
            string fileName = OpenDialogIcon.OpenDialog();
            if (fileName != null)
            {
                monumentType.IconPath = fileName;
                if (!tutorialMode)
                {
                    tutorialFinished = true;
                }
            }
            else
            {
                monumentType.IconPath = "";
            }
        }

        private void Cancel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = tutorialMode;
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Desc_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Do not allow more than 10 Lines in description textbox
            if (e.Key == Key.Enter)
            {
                if (tbDesc.LineCount >= 10)
                    e.Handled = true;
            }
        }
    }
}
