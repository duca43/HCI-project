using MyProject.AddDialogs;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for EditMonument.xaml
    /// </summary>
    public partial class EditMonument : Window
    {
        public Monument mnmt;
        public string oldMnmtID;
        public string oldType;

        public EditMonument(Monument mnmt)
        {
            this.mnmt = mnmt;
            this.oldMnmtID = mnmt.ID;
            this.oldType = mnmt.Type;

            InitializeComponent();

            this.DataContext = this.mnmt;

            cbClimate.ItemsSource = Monument.climates;
            cbTouristStatus.ItemsSource = Monument.touristStatuses;
            cbType.ItemsSource = Monument.types;

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }
    
        private void UpdateMonument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UpdateMonument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!Monument.types.Contains(mnmt.Type))
            {
                MessageBox.Show(this, "Type with ID '" + cbType.Text + "' not exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainWindow.connection.Open();

            string select = string.Format("SELECT * FROM Monument WHERE ID=@id AND ID NOT IN (SELECT ID FROM Monument WHERE ID=@oldId)");
            SqlCommand command = new SqlCommand(select, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", mnmt.ID));
            command.Parameters.Add(new SqlParameter("@oldId", oldMnmtID));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show(this, "Monument with ID '" + mnmt.ID + "' already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MainWindow.connection.Close();
                    return;
                }
            }

            try
            {
                mnmt.Image = System.Drawing.Image.FromFile(mnmt.ImagePreview);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Unsupported image file!\r\n" + mnmt.ImagePreview, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow.connection.Close();
                return;
            }
            
            string insert = "UPDATE Monument SET ID = @id, Name = @name, Description = @description, Type = @type, Climate = @climate, Icon = @icon, EcologicallyEndangered = @ee, Habitat = @habitat, PopulatedRegion = @pr, TouristStatus = @ts, Income = @income, DiscoveryDate = @dd, IconTaken = @iconTaken, IconPath = @iconPath WHERE ID=@oldId";            
            command = new SqlCommand(insert, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@oldId", oldMnmtID));
            command.Parameters.Add(new SqlParameter("@id", mnmt.ID));
            command.Parameters.Add(new SqlParameter("@name", mnmt.Name));
            command.Parameters.Add(new SqlParameter("@description", mnmt.Description + ""));
            command.Parameters.Add(new SqlParameter("@type", mnmt.Type));
            command.Parameters.Add(new SqlParameter("@climate", mnmt.Climate));
            command.Parameters.Add(new SqlParameter("@icon", File.ReadAllBytes(mnmt.ImagePreview)));
            command.Parameters.Add(new SqlParameter("@ee", mnmt.EcologicallyEndangered));
            command.Parameters.Add(new SqlParameter("@habitat", mnmt.Habitat));
            command.Parameters.Add(new SqlParameter("@pr", mnmt.PopulatedRegion));
            command.Parameters.Add(new SqlParameter("@ts", mnmt.TouristStatus));
            command.Parameters.Add(new SqlParameter("@income", mnmt.Income + 0));
            command.Parameters.Add(new SqlParameter("@dd", mnmt.DiscoveryDate));
            command.Parameters.Add(new SqlParameter("@iconTaken", mnmt.IconTaken));
            command.Parameters.Add(new SqlParameter("@iconPath", mnmt.ImagePreview));
            command.ExecuteNonQuery();

            string delete = "DELETE FROM MonumentTag WHERE MonID=@monId";
            command = new SqlCommand(delete, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@monId", oldMnmtID));
            command.ExecuteNonQuery();

            foreach (Tag pickedTag in mnmt.tags)
            {
                insert = "INSERT INTO MonumentTag (MonID,TagID) VALUES (@monId,@tagId)";
                command = new SqlCommand(insert, MainWindow.connection);
                command.Parameters.Add(new SqlParameter("@monId", mnmt.ID));
                command.Parameters.Add(new SqlParameter("@tagId", pickedTag.ID));
                command.ExecuteNonQuery();
            }

            MainWindow.connection.Close();

            foreach(var m in MainWindow.Monuments)
            {
                if (m.ID.Equals(oldMnmtID))
                {
                    MainWindow.Monuments.Remove(m);
                    MainWindow.Monuments.Add(this.mnmt);
                    break;
                }
            }

            this.Close();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            string fileName = OpenDialogIcon.OpenDialog();
            if (fileName != null)
            {
                mnmt.ImagePreview = fileName;
                mnmt.IconTaken = false;
            }
            {
                mnmt.ImagePreview = "";
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

        private void PickTags_Click(object sender, RoutedEventArgs e)
        {
            var pickTagsWindow = new PickTags(mnmt);
            pickTagsWindow.Owner = this;
            pickTagsWindow.ShowDialog();
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TakeImageFromNewType();
        }

        private string TakeImageFromNewType()
        {
            if (mnmt.IconTaken && Monument.types.Contains(mnmt.Type))
            {
                MainWindow.connection.Open();
                string select = "SELECT IconPath FROM MonumentType WHERE Id = @id";
                SqlCommand command = new SqlCommand(select, MainWindow.connection);
                command.Parameters.Add(new SqlParameter("@id", mnmt.Type));
                
                DataTable dataTable = new DataTable("MonumentType");
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    dataTable.Load(dataReader);
                }
                MainWindow.connection.Close();
                String imgUrl = dataTable.Rows[0]["IconPath"] as string;
                mnmt.ImagePreview = imgUrl;

                return imgUrl;
            }
            else
                return null;
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