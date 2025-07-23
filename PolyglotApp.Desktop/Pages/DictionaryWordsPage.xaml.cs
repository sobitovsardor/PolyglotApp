using PolyglotApp.Desktop.ViewModels;
using System.Windows.Controls;

namespace PolyglotApp.Desktop.Pages;

public partial class DictionaryWordsPage : Page
{
    public DictionaryWordsPage(string sectionTitle, string unitTitle)
    {
        InitializeComponent();
        DataContext = new WordListViewModel(sectionTitle, unitTitle);
    }
}

