using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interfaces;
using System.Collections.ObjectModel;

namespace PolyglotApp.Desktop.ViewModels;

public class SectionSelectionViewModel
{
    private readonly IDictionaryService _dictionaryService;
    public ObservableCollection<Section> Sections { get; set; } = new();

    public SectionSelectionViewModel()
    {
        _dictionaryService = App.GetService<IDictionaryService>();
        LoadSectionsAsync();
    }

    private async void LoadSectionsAsync()
    {
        var allSections = await _dictionaryService.GetAllSectionsAsync();
        Sections.Clear();
        foreach (var section in allSections)
            Sections.Add(section);
    }
}

