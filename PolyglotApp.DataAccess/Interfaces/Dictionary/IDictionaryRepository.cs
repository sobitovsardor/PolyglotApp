using PolyglotApp.Domain.Entities.Dictionary;

namespace PolyglotApp.DataAccess.Interfaces;

public interface IDictionaryRepository
{
    Task<List<Section>> GetAllSectionsAsync();
    Task<List<Unit>> GetUnitsBySectionTitleAsync(string sectionTitle);
    Task<List<Word>> GetWordsAsync(string sectionTitle, string unitTitle);
}


