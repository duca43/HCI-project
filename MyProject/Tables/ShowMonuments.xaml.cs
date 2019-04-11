using MyProject.AddDialogs;
using MyProject.EditDialogs;
using MyProject.Entities;
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

namespace MyProject.Tables
{
    /// <summary>
    /// Interaction logic for ShowMonuments.xaml
    /// </summary>
    public partial class ShowMonuments : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public readonly string[] tableBtnContents = { "Expand table", "Collapse table" };

        public string _tableBtnContent;

        public String TableBtnContent
        {
            get
            {
                return _tableBtnContent;
            }
            set
            {
                if (value != _tableBtnContent)
                {
                    _tableBtnContent = value;
                    OnPropertyChanged("TableBtnContent");
                }
            }
        }

        private static bool collapsed;
        private DependencyObject dep;

        private Dictionary<string, ObservableCollection<Tag>> allTagDict;

        private ObservableCollection<Tag> _tags;

        public ObservableCollection<Tag> Tags
        {
            get
            {
                return _tags;
            }
            set
            {
                if (value != _tags)
                {
                    _tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }

        public static ObservableCollection<String> Climates
        {
            get;
            set;
        }
        public static ObservableCollection<String> TouristStatuses
        {
            get;
            set;
        }

        public ObservableCollection<string> Types
        {
            get;
            set;
        }
        public ObservableCollection<string> AllTags
        {
            get;
            set;
        }

        private MainWindow mainWindow;

        public ShowMonuments()
        {
            InitializeComponent();
            this.DataContext = this;

            TableColumnsCollapseOrExpand();
            
            this.allTagDict = new Dictionary<string, ObservableCollection<Tag>>();
            this.AllTags = new ObservableCollection<string>();

            SelectTags();
            FillAllTags();

            this.Tags = new ObservableCollection<Tag>();

            DoSelectQuery(dgrMonuments, "Monument");
            ChangeTags();

            this.mainWindow = Application.Current.MainWindow as MainWindow;

            Types = Monument.types;

            Climates = new ObservableCollection<string>(Monument.climates);
            TouristStatuses = new ObservableCollection<string>(Monument.touristStatuses);

            helpCommand.Executed += this.mainWindow.Help_Executed;
        }

        private void DgrMonuments_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ChangeTags();
        }

        private void ChangeTags()
        {
            if (dgrMonuments.SelectedItem != null)
            {
                DataRowView dataRowView = dgrMonuments.SelectedItem as DataRowView;
                DataRow row = dataRowView.Row;
                if (allTagDict.ContainsKey(row["ID"] as string))
                {
                    Tags = allTagDict[row["ID"] as string];
                }
                else
                {
                    Tags = new ObservableCollection<Tag>();
                }
            }
            else
            {
                Tags = new ObservableCollection<Tag>();
            }
        }

        public void FillAllTags()
        {
            MainWindow.connection.Open();
            string select = "SELECT Id FROM Tag";
            
            DataTable dataTable = new DataTable("Tag");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, MainWindow.connection);
            dataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                AllTags.Add(row["Id"] as string);
            }

            MainWindow.connection.Close();
        }

        private void ExpandOrCollapse_Click(object sender, RoutedEventArgs e)
        {
            TableColumnsCollapseOrExpand();
        }

        public void TableColumnsCollapseOrExpand()
        {
            if (!collapsed)
            {
                colClimate.Visibility = colDesc.Visibility = colDiscoveryDate.Visibility = colEE.Visibility = colHabitat.Visibility =
                colIncome.Visibility = colPR.Visibility = colTouristStatus.Visibility = Visibility.Collapsed;
                TableBtnContent = tableBtnContents[0];
                colIcon.Width = colID.Width = colName.Width = colType.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                collapsed = true;
            }
            else
            {
                colClimate.Visibility = colDesc.Visibility = colDiscoveryDate.Visibility = colEE.Visibility = colHabitat.Visibility =
                colIncome.Visibility = colPR.Visibility = colTouristStatus.Visibility = Visibility.Visible;
                TableBtnContent = tableBtnContents[1];
                colIcon.Width = colID.Width = colName.Width = colType.Width = new DataGridLength(1, DataGridLengthUnitType.Auto);
                collapsed = false;
            }
        }

        private void DgrMonuments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
            if (dep != null)
            {
                DataGridRow currentRow = dep as DataGridRow;
                EditExecute(currentRow.Item as DataRowView);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dgrMonuments.SelectedItems != null)
            {
                EditExecute(dgrMonuments.SelectedItem as DataRowView);
            }
        }

        private void DgrMonuments_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridRow))
                dep = VisualTreeHelper.GetParent(dep);
        }

        private void EditExecute(DataRowView dataRowView)
        {
            DataRow dataRow = dataRowView.Row as DataRow;

            System.Drawing.Image img = null;
            System.Windows.Controls.Image imagePreview = new System.Windows.Controls.Image();
            if (dataRow["Icon"] as Byte[] != null)
            {
                using (var ms = new MemoryStream(dataRow["Icon"] as Byte[]))
                {
                    img = System.Drawing.Image.FromStream(ms);
                }
            }

            Monument mnmt = new Monument(dataRow["ID"] as string,
                                         dataRow["Name"] as string,
                                         dataRow["Description"] as string,
                                         dataRow["Type"] as string,
                                         img,
                                         dataRow["Climate"] as string,
                                         (bool)dataRow["EcologicallyEndangered"],
                                         (bool)dataRow["Habitat"],
                                         (bool)dataRow["PopulatedRegion"],
                                         dataRow["TouristStatus"] as string,
                                         (double)dataRow["Income"],
                                         ((DateTime)dataRow["DiscoveryDate"]).ToShortDateString(),
                                         dataRow["IconPath"] as string,
                                         (bool)dataRow["IconTaken"]);

            MainWindow.connection.Open();

            string select = "SELECT * FROM Tag WHERE Id IN (SELECT TagID FROM MonumentTag WHERE MonID = @id)";
            SqlCommand command = new SqlCommand(select, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", mnmt.ID));

            DataTable dataTable = new DataTable("MonumentTag");
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                dataTable.Load(dataReader);
            }
            
            MainWindow.connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(row["ColorCode"] as string);
                System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
                Tag tag = new Tag(row["ID"] as string, row["Description"] as string, color, row["ColorCode"] as string);
                mnmt.tags.Add(tag);
            }


            var editWindow = new EditMonument(mnmt);

            editWindow.cbClimate.SelectedIndex = FindIndex(Monument.climates, mnmt.Climate);
            editWindow.cbTouristStatus.SelectedIndex = FindIndex(Monument.touristStatuses, mnmt.TouristStatus);
            editWindow.cbType.SelectedIndex = FindIndex(Monument.types.ToList(), mnmt.Type);

            editWindow.Closed += EditWindow_Closed;

            editWindow.ShowDialog();
        }

        private void EditWindow_Closed(object sender, EventArgs e)
        {
            allTagDict = new Dictionary<string, ObservableCollection<Tag>>();
            SelectTags();

            RefreshDataGrid();
            mainWindow.FillMonumentsOnMap(); //Refresh display of monuments on map
        }

        private void RefreshDataGrid()
        {
            MainWindow.connection.Open();
            string select = "SELECT * FROM Monument WHERE ID LIKE @id";
            SqlCommand command = new SqlCommand(select, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", tbSearch.Text.TrimStart() + "%"));

            DataTable dataTable = new DataTable("Monument");

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                dataTable.Load(dataReader);
            }
            
            dgrMonuments.ItemsSource = dataTable.DefaultView;

            MainWindow.connection.Close();

            ChangeTags();
        }

        public static int FindIndex(List<String> list, String item)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(item))
                    return i;
            }
            return -1; //if item is not in the given list
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
            //Perform deleting selected monuments
            PerformDeleteCheck();
        }
        private void DeleteMonument(string id)
        {
            MainWindow.connection.Open();

            string delete = "DELETE FROM Monument WHERE ID=@id";
            SqlCommand command = new SqlCommand(delete, MainWindow.connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            command.ExecuteNonQuery();

            MainWindow.connection.Close();

            for (int i = 0; i < MainWindow.Monuments.Count; i++)
            {
                if (MainWindow.Monuments[i].ID.Equals(id))
                {
                    MainWindow.Monuments.Remove(MainWindow.Monuments[i]);
                    break;
                }
            }

            mainWindow.FillMonumentsOnMap(); //Refresh display of monuments on map
            ChangeTags();
        }

        private void DgrMonuments_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                PerformDeleteCheck();
            }
        }

        private void PerformDeleteCheck()
        {
            if (dgrMonuments.SelectedItems != null && (MessageBox.Show("Are you sure you want to delete picked monument(s)?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                foreach (var item in dgrMonuments.SelectedItems)
                {
                    DataRowView dataRowView = item as DataRowView;
                    DataRow dataRow = dataRowView.Row as DataRow;
                    string id = dataRow["ID"] as string;
                    DeleteMonument(id);
                }
                RefreshDataGrid();
            }
        }

        public static void DoSelectQuery(DataGrid dataGrid, String table)
        {
            MainWindow.connection.Open();
            string select = string.Format("SELECT * FROM {0}", table);
            
            DataTable dataTable = new DataTable(table);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, MainWindow.connection);
            dataAdapter.Fill(dataTable);

            dataGrid.ItemsSource = dataTable.DefaultView;

            MainWindow.connection.Close();
        }

        public void SelectTags()
        {
            MainWindow.connection.Open();

            string select = "SELECT * FROM Tag, MonumentTag WHERE Id = TagID";
            SqlCommand command = new SqlCommand(select, MainWindow.connection);
            
            DataTable dataTable = new DataTable("MonumentTag");
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                dataTable.Load(dataReader);
            }

            MainWindow.connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                if (!allTagDict.ContainsKey(row["MonID"] as string))
                {
                    allTagDict.Add(row["MonID"] as string, new ObservableCollection<Tag>());
                }
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(row["ColorCode"] as string);
                System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
                Tag tag = new Tag(row["ID"] as string, row["Description"] as string, color, row["ColorCode"] as string);
                allTagDict[row["MonID"] as string].Add(tag);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addMonumentWindow = new AddMonument();
            addMonumentWindow.Closed += AddMonumentWindow_Closed;
            addMonumentWindow.Show();
        }

        private void AddMonumentWindow_Closed(object sender, EventArgs e)
        {
            allTagDict = new Dictionary<string, ObservableCollection<Tag>>();
            SelectTags();

            RefreshDataGrid();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            DoSelectQuery(dgrMonuments, "Monument");

            MainWindow.connection.Open();

            List<string> encodingList = new List<string>();

            foreach (string str in Types)
            {
                string encodedString = EncodeString(str);
                encodingList.Add(encodedString);
            }

            string types = "('" + string.Join("','", encodingList) + "')";
            string tags = "";
            string climates = "('" + string.Join("','", Climates) + "')";
            string touristStatus = "('" + string.Join("','", TouristStatuses) + "')";

            if (filterTypes.SelectedItems.Count > 0)
            {
                List<string> typesList = new List<string>();
                for (int i = 0; i < filterTypes.SelectedItems.Count; i++)
                {
                    string encodedString = EncodeString(filterTypes.SelectedItems[i] as string);
                    typesList.Add(encodedString);
                }
                types = "('" + string.Join("','", typesList) + "')";
            }
            if (filterTags.SelectedItems.Count > 0)
            {
                DataTable dataTable = new DataTable("Monument");
                foreach (var tag in filterTags.SelectedItems)
                {
                    string select = "SELECT ID FROM Monument WHERE ID IN (SELECT MonID FROM MonumentTag WHERE TagID = @tagId)";
                    SqlCommand command = new SqlCommand(select, MainWindow.connection);
                    command.Parameters.Add(new SqlParameter("@tagId", tag as string));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        dataTable.Load(dataReader);
                    }
                }
                List<string> tagsList = new List<string>();
                foreach (DataRow row in dataTable.Rows)
                {
                    string encodedString = EncodeString(row["ID"] as string);
                    tagsList.Add(encodedString);
                }
                tags = "('" + string.Join("','", tagsList) + "')";
            }
            if (filterClimates.SelectedItems.Count > 0)
            {
                List<string> climatesList = new List<string>();
                for (int i = 0; i < filterClimates.SelectedItems.Count; i++)
                {
                    climatesList.Add(filterClimates.SelectedItems[i] as string);
                }
                climates = "('" + string.Join("','", climatesList) + "')";
            }
            if (filterTouristStatus.SelectedItems.Count > 0)
            {

                List<string> touristStatusList = new List<string>();
                for (int i = 0; i < filterTouristStatus.SelectedItems.Count; i++)
                {
                    touristStatusList.Add(filterTouristStatus.SelectedItems[i] as string);
                }
                touristStatus = "('" + string.Join("','", touristStatusList) + "')";
            }

            MainWindow.connection.Close();

            string filter;
            if (string.IsNullOrWhiteSpace(tags))
            {
                filter = string.Format("Type IN {0} AND Climate IN {1} AND TouristStatus IN {2}", types, climates, touristStatus);
            }
            else
            {
                filter = string.Format("Type IN {0} AND ID IN {1} AND Climate IN {2} AND TouristStatus IN {3}", types, tags, climates, touristStatus);
            }
            
            (dgrMonuments.ItemsSource as DataView).RowFilter = filter;

            ChangeTags();
        }

        private string EncodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            filterTypes.SelectedItems.Clear();
            filterTags.SelectedItems.Clear();
            filterClimates.SelectedItems.Clear();
            filterTouristStatus.SelectedItems.Clear();
            DoSelectQuery(dgrMonuments, "Monument");
            ChangeTags();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            collapsed = !collapsed; //Because of calling TableColumnsCollapseOrExpand() method in constructor of this class --> to be able to show up table in right state every time this window is opened
        }
    }
}