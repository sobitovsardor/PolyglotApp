using PolyglotApp.Desktop.ViewModels.Test;
using PolyglotApp.Service.Interface;
using PolyglotApp.Service.Interface.Test;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class TestUnitPage : Page
{
    private readonly string _sectionTitle;
    private readonly ITestService _testService;
    private readonly IDictionaryService _dictionaryService;

    public TestUnitPage(string sectionTitle)
    {
        InitializeComponent();
        _sectionTitle = sectionTitle;
        _dictionaryService = App.GetService<IDictionaryService>();
        _testService = App.GetService<ITestService>();

        DataContext = new TestUnitViewModel(_sectionTitle, _dictionaryService, _testService);
    }

    private void UnitButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string unitTitle)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new TestConfigurationPage(_sectionTitle, unitTitle));
        }
    }

    private async void ResetSectionResults_Click(object sender, RoutedEventArgs e)
    {
        var confirm = MessageBox.Show(
            $"Are you sure you want to delete ALL test results for section '{_sectionTitle}'?",
            "Confirm Reset",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.Yes)
        {
            await _testService.DeleteResultsForSectionAsync(_sectionTitle);

            MessageBox.Show("Section results deleted successfully.",
                "Success",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            DataContext = new TestUnitViewModel(_sectionTitle, _dictionaryService, _testService);
        }
    }
    
    private void BackToHome_Click(object sender, RoutedEventArgs e)
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
                BackToHome_Click(sender, e);
            }
        }
    }

}

