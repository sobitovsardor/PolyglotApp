using PolyglotApp.DataAccess.Interfaces;
using System.Text.Json;

namespace PolyglotApp.DataAccess.Repositories;

public class JsonRepository<T> : IRepository<T>
{
    private string _filePath;

    public JsonRepository(string filePath)
    {
        this._filePath = filePath;
    }

    public async Task SaveAllAsync(List<T> items)
    {
        var json = JsonSerializer.Serialize(items, new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task<List<T>> GetAllAsync()
    {

        if (!File.Exists(_filePath))
            return new List<T>();

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}
