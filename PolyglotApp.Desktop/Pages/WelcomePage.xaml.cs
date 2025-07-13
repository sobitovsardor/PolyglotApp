using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class WelcomePage : Page
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private void StartLearning_Click(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new DictionaryPage());
    }
}

