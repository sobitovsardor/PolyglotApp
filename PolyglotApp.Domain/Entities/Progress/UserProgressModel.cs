namespace PolyglotApp.Domain.Entities.Progress;

public class UserProgressModel
{
    public List<UnitProgressModel> CompletedUnits { get; set; } = new();
}
