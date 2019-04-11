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
    /// Interaction logic for ShowMonumentTypes.xaml
    /// </summary>
    public partial class ShowMonumentTypes : Window
    {
        private DependencyObject dep;

        private MainWindow mainWindow;

        public ShowMonumentTypes()
        {
            InitializeComponent();
            this.DataContext = this;
            
            dgrMonumentTypes.MouseDoubleClick += DgrMonumentTypes_MouseDoubleClick;
            dgrMonumentTypes.ContextMenuOpening += DgrMonumentTypes_ContextMenuOpening;
            dgrMonumentTypes.PreviewKeyDown += DgrMonumentTypes_PreviewKeyDown;

            ShowMonuments.DoSelectQuery(dgrMonumentTypes, "MonumentType");

            this.mainWindow = Application.Current.MainWindow as MainWindow;
            helpCommand.Executed += this.mainWindow.Help_Executed;
        }
        
        private void DgrMonumentTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
            if (dgrMonumentTypes.SelectedItems != null)
            {
                EditExecute(dgrMonumentTypes.SelectedItem as DataRowView);
            }
        }

        private void DgrMonumentTypes_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridRow))
                dep = VisualTreeHelper.GetParent(dep);

            if (dep == null) return;
        }

        private void EditExecute(DataRowView dataRowView)
        {
            DataRow dataRow = dataRowView.Row as DataRow;

            System.Drawing.Image img = null;
            if (dataRow["Icon"] as Byte[] != null)
            {
                using (var ms = new MemoryStream(dataRow["Icon"] as Byte[]))
                {
                    img = System.Drawing.Image.FromStream(ms);
                }
            }

            MonumentType monumentType = new MonumentType(dataRow["ID"] as string,
                                         dataRow["Name"] as string,
                                         dataRow["Description"] as string,
                                         img,
                                         dataRow["IconPath"] as string);

            var editWindow = new EditMonumentType(monumentType);
            editWindow.Closed += EditWindow_Closed;
            editWindow.Show();
        }

        private void EditWindow_Closed(object sender, EventArgs e)
        {
            RefreshDataGrid();
            mainWindow.FillMonumentsOnMap(); //Refresh display on the map
        }

        private void RefreshDataGrid()
        {
            dgrMonumentTypes.ItemsSource = new List<string>();
            ShowMonuments.DoSelectQuery(dgrMonumentTypes, "MonumentType");
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

            for (int i = MainWindow.Monuments.Count - 1; i >= 0; i--)
            {
                if (MainWindow.Monuments[i].Type.Equals(dataRow["ID"] as string))
                {
                    MainWindow.Monuments.RemoveAt(i);
                }
            }

            MainWindow.connection.Open();

            string delete = "DELETE FROM MonumentType WHERE ID=@id";
            SqlCommand command = new SqlCommand(delete, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", dataRow["ID"] as string));
            command.ExecuteNonQuery();

            Monument.types.Remove(dataRow["ID"] as string);

            MainWindow.connection.Close();


            mainWindow.FillMonumentsOnMap(); //Refresh display on the map
        }

        private void DgrMonumentTypes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                PerformDeleteCheck();
            }
        }

        private void PerformDeleteCheck()
        {
            if (dgrMonumentTypes.SelectedItems != null && MessageBox.Show("Are you sure you want to delete picked monument type(s)?\r\nAll monuments with these types will be deleted pernamently!", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var item in dgrMonumentTypes.SelectedItems)
                {
                    DeleteMonumentType(item as DataRowView);
                }
                RefreshDataGrid();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addMonumentTypeWindow = new AddMonumentType();
            addMonumentTypeWindow.Closed += AddMonumentTypeWindow_Closed;
            addMonumentTypeWindow.Show();
        }

        private void AddMonumentTypeWindow_Closed(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}