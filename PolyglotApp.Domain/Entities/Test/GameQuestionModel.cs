namespace PolyglotApp.Domain.Entities.Test;

public class GameQuestionModel
{
    public string QuestionText { get; set; } = string.Empty;

    public string CorrectAnswer { get; set; } = string.Empty;

    public List<string> Options { get; set; } = new();
}
