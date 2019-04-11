using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using MyProject.AddDialogs;
using MyProject.Commands;
using MyProject.EditDialogs;
using MyProject.Entities;
using MyProject.Help;
using MyProject.Other;
using MyProject.Tables;
namespace MyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static SqlConnection connection;

        public static ObservableCollection<Monument> Monuments
        {
            get;
            set;
        }

        private Point startPoint = new Point();

        private static Dictionary<Monument, Point> MonumentsOnMap;

        private Image deletingImageFromMap;

        private bool _tutorialMode = true;

        public bool TutorialMode
        {
            get
            {
                return _tutorialMode;
            }
            set
            {
                if (value != _tutorialMode)
                {
                    _tutorialMode = value;
                    OnPropertyChanged("TutorialMode");
                }
            }
        }

        public Tutorial tutorialWindow;

        private DependencyObject dep;

        private Image draggedImage = null;
        private Cursor customCursor = null;

        public MainWindow()
        {
            InitializeComponent();
        
            connection = new SqlConnection(Properties.Settings.Default.MonumentsDatabaseConnectionString);
            Monument.types = new ObservableCollection<string>();
            Monuments = new ObservableCollection<Monument>();
            MonumentsOnMap = new Dictionary<Monument, Point>();

            this.DataContext = this;

            FillTypesList();
            FillCollections();
            FillMonumentsOnMap();

            ZoomSlider.ValueChanged += ZoomSlider_ValueChanged;

            //***To trigger scrollbar, whatever*** 
            ZoomSlider.Value = 1.01;
            ZoomSlider.Value = 1;
        }

        public void FillMonumentsOnMap()
        {
            RemoveAllMonumentsFromMap();
            MonumentsOnMap.Clear();

            connection.Open();

            string select = string.Format("SELECT * FROM MonumentsOnMap");
            SqlCommand command = new SqlCommand(select, connection);
            
            DataTable dataTableMonuments = new DataTable("MonumentsOnMap");
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                dataTableMonuments.Load(dataReader);
            }
            
            connection.Close();

            foreach (DataRow dataRow in dataTableMonuments.Rows)
            {
                Monument monument = null;
                foreach (Monument m in Monuments)
                {
                    if (m.ID.Equals(dataRow["ID"] as string))
                    {
                        monument = m;
                        break;
                    }
                }
                if (monument != null)
                {
                    Point point = new Point((double)dataRow["XCoordinate"], (double)dataRow["YCoordinate"]);
                    PutMonumentOnMap(monument, point);
                }
            }
        }

        private void MonumentType_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void MonumentType_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddMonumentTypeExec();
        }

        private void AddMonumentTypeExec()
        {

            var addMonumentTypeWindow = new AddMonumentType();
            addMonumentTypeWindow.Owner = this;

            if (TutorialMode)
            {
                addMonumentTypeWindow.ShowDialog();
            }
            else
            {
                tutorialWindow.Navigate("tutorialOpenDialogPage.htm");
                addMonumentTypeWindow.Show();
                addMonumentTypeWindow.Top = this.Top + (this.Height - addMonumentTypeWindow.Height) / 2;
                addMonumentTypeWindow.Left = this.Left;
            }
        }

        private void Monument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TutorialMode;
        }

        private void Monument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!IsTableEmpty("MonumentType"))
            {
                var addMonumentWindow = new AddMonument();
                addMonumentWindow.ShowDialog();
            }
            else
            {
                MessageBoxResult boxResult = MessageBox.Show("Can't add monument without previously adding monument type!\r\nDo you want to add new type now?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (boxResult == MessageBoxResult.Yes)
                    AddMonumentTypeExec();
            }
        }

        private void Tag_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TutorialMode;
        }

        private void Tag_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var addTagWindow = new AddTag();
            addTagWindow.ShowDialog();
        }

        private void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowMonuments_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TutorialMode;
        }

        private void ShowMonuments_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //If there are no any monument -> don't show up a new dialog with table
            if (IsTableEmpty("Monument"))
            {
                MessageBox.Show("There is no any monument!", "Show monuments", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var showMonumentsWindow = new ShowMonuments();
                showMonumentsWindow.ShowDialog();
            }
        }

        private void ShowMonumentTypes_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TutorialMode;
        }

        private void ShowMonumentTypes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (IsTableEmpty("MonumentType"))
            {
                MessageBox.Show("There is no any monument type!", "Show monument types", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var showMonumentTypesWindow = new ShowMonumentTypes();
                showMonumentTypesWindow.ShowDialog();
            }
        }

        private void ShowTags_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TutorialMode;
        }

        private void ShowTags_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (IsTableEmpty("Tag"))
            {
                MessageBox.Show("There is no any tag!", "Show tags", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var showTagsWindow = new ShowTags();
                showTagsWindow.ShowDialog();
            }
        }

        public bool IsTableEmpty(String table)
        {
            try
            {
                connection.Open();
                string select = string.Format("SELECT COUNT(*) FROM {0}", table);
                SqlCommand cmd = new SqlCommand(select, connection);
                int res = int.Parse(cmd.ExecuteScalar().ToString());
                return (res == 0) ? true : false;
            }
            catch
            {
                return true;
            }
            finally
            {
                connection.Close();
            }
        }
        public void FillTypesList()
        {
            connection.Open();

            string select = "SELECT ID FROM MonumentType";
            SqlCommand cmd = new SqlCommand(select, connection);

            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Monument.types.Add(dataReader[0] as string);
                }
            }

            connection.Close();
        }

        public void FillCollections()
        {
            connection.Open();

            string select = "SELECT * FROM Monument";
            SqlCommand command = new SqlCommand(select, connection);
            
            DataTable dataTableMonuments = new DataTable("Monument");
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                dataTableMonuments.Load(dataReader);
            }
            
            foreach (DataRow dataRow in dataTableMonuments.Rows)
            {
                System.Drawing.Image img = null;
                Image imagePreview = new Image();
                using (var ms = new MemoryStream(dataRow["Icon"] as Byte[]))
                {
                    img = System.Drawing.Image.FromStream(ms);
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
                Monuments.Add(mnmt);
            }

            connection.Close();
        }

        private void MonumentsTreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.startPoint = e.GetPosition(null);
        }

        private void MonumentsTreeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (!TutorialMode)
            {
                e.Handled = true;
                return;
            }
            Point currentPoint = e.GetPosition(null);
            Vector distance = startPoint - currentPoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(distance.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(distance.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);
                
                if (listViewItem == null)
                    return;
                
                Monument monument = (Monument)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                draggedImage = new Image();
                draggedImage.Source = new BitmapImage(new Uri(monument.ImagePreview));
                draggedImage.MaxHeight = 36 * ZoomSlider.Value;
                draggedImage.MaxWidth = 36 * ZoomSlider.Value;

                DataObject dragData = new DataObject("customFormat", monument);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy);
            }
        }

        private void MonumentsView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effects == DragDropEffects.Copy || e.Effects == DragDropEffects.Move && draggedImage != null)
            {
                customCursor = CursorHelper.CreateCursor(draggedImage);

                if (customCursor != null)
                {
                    e.UseDefaultCursors = false;
                    Mouse.SetCursor(customCursor);
                }
            }
            else
            {
                e.UseDefaultCursors = true;
            }
            
            e.Handled = true;
        }

        public static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void Map_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("customFormat"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Map_Drop(object sender, DragEventArgs e)
        {
            Point dropPoint = e.GetPosition(mapCanvas);

            if (dropPoint.X + 14 > Map.Width || dropPoint.Y + 14 > Map.Height || dropPoint.X < 0 || dropPoint.Y < 0)
            {
                MessageBox.Show("Too out of bounds!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (e.Data.GetDataPresent("customFormat"))
            {
                Monument monument = e.Data.GetData("customFormat") as Monument;
                if (MonumentsOnMap.ContainsKey(monument))
                {
                    MessageBox.Show("This monument is already on the map!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    PutMonumentOnMap(monument, dropPoint);
                    InsertMonumentOnMap(monument, dropPoint);
                }
            }
            else if (e.Data.GetDataPresent("customFormatMap"))
            {
                Monument monument = e.Data.GetData("customFormatMap") as Monument;
                foreach (KeyValuePair<Monument, Point> monumentOnMap in MonumentsOnMap)
                {
                    if (monumentOnMap.Key.ID == monument.ID)
                    {
                        foreach (UIElement ui in mapCanvas.Children)
                        {
                            if (ui.GetType() == typeof(Border))
                            {
                                Border b = ui as Border;
                                DockPanel dockPanel = b.Child as DockPanel;
                                Image img = dockPanel.Children[0] as Image;
                                string imgSource = (img.Source.ToString().Trim("file:///".ToCharArray())).Replace("/", "\\");
                                if (imgSource.Equals(monumentOnMap.Key.ImagePreview))
                                {
                                    b.Margin = new Thickness(dropPoint.X - 14, dropPoint.Y - 14, 0, 0);
                                    dockPanel.AllowDrop = false;
                                    dockPanel.Drop -= Map_Drop;
                                    break;
                                }
                            }
                        }
                        MonumentsOnMap[monumentOnMap.Key] = dropPoint;
                        UpdateMonumentOnMap(monumentOnMap.Key, dropPoint);
                        FillMonumentsOnMap();
                        break;
                    }
                }
            }
        }

        public void PutMonumentOnMap(Monument monument, Point point)
        {
            

            Border b = new Border();
            DockPanel dockPanel = new DockPanel();
            
            b.Width = b.Height = 42;
            b.Margin = new Thickness(point.X - 14, point.Y - 14, 0, 0);

            Image image = new Image();
            try
            {
                image.Source = new BitmapImage(new Uri(monument.ImagePreview));
            }
            catch(Exception)
            {
                MessageBox.Show(this, "Couldn't load an image on path\r\n" + monument.ImagePreview, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            image.MaxHeight = image.MaxWidth = 28;


            MonumentsOnMap.Add(monument, point);

            b.Child = dockPanel;
            dockPanel.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            dockPanel.Children.Add(image);
            image.HorizontalAlignment = HorizontalAlignment.Right;
            image.VerticalAlignment = VerticalAlignment.Bottom;

            image.PreviewMouseDown += MonumentsTreeView_PreviewMouseLeftButtonDown;
            image.MouseMove += Image_MouseMove;

            ContextMenu contextMenu = new ContextMenu();
            MenuItem removeItem = new MenuItem();
            removeItem.Header = "_Remove";
            removeItem.Click += RemoveItem_Click;
            contextMenu.Items.Add(removeItem);
            image.ContextMenu = contextMenu;
            image.ContextMenuOpening += Image_ContextMenuOpening;
            
            image.ToolTip = "ID:\t" + monument.ID + "\r\n" +
                            "Name:\t" + monument.Name + "\r\n" +
                            "Type:\t" + monument.Type; ;

            mapCanvas.Children.Add(b);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (UIElement ui in mapCanvas.Children)
            {
                if (ui.GetType() == typeof(Border))
                {
                    Border b = ui as Border;
                    DockPanel dockPanel = b.Child as DockPanel;
                    dockPanel.AllowDrop = false;
                    dockPanel.Drop -= Map_Drop;
                }
            }
            Point currentPoint = e.GetPosition(null);
            Vector distance = startPoint - currentPoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(distance.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(distance.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image image = FindAncestor<Image>((DependencyObject)e.OriginalSource);
                if (image == null)
                    return;

                Monument mnmt = null;
                DockPanel dockPanelMnmt = null;
                foreach (KeyValuePair<Monument, Point> monumentOnMap in MonumentsOnMap)
                {
                    Rect s = new Rect(monumentOnMap.Value.X, monumentOnMap.Value.Y, 28, 28);
                    if (s.Contains(e.GetPosition(mapCanvas)))
                    {
                        foreach (UIElement ui in mapCanvas.Children)
                        {
                            if (ui.GetType() == typeof(Border))
                            {
                                Border b = ui as Border;
                                DockPanel dockPanel = b.Child as DockPanel;
                                Image img = dockPanel.Children[0] as Image;
                                string imgSource = (img.Source.ToString().Trim("file:///".ToCharArray())).Replace("/", "\\");
                                if (imgSource.Equals(monumentOnMap.Key.ImagePreview))
                                {
                                    mnmt = monumentOnMap.Key;
                                    dockPanelMnmt = dockPanel;
                                }
                            }
                        }
                    }
                }

                if (mnmt == null || image == null)
                {
                    return;
                }
                bool flag = true;
                foreach (KeyValuePair<Monument, Point> monumentOnMap in MonumentsOnMap)
                {
                    Rect monumentRect = new Rect(monumentOnMap.Value.X, monumentOnMap.Value.Y, 28, 28);
                    Rect draggedMonumentRect = new Rect(e.GetPosition(mapCanvas).X - 14, e.GetPosition(mapCanvas).Y - 14, 42, 42);
                    if (!monumentOnMap.Key.ID.Equals(mnmt.ID) && monumentRect.IntersectsWith(draggedMonumentRect))
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    dockPanelMnmt.AllowDrop = true;
                    dockPanelMnmt.Drop += Map_Drop;
                }

                draggedImage = new Image();
                draggedImage.Source = new BitmapImage(new Uri(mnmt.ImagePreview));
                draggedImage.MaxHeight = 36 * ZoomSlider.Value;
                draggedImage.MaxWidth = 36 * ZoomSlider.Value;

                DataObject dragData = new DataObject("customFormatMap", mnmt);
                DragDrop.DoDragDrop(image, dragData, DragDropEffects.Move);
            }
        }

        public void InsertMonumentOnMap(Monument monument, Point point)
        {
            connection.Open();

            string insert = "INSERT INTO MonumentsOnMap (ID,XCoordinate,YCoordinate) VALUES (@id,@x,@y)";
            SqlCommand command = new SqlCommand(insert, connection);
            command.Parameters.Add(new SqlParameter("@id", monument.ID));
            command.Parameters.Add(new SqlParameter("@x", point.X));
            command.Parameters.Add(new SqlParameter("@y", point.Y));
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateMonumentOnMap(Monument monument, Point point)
        {
            connection.Open();

            string insert = "UPDATE MonumentsOnMap SET XCoordinate = @x, YCoordinate = @y WHERE ID = @id";
            SqlCommand command = new SqlCommand(insert, connection);
            command.Parameters.Add(new SqlParameter("@id", monument.ID));
            command.Parameters.Add(new SqlParameter("@x", point.X));
            command.Parameters.Add(new SqlParameter("@y", point.Y));
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void DeleteMonumentOnMap(Monument monument)
        {
            connection.Open();

            string insert = "DELETE FROM MonumentsOnMap WHERE ID = @id";
            SqlCommand command = new SqlCommand(insert, connection);
            command.Parameters.Add(new SqlParameter("@id", monument.ID));
            command.ExecuteNonQuery();

            connection.Close();
        }

        private void Image_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            deletingImageFromMap = sender as Image;
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (deletingImageFromMap != null)
            {
                foreach (var monumentOnMap in MonumentsOnMap)
                {
                    string imgSource = (deletingImageFromMap.Source.ToString().Trim("file:///".ToCharArray())).Replace("/", "\\");
                    if (imgSource.Equals(monumentOnMap.Key.ImagePreview))
                    {
                        MonumentsOnMap.Remove(monumentOnMap.Key);
                        DeleteMonumentOnMap(monumentOnMap.Key);
                        break;
                    }
                }
                FillMonumentsOnMap();
            }
        }

        public void RemoveAllMonumentsFromMap()
        {
            mapCanvas.Children.RemoveRange(1, mapCanvas.Children.Count - 1);
        }

        private void RemoveAllMonumentsFromMap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (var item in MonumentsOnMap)
            {
                DeleteMonumentOnMap(item.Key);
            }

            RemoveAllMonumentsFromMap();
            MonumentsOnMap.Clear();
        }

        private void RemoveAllMonumentsFromMap_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TutorialMode;
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mapCanvas.Height = Map.Height;
            mapCanvas.Width = Map.Width;

            if (e.OldValue < e.NewValue)
            {
                mapCanvas.Height *= e.NewValue;
                mapCanvas.Width *= e.NewValue;
            }
            else
            {
                mapCanvas.Height *= e.OldValue;
                mapCanvas.Width *= e.OldValue;
                mapCanvas.Height /= (e.OldValue - e.NewValue) + 1;
                mapCanvas.Width /= (e.OldValue - e.NewValue) + 1;
            }
        }

        private void Tutorial_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tutorial_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (TutorialMode)
            {
                TutorialMode = false;
                tutorialWindow = new Tutorial(this);
                tutorialWindow.Closed += TutorialWindow_Closed;
                tutorialWindow.Show();
            }
            else
            {
                TutorialMode = true;
                if (tutorialWindow.IsEnabled)
                {
                    tutorialWindow.Close();
                }
            }
        }

        private void TutorialWindow_Closed(object sender, EventArgs e)
        {
            TutorialMode = true;
            tutorialItem.IsChecked = false;

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(AddMonumentType))
                {
                    try
                    {
                        window.Close();
                        break;
                    }
                    catch { }
                }
            }
            this.Focus();
        }

        public void CheckIsTutorialFollowed()
        {
            foreach(Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(AddMonumentType))
                {
                    tutorialWindow.Navigate("tutorialOpenDialogPage.htm");
                    return;
                }
            }

            FollowInstructionsMessage();
        }

        public static void FollowInstructionsMessage()
        {
            MessageBox.Show("Please follow tutorial instructions!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive); //get active window 
            IInputElement focusedControl = FocusManager.GetFocusedElement(currentWindow); //get focused element on active window
            if (focusedControl is DependencyObject)
            {
                string helpKey = FindHelpKey((DependencyObject)focusedControl); //looking for help key all the way up in Visual Tree 
                HelpProvider.ShowHelp(helpKey);
            }
            else
            {
                HelpProvider.ShowHelp("helpMainPage");
            }
        }

        public static string FindHelpKey(DependencyObject current)
        {
            //go up through visual tree to find first help key
            do
            {
                if (!HelpProvider.GetHelpKey(current).Equals("_DefaultValue"))
                {
                    return HelpProvider.GetHelpKey(current);
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return "index"; //if help key is not found, return default page
        }

        private void MonumentsView_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (!TutorialMode)
            {
                e.Handled = true;
                return;
            }
            dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
                dep = VisualTreeHelper.GetParent(dep);
        }

        private void MonumentsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!TutorialMode)
            {
                e.Handled = true;
                return;
            }
            dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
                dep = VisualTreeHelper.GetParent(dep);

            if (dep == null) return;

            ListViewItem item = dep as ListViewItem;
            Monument selectedMonument = item.Content as Monument;

            EditExecute(selectedMonument);
        }

        private void EditExecute(Monument monument)
        {
            Monument editMonument = new Monument(monument.ID,
                                                 monument.Name,
                                                 monument.Description,
                                                 monument.Type,
                                                 monument.Image,
                                                 monument.Climate,
                                                 monument.EcologicallyEndangered,
                                                 monument.Habitat,
                                                 monument.PopulatedRegion,
                                                 monument.TouristStatus,
                                                 monument.Income,
                                                 monument.DiscoveryDate,
                                                 monument.ImagePreview,
                                                 monument.IconTaken);

            var editWindow = new EditMonument(editMonument);
            
            editWindow.cbClimate.SelectedIndex = ShowMonuments.FindIndex(Monument.climates, editMonument.Climate);
            editWindow.cbTouristStatus.SelectedIndex = ShowMonuments.FindIndex(Monument.touristStatuses, editMonument.TouristStatus);
            editWindow.cbType.SelectedIndex = ShowMonuments.FindIndex(Monument.types.ToList(), editMonument.Type);

            editWindow.Closed += EditWindow_Closed;

            editWindow.ShowDialog();
        }

        private void EditWindow_Closed(object sender, EventArgs e)
        {
            FillMonumentsOnMap(); //Refresh display of monuments on map
        }

        private void PerformDeleteCheck()
        {
            if (MonumentsView.SelectedItems != null && (MessageBox.Show("Are you sure you want to delete picked monument(s)?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                connection.Open();

                List<Monument> list = new List<Monument>();
                foreach(var item in MonumentsView.SelectedItems)
                {
                    list.Add(item as Monument);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    string id = (list[i] as Monument).ID;
                    
                    string delete = "DELETE FROM Monument WHERE ID=@id";
                    SqlCommand command = new SqlCommand(delete, connection);
                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.ExecuteNonQuery();
                    
                    for (int j = 0; j < Monuments.Count; j++)
                    {
                        if (Monuments[j].ID.Equals(id))
                        {
                            Monuments.RemoveAt(j);
                            break;
                        }
                    }

                }
                connection.Close();

                FillMonumentsOnMap(); //Refresh display of monuments on map
            }
        }

        private void EditMonument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            EditExecute(MonumentsView.SelectedItem as Monument);
        }
        private void EditMonument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (MonumentsView.SelectedItem != null) && TutorialMode;
        }

        private void DeleteMonument_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PerformDeleteCheck();
        }

        private void DeleteMonument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (MonumentsView.SelectedItem != null) && TutorialMode;
        }
    }
}