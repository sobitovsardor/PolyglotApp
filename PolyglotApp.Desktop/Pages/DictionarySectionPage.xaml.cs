using PolyglotApp.Service.Interface;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class DictionarySectionPage : Page
{
    public DictionarySectionPage()
    {
        InitializeComponent();
        DataContext = new SectionSelectionViewModel(App.GetService<IDictionaryService>());
    }

    private void SectionButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string sectionTitle)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new DictionaryUnitPage(sectionTitle));
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
}


