using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interface;
using System.Collections.ObjectModel;

namespace PolyglotApp.Desktop.ViewModels.Test;

public class TestUnitViewModel
{
    private readonly IDictionaryService _dictionaryService;
    private readonly string _sectionTitle;

    public ObservableCollection<Unit> Units { get; set; } = new();

    public TestUnitViewModel(IDictionaryService dictionaryService, string sectionTitle)
    {
        _dictionaryService = dictionaryService;
        _sectionTitle = sectionTitle;
        LoadUnitsAsync();
    }

    private async void LoadUnitsAsync()
    {
        var units = await _dictionaryService.GetUnitsBySectionTitleAsync(_sectionTitle);
        Units.Clear();
        foreach (var unit in units)
            Units.Add(unit);
    }
}

