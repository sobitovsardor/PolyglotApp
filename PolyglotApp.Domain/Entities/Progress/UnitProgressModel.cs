using PolyglotApp.Domain.Enums;

namespace PolyglotApp.Domain.Entities.Progress;

public class UnitProgressModel
{
    public int Section { get; set; }

    public int Unit { get; set; }

    public int MaxCorrect { get; set; }

    public int TotalQuestions { get; set; } = 20;

    public GameDifficulty BestDifficulty { get; set; }

    public bool IsCompleted => MaxCorrect > 0;
}
