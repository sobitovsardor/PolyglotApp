using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interfaces;
using System.Collections.ObjectModel;

namespace PolyglotApp.Desktop.ViewModels;

public class WordListViewModel
{
    private readonly IDictionaryService _dictionaryService;
    public ObservableCollection<Word> Words { get; set; } = new()!;

    public WordListViewModel(string sectionTitle, string unitTitle)
    {
        _dictionaryService = App.GetService<IDictionaryService>();
        LoadWordsAsync(sectionTitle, unitTitle);
    }

    private async void LoadWordsAsync(string sectionTitle, string unitTitle)
    {
        var allWords = await _dictionaryService.GetWordsAsync(sectionTitle, unitTitle);
        Words.Clear();
        foreach (var word in allWords)
            Words.Add(word);
    }
}

