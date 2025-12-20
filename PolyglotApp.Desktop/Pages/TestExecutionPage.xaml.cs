using PolyglotApp.Desktop.ViewModels.Test;
using PolyglotApp.Domain.Entities.Enums;
using PolyglotApp.Service.Interface.Test;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class TestExecutionPage : Page
{
    private readonly TestExecutionViewModel _viewModel;

    public TestExecutionPage(string sectionTitle, string unitTitle, string fromLang, string toLang, Difficulty difficulty)
    {
        InitializeComponent();
        _viewModel = new TestExecutionViewModel(App.GetService<ITestService>(), sectionTitle, unitTitle, fromLang, toLang, difficulty);
        _viewModel.TestFinished += OnTestFinished;
        DataContext = _viewModel;
    }

    private void OptionButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Content is string answer)
        {
            _viewModel.SubmitAnswer(answer);
        }
    }

    private void OnTestFinished(PolyglotApp.Domain.Entities.Test.TestResult result)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new TestResultPage(result));
    }

    private void DictionaryPage_Click(object sender, RoutedEventArgs e)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;

        mainWindow?.MainFrame.Navigate(new DictionarySectionPage());
    }
}

