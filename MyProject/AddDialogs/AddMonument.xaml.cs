using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
using Microsoft.Win32;
using MyProject.Entities;
using MyProject.Other;
using MyProject.Tables;

namespace MyProject.AddDialogs
{
    /// <summary>
    /// Interaction logic for AddMonument.xaml
    /// </summary>
    public partial class AddMonument
    {

        private Monument mnmt;
        
        public AddMonument()
        {
            InitializeComponent();

            this.mnmt = new Monument();
            this.DataContext = this.mnmt;
            
            cbClimate.ItemsSource = Monument.climates;
            cbTouristStatus.ItemsSource = Monument.touristStatuses;
            cbType.ItemsSource = Monument.types;

            mnmt.Type = Monument.types[0]; //setting default value for type of monument

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }

        private void AddMonument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddMonument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbID.Text) || string.IsNullOrWhiteSpace(tbName.Text))
            {
                //manually fire the bindings to get the initial validation
                tbID.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                tbName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                return;
            }

            if (!Monument.types.Contains(cbType.Text))
            {
                MessageBox.Show(this, "Type with ID '" + cbType.Text + "' not exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            MainWindow.connection.Open();

            string select = "SELECT * FROM Monument WHERE ID=@id";
            SqlCommand cmd = new SqlCommand(select, MainWindow.connection);
            cmd.Parameters.Add(new SqlParameter("@id", mnmt.ID));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show(this, "Monument with ID '" + mnmt.ID + "' already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MainWindow.connection.Close();
                    return;
                }
            }
            mnmt.IconTaken = false;
            if (string.IsNullOrWhiteSpace(mnmt.ImagePreview))
            {
                select = "SELECT Id,IconPath FROM MonumentType WHERE ID=@type";
                cmd = new SqlCommand(select, MainWindow.connection);
                cmd.Parameters.Add(new SqlParameter("@type", mnmt.Type));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mnmt.ImagePreview = reader["IconPath"] as string; //taking icon of type for this monument, because his icon is not choosed by user
                        mnmt.IconTaken = true;
                    }
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

            //Inserting added monument in database as a new record
            string insert = "INSERT INTO Monument (ID,Name,Description,Type,Climate,Icon,EcologicallyEndangered,Habitat,PopulatedRegion,TouristStatus,Income,DiscoveryDate,IconTaken,IconPath) VALUES (@id,@name,@description,@type,@climate,@icon,@ee,@habitat,@pr,@ts,@income,@dd,@iconTaken,@iconPath)";
            SqlCommand command = new SqlCommand(insert, MainWindow.connection);
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


            foreach (Tag pickedTag in mnmt.tags)
            {
                insert = "INSERT INTO MonumentTag (MonID,TagID) VALUES (@monId,@tagId)";
                command = new SqlCommand(insert, MainWindow.connection);
                command.Parameters.Add(new SqlParameter("@monId", mnmt.ID));
                command.Parameters.Add(new SqlParameter("@tagId", pickedTag.ID));
                command.ExecuteNonQuery();
            }
            
            MainWindow.connection.Close();

            MainWindow.Monuments.Add(mnmt);

            this.Close();
        }
        
        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            string fileName = OpenDialogIcon.OpenDialog();
            if (fileName != null)
            {
                mnmt.ImagePreview = fileName;
            }
            else
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