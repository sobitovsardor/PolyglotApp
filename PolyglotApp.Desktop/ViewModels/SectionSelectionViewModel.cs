// PolyglotApp.Desktop.ViewModels/SectionSelectionViewModel.cs
using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interfaces;
using System.Collections.ObjectModel;

public class SectionSelectionViewModel
{
    private readonly IDictionaryService _dictionaryService;
    public ObservableCollection<Section> Sections { get; set; } = new()!;

    public SectionSelectionViewModel(IDictionaryService dictionaryService)
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


