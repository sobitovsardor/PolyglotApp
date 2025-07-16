namespace PolyglotApp.Domain.Entities.Dictionary;

public class UnitModel
{
    public int UnitNumber { get; set; }

    public List<WordModel> Word { get; set; } = new();
}
