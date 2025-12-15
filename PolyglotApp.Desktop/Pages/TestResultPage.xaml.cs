using PolyglotApp.Desktop.ViewModels.Test;
using PolyglotApp.Domain.Entities.Test;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class TestResultPage : Page
{
    private readonly string _sectionTitle;
    private readonly string _unitTitle;

    public TestResultPage(TestResult result)
    {
        InitializeComponent();
        _sectionTitle = result.SectionTitle;
        _unitTitle = result.UnitTitle;
        DataContext = new TestResultViewModel(result);
    }

    private void BackToUnits_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new TestUnitPage(_sectionTitle));
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

