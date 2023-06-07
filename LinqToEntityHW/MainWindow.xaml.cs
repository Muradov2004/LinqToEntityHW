using System.Windows;

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
            if (ComboBox1.SelectedItem == "Authors")
            {

            }
        }
    }
}
