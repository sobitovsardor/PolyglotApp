using PolyglotApp.Domain.Entities.Test;

namespace PolyglotApp.DataAccess.Interfaces.Test;

public interface ITestResultRepository
{
    Task<List<TestResult>> GetAllResultsAsync();

    Task SaveResultAsync(TestResult result);

    Task<TestResult?> GetBestResultAsync(string sectionTitle, string unitTitle);

}
