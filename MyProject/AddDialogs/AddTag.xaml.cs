using MyProject.Entities;
using System;
using System.Collections.Generic;
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

namespace MyProject.AddDialogs
{
    /// <summary>
    /// Interaction logic for AddTag.xaml
    /// </summary>
    public partial class AddTag : Window
    {
        private Tag tag;
        public AddTag()
        {
            InitializeComponent();

            this.tag = new Tag();
            this.tag.Color = System.Windows.Media.Color.FromArgb(255, 255, 255, 255); //Initialize color to white with 100% opacity
            this.DataContext = tag;

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }
        private void AddTag_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text))
            {
                //manually fire the bindings to get the initial validation
                tbID.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                return;

            }

            MainWindow.connection.Open();

            string select = "SELECT * FROM Tag WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(select, MainWindow.connection);
            cmd.Parameters.Add(new SqlParameter("@id", tag.ID));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show(this, "Tag with ID '" + tag.ID + "' already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MainWindow.connection.Close();
                    return;
                }
            }

            string query = "INSERT INTO Tag (ID,Description,Color,ColorCode) VALUES (@id,@description,@color,@colorCode)";
            SqlCommand command = new SqlCommand(query, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", tag.ID));
            command.Parameters.Add(new SqlParameter("@description", tag.Description + ""));

            using (var stream = new MemoryStream())
            {
                var drawingcolor = System.Drawing.Color.FromArgb(tag.Color.A, tag.Color.R, tag.Color.G, tag.Color.B);
                Bitmap img = new Bitmap(32, 32);
                Graphics.FromImage(img).Clear(drawingcolor);
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                command.Parameters.Add(new SqlParameter("@color", stream.ToArray()));
                command.Parameters.Add(new SqlParameter("@colorCode", tag.Color.ToString()));
            }

            command.ExecuteNonQuery();

            MainWindow.connection.Close();

            this.Close();
        }
        
        private void Cancel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
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