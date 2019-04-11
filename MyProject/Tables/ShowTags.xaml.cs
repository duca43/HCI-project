using MyProject.AddDialogs;
using MyProject.EditDialogs;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyProject.Tables
{
    /// <summary>
    /// Interaction logic for ShowTags.xaml
    /// </summary>
    public partial class ShowTags : Window
    {
        private DependencyObject dep;

        public ShowTags()
        {
            InitializeComponent();

            this.DataContext = this;

            dgrTags.MouseDoubleClick += DgrTags_MouseDoubleClick;
            dgrTags.ContextMenuOpening += DgrTags_ContextMenuOpening;
            dgrTags.PreviewKeyDown += DgrTags_PreviewKeyDown;

            ShowMonuments.DoSelectQuery(dgrTags, "Tag");

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }

        private void DgrTags_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridRow))
                dep = VisualTreeHelper.GetParent(dep);

            if (dep == null) return;

            DataGridRow currentRow = dep as DataGridRow;
            EditExecute(currentRow.Item as DataRowView);
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow currentRow = dep as DataGridRow;
            EditExecute(currentRow.Item as DataRowView);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dgrTags.SelectedItems != null)
            {
                EditExecute(dgrTags.SelectedItem as DataRowView);
            }
        }

        private void DgrTags_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridRow))
                dep = VisualTreeHelper.GetParent(dep);

            if (dep == null) return;
        }

        private void EditExecute(DataRowView dataRowView)
        {
            DataRow dataRow = dataRowView.Row as DataRow;

            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(dataRow["ColorCode"] as string);
            Color color = Color.FromArgb(c.A, c.R, c.G, c.B);
            
            Tag tag = new Tag(dataRow["ID"] as string, dataRow["Description"] as string, color, dataRow["ColorCode"] as string);

            var editWindow = new EditTag(tag);
            editWindow.Closed += EditWindow_Closed;
            editWindow.Show();
        }

        private void EditWindow_Closed(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            dgrTags.ItemsSource = new List<string>();
            ShowMonuments.DoSelectQuery(dgrTags, "Tag");
        }
        
        private void Cancel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Perform deleting selected monument types
            PerformDeleteCheck();
        }

        private void DeleteMonumentType(DataRowView dataRowView)
        {
            DataRow dataRow = dataRowView.Row as DataRow;

            MainWindow.connection.Open();

            string delete = "DELETE FROM Tag WHERE ID=@id";
            SqlCommand command = new SqlCommand(delete, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", dataRow["ID"] as string));
            command.ExecuteNonQuery();

            MainWindow.connection.Close();
        }

        private void DgrTags_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                PerformDeleteCheck();
            }
        }

        private void PerformDeleteCheck()
        {
            if (dgrTags.SelectedItems != null && MessageBox.Show("Are you sure you want to delete picked tag(s)?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var item in dgrTags.SelectedItems)
                {
                    DeleteMonumentType(item as DataRowView);
                }
                RefreshDataGrid();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addTagWindow = new AddTag();
            addTagWindow.Closed += AddTagWindow_Closed;
            addTagWindow.Show();
        }

        private void AddTagWindow_Closed(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
