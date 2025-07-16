namespace PolyglotApp.Domain.Entities.Dictionary;

public class WordModel
{
    public WordTranslation Uz { get; set; } = new();

    public WordTranslation Ru { get; set; } = new();

    public WordTranslation Eng { get; set; } = new();

    public WordTranslation De { get; set; } = new();
}
