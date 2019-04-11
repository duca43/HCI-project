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

namespace MyProject.EditDialogs
{
    /// <summary>
    /// Interaction logic for EditTag.xaml
    /// </summary>
    public partial class EditTag : Window
    {
        private Tag tag;
        private string oldTagID;

        public EditTag(Tag tag)
        {
            InitializeComponent();

            this.tag = tag;
            this.oldTagID = tag.ID;
            this.DataContext = this.tag;

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }
        private void EditTag_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EditTag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow.connection.Open();

            string select = "SELECT * FROM Tag WHERE Id=@id AND ID NOT IN (SELECT ID FROM Tag WHERE ID=@oldId)";
            SqlCommand cmd = new SqlCommand(select, MainWindow.connection);
            cmd.Parameters.Add(new SqlParameter("@id", tag.ID));
            cmd.Parameters.Add(new SqlParameter("@oldId", oldTagID));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show(this, "Tag with ID '" + tag.ID + "' already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MainWindow.connection.Close();
                    return;
                }
            }

            string query = "UPDATE Tag SET ID = @id, Description = @description, Color = @color, ColorCode = @colorCode WHERE ID=@oldId";
            SqlCommand command = new SqlCommand(query, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", tag.ID));
            command.Parameters.Add(new SqlParameter("@oldId", oldTagID));
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
