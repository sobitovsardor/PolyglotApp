using PolyglotApp.Desktop.Pages;
using System.Windows;

namespace PolyglotApp.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartLearning_Click(object sender, RoutedEventArgs e)
    {
        // Hide welcome card
        WelcomeCard.Visibility = Visibility.Collapsed;

        // Show main frame and navigate
        MainFrame.Visibility = Visibility.Visible;
        MainFrame.Navigate(new DictionarySectionPage());
    }

    private void CloseApp_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}


