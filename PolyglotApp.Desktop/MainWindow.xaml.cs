using PolyglotApp.Desktop.Pages;
using System.Windows;

namespace PolyglotApp.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Dastlabki sahifa: DictionarySectionPage
        MainFrame.Navigate(new DictionarySectionPage());
    }
}

