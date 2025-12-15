using PolyglotApp.Desktop.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PolyglotApp.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DictionaryPage_Click(object sender, RoutedEventArgs e)
    {
        try 
        { 
            NavigateToPage(new DictionarySectionPage()); 
        }
        catch (System.Exception ex)
        {
            MessageBox.Show("Lug'at sahifasini yuklashda xatolik yuz berdi: " + ex.Message);
        }
        
    }

    private void GamePage_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Game sahifasi tayyor bo'lganda bu yerda kerakli page ni chaqiring
            NavigateToPage(new TestSectionPage());

        }
        catch (System.Exception ex)
        {
            MessageBox.Show("O'yin sahifasini yuklashda xatolik yuz berdi: " + ex.Message);
        }
    }

    private void NavigateToPage(Page page)
    {
        MainFrame.Visibility = Visibility.Visible;
        BackButton.Visibility = Visibility.Visible;
        MainFrame.Navigate(page);
    }

    private void BackToHome_Click(object sender, RoutedEventArgs e)
    {

        MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

        if (mainWindow != null)
        {
            // MainWindow ni ko'rsatish
            mainWindow.Show();

        }
    }

    private void PreviousButton_Click(object sender, RoutedEventArgs e)
    {
        // Previous slide logic
    }

    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        // Next slide logic
    }
}
