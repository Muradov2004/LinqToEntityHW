using System.Collections.ObjectModel;
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
        ObservableCollection<Book> books;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            using (LibraryContext database = new())
            {
                ComboBoxItem? selectedItem = ComboBox1.SelectedItem as ComboBoxItem;

                books.Clear();

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

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (LibraryContext database = new())
            {
                ComboBoxItem? selectedItem = ComboBox1.SelectedItem as ComboBoxItem;


                if (selectedItem!.Content.ToString() == "Authors")
                {
                    books.Clear();

                    var choosenBooks = database.Books
                        .Join(
                        database.Authors,
                        b => b.IdAuthor,
                        a => a.Id,
                        (b,a) =>
                        new Book()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Pages = b.Pages,
                            YearPress = b.Pages,
                            IdThemes = b.IdThemes,
                            IdCategory = b.IdCategory,
                            IdAuthor = b.IdAuthor,
                            IdPress = b.IdPress,
                            Comment = b.Comment,
                            Quantity = b.Quantity
                        })
                         .ToList();

                    choosenBooks.ForEach(b => books.Add(b));

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
