using PolyglotApp.Domain.Enums;

public class AppStateModel
{
    public int LastOpenedSectionId { get; set; }
    
    public int LastOpenedUnitId { get; set; }

    public string FromLanguage { get; set; } = "uz";
   
    public string ToLanguage { get; set; } = "en";
   
    public GameDifficulty LastDifficulty { get; set; }
}

