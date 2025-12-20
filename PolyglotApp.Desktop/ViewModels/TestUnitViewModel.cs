using PolyglotApp.Service.Interface;
using PolyglotApp.Service.Interface.Test;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PolyglotApp.Desktop.ViewModels.Test;

public class TestUnitViewModel : INotifyPropertyChanged
{
    private readonly IDictionaryService _dictionaryService;
    private readonly ITestService _testService;

    public string SectionTitle { get; }
    public ObservableCollection<UnitDisplayModel> Units { get; set; } = new();

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public TestUnitViewModel(string sectionTitle, IDictionaryService dictionaryService, ITestService testService)
    {
        SectionTitle = sectionTitle;
        _dictionaryService = dictionaryService;
        _testService = testService;
        LoadUnitsAsync();
    }

    private async void LoadUnitsAsync()
    {
        var units = await _dictionaryService.GetUnitsBySectionTitleAsync(SectionTitle);
        Units.Clear();

        foreach (var unit in units)
        {
            var best = await _testService.GetBestResultAsync(SectionTitle, unit.Title);
            string bestText = best is null
                ? "—"
                : $"{best.Difficulty} {best.CorrectAnswers}/{best.TotalQuestions}";

            Units.Add(new UnitDisplayModel
            {
                Title = unit.Title,
                BestResult = bestText
            });
        }
    }

    public async Task RefreshUnitsAsync()
    {
        await Task.Run(() => LoadUnitsAsync());
    }
}

public class UnitDisplayModel
{
    public string Title { get; set; } = string.Empty;
    public string BestResult { get; set; } = string.Empty;
}
