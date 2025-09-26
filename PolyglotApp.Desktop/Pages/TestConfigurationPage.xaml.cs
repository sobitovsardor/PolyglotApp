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
}

