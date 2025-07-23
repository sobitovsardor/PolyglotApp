namespace PolyglotApp.Domain.Entities.Dictionary;

public class Section
{
    public string Title { get; set; } = default!;
    public List<Unit> Units { get; set; } = new();
}
