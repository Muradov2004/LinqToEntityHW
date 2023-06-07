using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LinqToEntityHW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (LibraryContext database = new())
            {
                ComboBoxItem? selectedItem = ComboBox1.SelectedItem as ComboBoxItem;

                if (selectedItem!.Content.ToString() == "Authors")
                {
                    ComboBox2.Items.Clear();

                    var authors = database.Authors;
                    
                    authors.ToList().ForEach(a => ComboBox2.Items.Add($"{a.FirstName} {a.LastName}"));
                }
                else if (selectedItem!.Content.ToString() == "Themes")
                {
                    ComboBox2.Items.Clear();
                    
                    var themes = database.Themes;
                    
                    themes.ToList().ForEach(t => ComboBox2.Items.Add($"{t.Name}"));
                }
                else if (selectedItem!.Content.ToString() == "Categories")
                {
                    ComboBox2.Items.Clear();
                    
                    var categories = database.Categories;
                    
                    categories.ToList().ForEach(c => ComboBox2.Items.Add($"{c.Name}"));
                }
            }
        }
    }
}
