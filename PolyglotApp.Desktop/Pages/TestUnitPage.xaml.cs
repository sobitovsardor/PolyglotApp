using PolyglotApp.Desktop.ViewModels.Test;
using PolyglotApp.Service.Interface;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class TestUnitPage : Page
{
    private readonly string _sectionTitle;

    public TestUnitPage(string sectionTitle)
    {
        InitializeComponent();
        _sectionTitle = sectionTitle;
        DataContext = new TestUnitViewModel(App.GetService<IDictionaryService>(), sectionTitle);
    }

    private void UnitButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string unitTitle)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new TestConfigurationPage(_sectionTitle, unitTitle));
        }
    }
}

