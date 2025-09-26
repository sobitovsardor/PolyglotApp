using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.DataAccess.Interfaces.Test;
using PolyglotApp.Domain.Entities.Enums;
using PolyglotApp.Domain.Entities.Test;
using PolyglotApp.Service.Extensions;
using PolyglotApp.Service.Interface;

namespace PolyglotApp.Service.Services;

public class TestService : ITestService
{
    private IDictionaryRepository _dictionaryRepository;
    private ITestResultRepository _testResultRepository;

    public TestService(IDictionaryRepository dictionaryRepository, ITestResultRepository testResultRepository)
    {
        _dictionaryRepository = dictionaryRepository;
        _testResultRepository = testResultRepository;
    }

    public async Task<List<TestQuestion>> GenerateTestAsync(string sectionTiitle, string unitTitle, string fromLang, string toLang)
    {
        var words = await _dictionaryRepository.GetWordsAsync(sectionTiitle, unitTitle);

        var random = new Random();
        var selected = words.OrderBy(_ => random.Next())
            .Take(20).ToList();

        var questions = selected.Select(word => new TestQuestion
        {
            WordText = word.GetTextByLang(fromLang),
            CorrectTranslation = word.GetTextByLang(toLang),
            FromLanguage = fromLang,
            ToLanguage = toLang
        }).ToList();

        return questions;
    }

    public async Task SaveTestResultAsync(TestResult result)
    {
        await _testResultRepository.SaveResultAsync(result);
    }

    public async Task<TestResult?> GetBestResultAsync(string sectionTitle, string unitTitle)
    {
        return await _testResultRepository.GetBestResultAsync(sectionTitle, unitTitle);
    }

    public async Task<TestResult> FinishTestAsync(string sectionTitle, string unitTitle, Difficulty difficulty, TimeSpan timeTaken, List<TestQuestion> questions)
    {
        var result = new TestResult
        {
            SectionTitle = sectionTitle,
            UnitTitle = unitTitle,
            Difficulty = difficulty,
            TimeTaken = timeTaken,
            TotalQuestions = questions.Count,
            CorrectAnswers = questions.Count(q => q.IsCorrect),
            Mistakes = questions.Where(q => !q.IsCorrect).ToList()
        };

        await _testResultRepository.SaveResultAsync(result);
        return result;
    }
}
