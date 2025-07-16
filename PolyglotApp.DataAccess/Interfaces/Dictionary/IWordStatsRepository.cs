namespace PolyglotApp.DataAccess.Interfaces.Dictionary;

public interface IWordStatsRepository : IRepository<WordStatsModel>
{
    public Task<WordStatsModel?> GetByKeyAsync(string wordKey);
  
    public Task UpdateAsync(string wordKey, bool isCorrect);
}

