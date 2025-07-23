using PolyglotApp.Desktop.ViewModels;
using PolyglotApp.Domain.Entities.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class DictionaryUnitPage : Page
{
    private readonly string _sectionTitle;

    public DictionaryUnitPage(string sectionTitle)
    {
        InitializeComponent();
        _sectionTitle = sectionTitle;
        DataContext = new UnitSelectionViewModel(sectionTitle);
    }

    private void UnitButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Unit selectedUnit)
        {
            NavigationService?.Navigate(new DictionaryWordsPage(_sectionTitle, selectedUnit.Title));
        }
    }
}
