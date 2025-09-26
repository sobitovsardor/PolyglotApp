using PolyglotApp.Domain.Entities.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PolyglotApp.Desktop.ViewModels.Test;

public class TestConfigurationViewModel : INotifyPropertyChanged
{
    private string _fromLanguage = "eng";
    private string _toLanguage = "uz";
    private Difficulty _difficulty = Difficulty.Easy;

    public string SectionTitle { get; }
    public string UnitTitle { get; }

    public ObservableCollection<string> Languages { get; } =
        new() { "uz", "ru", "eng", "de" };

    public IEnumerable<Difficulty> Difficulties => Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>();

    public string FromLanguage
    {
        get => _fromLanguage;
        set { _fromLanguage = value; OnPropertyChanged(); }
    }

    public string ToLanguage
    {
        get => _toLanguage;
        set { _toLanguage = value; OnPropertyChanged(); }
    }

    public Difficulty Difficulty
    {
        get => _difficulty;
        set { _difficulty = value; OnPropertyChanged(); }
    }

    public TestConfigurationViewModel(string sectionTitle, string unitTitle)
    {
        SectionTitle = sectionTitle;
        UnitTitle = unitTitle;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

