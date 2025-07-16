using PolyglotApp.Domain.Enums;

namespace PolyglotApp.Domain.Entities.Test;

public class GameSettingsModel
{
    public string FromLanguage { get; set; } = string.Empty;

    public string ToLanguage { get; set; } = string.Empty;

    public GameDifficulty Difficulty { get; set; }

    public int Section { get; set; }

    public int Unit { get; set; }
}
