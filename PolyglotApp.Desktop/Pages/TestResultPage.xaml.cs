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
}

