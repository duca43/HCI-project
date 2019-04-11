using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for PickTags.xaml
    /// </summary>
    public partial class PickTags : Window
    {
        Point startPoint = new Point();
        Point startPoint2 = new Point();

        public ObservableCollection<Tag> AllTags
        {
            get;
            set;
        }

        public ObservableCollection<Tag> PickedTags
        {
            get;
            set;
        }

        private Monument mnmt;

        public PickTags(Monument mnmt)
        {
            InitializeComponent();

            this.DataContext = this;

            this.mnmt = mnmt;
            
            AllTags = new ObservableCollection<Tag>();
            PickedTags = new ObservableCollection<Tag>();

            FillPickedTagsList();
            FillAllTagsList();

            listViewLeft.KeyDown += ListViewLeft_KeyDown;
            listViewRight.KeyDown += ListViewRight_KeyDown;

            helpCommand.Executed += ((MainWindow)Application.Current.MainWindow).Help_Executed;
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = MainWindow.FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null)
                    return;

                Tag tag = (Tag)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
                
                DataObject dragData = new DataObject("mf", tag);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("mf") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("mf"))
            {
                Tag tag = e.Data.GetData("mf") as Tag;
                if (TagsListContainsTag(PickedTags, tag))
                {
                    MessageBox.Show("This tag is already picked!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    PickedTags.Add(tag);
                    AllTags.Remove(tag);
                }
            }
        }

        private void ListView2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint2 = e.GetPosition(null);
        }

        private void ListView2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint2 - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem = MainWindow.FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem == null)
                    return;

                Tag tag = (Tag)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                DataObject dragData = new DataObject("mf2", tag);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void ListView2_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("mf2") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView2_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("mf2"))
            {
                Tag tag = e.Data.GetData("mf2") as Tag;
                if (TagsListContainsTag(AllTags, tag))
                {
                    MessageBox.Show("This tag is already here!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    AllTags.Add(tag);
                    PickedTags.Remove(tag);
                }
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            mnmt.tags = PickedTags;
            this.Close();
        }

        public void FillAllTagsList()
        {
            MainWindow.connection.Open();

            string select = "SELECT * FROM Tag";
            DataTable dataTable = new DataTable("Tag");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, MainWindow.connection);
            dataAdapter.Fill(dataTable);

            MainWindow.connection.Close();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(dataRow["ColorCode"] as string);
                Color color = Color.FromArgb(c.A, c.R, c.G, c.B);
                Tag tag = new Tag(dataRow["ID"] as string, dataRow["Description"] as string, color, dataRow["ColorCode"] as string);

                if (!TagsListContainsTag(PickedTags, tag))
                {
                    AllTags.Add(tag);
                }
            }
        }

        public void FillPickedTagsList()
        {
            if (mnmt.tags != null)
            {
                PickedTags = mnmt.tags;
            }
        }

        public bool TagsListContainsTag(ObservableCollection<Tag> tags, Tag tag)
        {
            foreach (Tag t in tags)
            {
                if (t.ID.Equals(tag.ID))
                {
                    return true;
                }
            }
            return false;
        }

        private void ToLeft_Click(object sender, RoutedEventArgs e)
        {
            MoveLeft();
        }

        private void ToRight_Click(object sender, RoutedEventArgs e)
        {
            MoveRight();
        }

        private void ListViewRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                MoveLeft();
            }
        }

        private void ListViewLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                MoveRight();
            }
        }

        private void MoveLeft()
        {
            if (listViewRight.SelectedItem != null)
            {
                AllTags.Add(listViewRight.SelectedItem as Tag);
                PickedTags.Remove(listViewRight.SelectedItem as Tag);
            }
        }

        private void MoveRight()
        {
            if (listViewLeft.SelectedItem != null)
            {
                PickedTags.Add(listViewLeft.SelectedItem as Tag);
                AllTags.Remove(listViewLeft.SelectedItem as Tag);
            }
        }
    }
}
