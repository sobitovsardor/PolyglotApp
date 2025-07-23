namespace PolyglotApp.Domain.Entities.Dictionary;

public class Section
{
    public string Title { get; set; } = string.Empty;
    public List<Unit> Units { get; set; } = new();
}
