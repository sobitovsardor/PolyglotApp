namespace PolyglotApp.DataAccess.Interfaces;

public interface IReadOnlyRepository<T>
{
    public Task<List<T>> GetAllAsync();
}
