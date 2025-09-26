using PolyglotApp.Domain.Entities.Enums;

namespace PolyglotApp.Domain.Entities.Test;

public class TestConfig
{
    public string SectionTitle { get; set; } = string.Empty;
    public string UnitTitle { get; set; } = string.Empty;

    public string FromLanguage { get; set; } = "eng";
    public string ToLanguage { get; set; } = "uz";

    public Difficulty Difficulty { get; set; } = Difficulty.Medium;
}
