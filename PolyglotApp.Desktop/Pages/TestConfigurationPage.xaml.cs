using PolyglotApp.Desktop.ViewModels.Test;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class TestConfigurationPage : Page
{
    private readonly TestConfigurationViewModel _viewModel;

    public TestConfigurationPage(string sectionTitle, string unitTitle)
    {
        InitializeComponent();
        _viewModel = new TestConfigurationViewModel(sectionTitle, unitTitle);
        DataContext = _viewModel;
    }

    private void StartTest_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        if (mainWindow != null)
        {
            mainWindow.MainFrame.Navigate(new TestExecutionPage(
                _viewModel.SectionTitle,
                _viewModel.UnitTitle,
                _viewModel.FromLanguage,
                _viewModel.ToLanguage,
                _viewModel.Difficulty));
        }
    }


    private void HomeButton_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;

        if (mainWindow != null)
        {
            // MainFrame ni yashirish va asosiy contentni ko'rsatish
            mainWindow.MainFrame.Visibility = Visibility.Collapsed;
            mainWindow.BackButton.Visibility = Visibility.Collapsed;

            // Agar MainWindow'da MainContentGrid yoki boshqa Grid bor bo'lsa
            // mainWindow.MainContentGrid.Visibility = Visibility.Visible;
        }
    }

    private void GamePage_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;

        if (mainWindow != null)
        {
            // Game page'ga navigate qilish
            // mainWindow.MainFrame.Navigate(new GamePage());

            // Yoki NavigationService orqali:
            NavigationService?.Navigate(new Uri("Pages/GamePage.xaml", UriKind.Relative));
        }
    }

    private void DictionaryPage_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;

        if (mainWindow != null)
        {
            // DictionaryPage'ga navigate qilish
            try
            {
                // Agar DictionaryPage mavjud bo'lsa:
                // mainWindow.MainFrame.Navigate(new DictionaryPage());

                // Yoki NavigationService orqali:
                NavigationService?.Navigate(new Uri("Pages/DictionaryPage.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                // Agar DictionaryPage mavjud bo'lmasa, boshqa page'ga yo'naltiring
                // yoki xato xabarini ko'rsating
                MessageBox.Show($"Dictionary page not found: {ex.Message}", "Navigation Error",
                               MessageBoxButton.OK, MessageBoxImage.Warning);

                // Asosiy sahifaga qaytish
                DictionaryPage_Click(sender, e);
            }
        }
    }
}

