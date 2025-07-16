namespace PolyglotApp.DataAccess.Interfaces;

public interface IRepository<T> : IReadOnlyRepository<T>
{
    public Task SaveAllAsync(List<T> items);
}
