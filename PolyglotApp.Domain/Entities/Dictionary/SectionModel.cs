namespace PolyglotApp.Domain.Entities.Dictionary;

public class SectionModel
{
    public int SectionNumber { get; set; }

    public List<UnitModel> Unit { get; set; } = new();
}
