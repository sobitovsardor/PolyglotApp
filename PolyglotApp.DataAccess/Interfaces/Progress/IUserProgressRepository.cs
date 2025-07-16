using PolyglotApp.Domain.Entities.Progress;

namespace PolyglotApp.DataAccess.Interfaces.Progress;

public interface IUserProgressRepository : IRepository<UserProgressModel>
{
    // Optional: GetProgressByUnit, ResetProgress
}

