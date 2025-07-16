using PolyglotApp.Domain.Entities.Dictionary;

namespace PolyglotApp.DataAccess.Interfaces.Dictionary;

public interface IUnitRepository : IReadOnlyRepository<UnitModel>
{
    public Task<UnitModel> GetByIdAsync(int sectionId, int unitId);
}
