using PolyglotApp.Domain.Entities.Dictionary;

namespace PolyglotApp.Service.Extensions;

public static class WordExtensions
{
    public static string GetTextByLang(this Word word, string lang)
    {
        return lang.ToLower() switch
        {
            "uz" => word.Uz?.Text ?? "",
            "ru" => word.Ru?.Text ?? "",
            "eng" => word.Eng?.Text ?? "",
            "de" => word.De?.Text ?? "",
            _ => ""
        };
    }
}