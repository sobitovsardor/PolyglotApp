using PolyglotApp.Domain.Entities.Test;

namespace PolyglotApp.Service.Interface;

public interface ITestService
{
    Task<List<TestQuestion>> GenerateTestAsync(string sectionTiitle, string unitTitle, string fromLang, string toLang);

    Task SaveTestResultAsync(TestResult result);

    Task<TestResult?> GetBestResultAsync(string sectionTitle, string unitTitle);
}
