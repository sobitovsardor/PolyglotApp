namespace PolyglotApp.Domain.Entities.Test;

public class GameResultModel
{
    public int TotalQuestions { get; set; }

    public int CorrectAnswers { get; set; }

    public List<string> IncorrectWords { get; set; } = new();

    public string Difficulty { get; set; } = string.Empty;

    public string FromLanguage { get; set; } = string.Empty;

    public string ToLanguage { get; set; } = string.Empty;

    public DateTime CompletedAt { get; set; } = DateTime.Now;
}
