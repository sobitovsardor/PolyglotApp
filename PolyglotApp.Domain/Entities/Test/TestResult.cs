using PolyglotApp.Domain.Entities.Enums;

namespace PolyglotApp.Domain.Entities.Test;

public class TestResult
{
    public string SectionTitle { get; set; } = string.Empty;
    public string UnitTitle { get; set; } = string.Empty;

    public Difficulty Difficulty { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }

    public TimeSpan TimeTaken { get; set; } = TimeSpan.Zero;

    public List<TestQuestion> Mistakes { get; set; } = new();
}

