using PolyglotApp.Service.Interfaces;
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
}


