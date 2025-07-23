using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.Domain.Entities.Dictionary;
using PolyglotApp.Service.Interfaces;

namespace PolyglotApp.Service.Services;

public class DictionaryService : IDictionaryService
{
    private readonly IDictionaryRepository _repository;

    public DictionaryService(IDictionaryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Section>> GetAllSectionsAsync()
    {
        return await _repository.GetAllSectionsAsync();
    }

    public async Task<List<Unit>> GetUnitsBySectionTitleAsync(string sectionTitle)
    {
        return await _repository.GetUnitsBySectionTitleAsync(sectionTitle);
    }

    public async Task<List<Word>> GetWordsAsync(string sectionTitle, string unitTitle)
    {
        return await _repository.GetWordsAsync(sectionTitle, unitTitle);
    }
}


