using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interface;
using System.Collections.ObjectModel;

namespace PolyglotApp.Desktop.ViewModels.Test;

public class TestSectionViewModel
{
    private readonly IDictionaryService _dictionaryService;

    public ObservableCollection<Section> Sections { get; set; } = new();

    public TestSectionViewModel(IDictionaryService dictionaryService)
    {
        _dictionaryService = dictionaryService;
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
