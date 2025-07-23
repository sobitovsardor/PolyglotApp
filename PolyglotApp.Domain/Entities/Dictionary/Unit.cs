namespace PolyglotApp.Domain.Entities.Dictionary;

public class Unit
{
    public string Title { get; set; } = string.Empty;
    public List<Word> Words { get; set; } = new();
}

