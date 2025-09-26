using PolyglotApp.Domain.Entities.Test;
using System.Collections.ObjectModel;

namespace PolyglotApp.Desktop.ViewModels.Test;

public class TestResultViewModel
{
    public string SectionTitle { get; set; }
    public string UnitTitle { get; set; }

    public string Difficulty { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public string TimeTaken { get; set; }

    public string Score => $"{CorrectAnswers} / {TotalQuestions}";

    public ObservableCollection<TestQuestion> Mistakes { get; set; }

    public TestResultViewModel(TestResult result)
    {
        SectionTitle = result.SectionTitle;
        UnitTitle = result.UnitTitle;
        Difficulty = result.Difficulty.ToString();
        TotalQuestions = result.TotalQuestions;
        CorrectAnswers = result.CorrectAnswers;
        TimeTaken = $"{result.TimeTaken.Minutes}m {result.TimeTaken.Seconds}s";

        Mistakes = new ObservableCollection<TestQuestion>(result.Mistakes);
    }
}

