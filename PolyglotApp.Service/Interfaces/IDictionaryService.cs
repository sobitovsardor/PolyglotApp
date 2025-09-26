using PolyglotApp.Domain.Entities.Dictionary;

namespace PolyglotApp.Service.Interface;

public interface IDictionaryService
{
    Task<List<Section>> GetAllSectionsAsync();
    Task<List<Unit>> GetUnitsBySectionTitleAsync(string sectionTitle);
    Task<List<Word>> GetWordsAsync(string sectionTitle, string unitTitle);
}

