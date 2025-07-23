namespace PolyglotApp.Domain.Entities.Dictionary;

public class Word
{
    public Translation Uz { get; set; } = new();
    public Translation Ru { get; set; } = new();
    public Translation Eng { get; set; } = new();
    public Translation De { get; set; } = new();
}
