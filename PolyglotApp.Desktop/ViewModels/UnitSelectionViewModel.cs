using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interface;
using System.Collections.ObjectModel;

namespace PolyglotApp.Desktop.ViewModels;

public class UnitSelectionViewModel
{
    private readonly IDictionaryService _dictionaryService;
    public ObservableCollection<Unit> Units { get; set; } = new()!;

    public UnitSelectionViewModel(string sectionTitle)
    {
        _dictionaryService = App.GetService<IDictionaryService>();
        LoadUnitsAsync(sectionTitle);
    }

    private async void LoadUnitsAsync(string sectionTitle)
    {
        var allUnits = await _dictionaryService.GetUnitsBySectionTitleAsync(sectionTitle);
        Units.Clear();
        foreach (var unit in allUnits)
            Units.Add(unit);
    }
}