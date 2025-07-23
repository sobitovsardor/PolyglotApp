using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.Domain.Entities.Dictionary;
using System.Text.Json;

namespace PolyglotApp.DataAccess.Repositories;

public class DictionaryRepository : IDictionaryRepository
{
    private readonly string _filePath;

    public DictionaryRepository(string filePath)
    {
        _filePath = filePath;
    }

    private async Task<List<Section>> LoadDataAsync()
    {
        if (!File.Exists(_filePath))
            return new List<Section>();

        using FileStream stream = new(_filePath, FileMode.Open, FileAccess.Read);
        var result = await JsonSerializer.DeserializeAsync<List<Section>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result ?? new List<Section>();
    }

    public async Task<List<Section>> GetAllSectionsAsync()
    {
        return await LoadDataAsync();
    }

    public async Task<List<Unit>> GetUnitsBySectionTitleAsync(string sectionTitle)
    {
        var sections = await LoadDataAsync();
        return sections.FirstOrDefault(s => s.Title == sectionTitle)?.Units ?? new();
    }

    public async Task<List<Word>> GetWordsAsync(string sectionTitle, string unitTitle)
    {
        var sections = await LoadDataAsync();
        var units = sections.FirstOrDefault(s => s.Title == sectionTitle)?.Units;
        return units?.FirstOrDefault(u => u.Title == unitTitle)?.Words ?? new();
    }
}
