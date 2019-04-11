using MyProject.AddDialogs;
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

namespace MyProject.EditDialogs
{
    /// <summary>
    /// Interaction logic for EditMonumentType.xaml
    /// </summary>
    public partial class EditMonumentType : Window
    {
        public MonumentType monumentType;
        public string oldMonumentTypeID;

        public EditMonumentType(MonumentType monumentType)
        {
            InitializeComponent();
        
            this.monumentType = monumentType;
            this.oldMonumentTypeID = monumentType.ID;
            this.DataContext = this.monumentType;

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }

        private void UpdateMonumentType_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UpdateMonumentType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow.connection.Open();

            string select = string.Format("SELECT * FROM MonumentType WHERE ID=@id AND ID NOT IN (SELECT ID FROM MonumentType WHERE ID=@oldId)");
            SqlCommand cmd = new SqlCommand(select, MainWindow.connection);
            cmd.Parameters.Add(new SqlParameter("@id", monumentType.ID));
            cmd.Parameters.Add(new SqlParameter("@oldId", oldMonumentTypeID));

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

            string update = "UPDATE MonumentType SET ID = @id, Name = @name, Description = @description, Icon = @icon, IconPath = @iconPath WHERE ID=@oldId";
            SqlCommand command = new SqlCommand(update, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@oldId", oldMonumentTypeID));
            command.Parameters.Add(new SqlParameter("@id", monumentType.ID));
            command.Parameters.Add(new SqlParameter("@name", monumentType.Name));
            command.Parameters.Add(new SqlParameter("@description", monumentType.Description + ""));
            command.Parameters.Add(new SqlParameter("@icon", File.ReadAllBytes(monumentType.IconPath)));
            command.Parameters.Add(new SqlParameter("@iconPath", monumentType.IconPath));
            command.ExecuteNonQuery();

            //Update icons of all monuments that are using icon of its type
            update = "UPDATE Monument SET Icon = @icon, IconPath = @iconPath WHERE Type=@id AND IconTaken=1";
            command = new SqlCommand(update, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@icon", File.ReadAllBytes(monumentType.IconPath)));
            command.Parameters.Add(new SqlParameter("@id", monumentType.ID));
            command.Parameters.Add(new SqlParameter("@iconPath", monumentType.IconPath));
            command.ExecuteNonQuery();

            select = "SELECT ID, Icon FROM Monument WHERE Type=@id AND IconTaken=1";
            command = new SqlCommand(select, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", monumentType.ID));

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    foreach (Monument mnmt in MainWindow.Monuments)
                    {
                        if (mnmt.ID.Equals(dataReader["ID"] as string))
                        {
                            mnmt.Image = System.Drawing.Image.FromFile(monumentType.IconPath);
                            mnmt.ImagePreview = monumentType.IconPath;
                            break;
                        }
                    }
                }
            }
            
            MainWindow.connection.Close();

            if (!monumentType.ID.Equals(oldMonumentTypeID))
            {
                Monument.types.Add(monumentType.ID);
                Monument.types.Remove(oldMonumentTypeID);
            }
            
            this.Close();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            string fileName = OpenDialogIcon.OpenDialog();
            if (fileName != null)
            {
                monumentType.IconPath = fileName;
            }
            else
            {
                monumentType.IconPath = "";
            }
        }

        private void Cancel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
