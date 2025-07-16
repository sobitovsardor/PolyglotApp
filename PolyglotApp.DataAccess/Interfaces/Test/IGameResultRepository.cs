using PolyglotApp.Domain.Entities.Test;

namespace PolyglotApp.DataAccess.Interfaces.Test;

public interface IGameResultRepository : IRepository<GameResultModel>
{
    // Future: GetResultsByDate, BestScore, etc.
}

