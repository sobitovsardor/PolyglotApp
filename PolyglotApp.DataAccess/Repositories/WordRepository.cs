using PolyglotApp.DataAccess.Constants;
using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.Domain.Entities.Dictionary;
using System.Text.Json;

namespace PolyglotApp.DataAccess.Repositories;

public class WordRepository : IReadOnlyRepository<WordModel>
{
    public async Task<List<WordModel>> GetAllAsync()
    {
        if (!File.Exists(FilePaths.Words))
            return new List<WordModel>();

        var json = await File.ReadAllTextAsync(FilePaths.Words);
        return JsonSerializer.Deserialize<List<WordModel>>(json) ?? new List<WordModel>();
    }
}
