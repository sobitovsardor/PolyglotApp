// DictionarySectionPage.xaml.cs
using PolyglotApp.Desktop.Pages;
using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Desktop.ViewModels;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Navigation;

namespace PolyglotApp.Desktop.Pages;

public partial class DictionarySectionPage : Page
{
    public DictionarySectionPage()
    {
        InitializeComponent();
        DataContext = new SectionSelectionViewModel();
    }

    private void SectionButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Section selectedSection)
        {
            // Navigate to next page (Unit page), pass section title
            NavigationService?.Navigate(new DictionaryUnitPage(selectedSection.Title));
        }
    }
}
