namespace PolyglotApp.Domain.Entities.Test;

public class TestQuestion
{
    public string WordText { get; set; } = string.Empty;             // Asosiy so‘z
    public string CorrectTranslation { get; set; } = string.Empty;   // To‘g‘ri javob
    public string UserAnswer { get; set; } = string.Empty;           // Foydalanuvchi tanlagan javob

    public string FromLanguage { get; set; } = string.Empty;
    public string ToLanguage { get; set; } = string.Empty;

    public List<string> Options { get; set; } = new();               // 4 variant (to‘g‘ri + 3 noto‘g‘ri)

    public bool IsCorrect => UserAnswer == CorrectTranslation;
}

