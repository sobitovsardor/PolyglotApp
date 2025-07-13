using PolyglotApp.Desktop.Pages;
using System.Windows;

namespace PolyglotApp.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new WelcomePage());
        }

        private void WelcomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WelcomePage());
        }

        private void DictionaryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DictionaryPage());
        }

        private void GamesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GamesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
