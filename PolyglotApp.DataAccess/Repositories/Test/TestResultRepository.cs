using PolyglotApp.DataAccess.Interfaces.Test;
using PolyglotApp.Domain.Entities.Test;
using System.Text.Json;

namespace PolyglotApp.DataAccess.Repositories.Test;

public class TestResultRepository : ITestResultRepository
{
    private string _filePath;

    public TestResultRepository(string filePath)
    {
        _filePath = filePath;
    }

    private async Task<List<TestResult>> LoadResultsAsync()
    {
        if (!File.Exists(_filePath))
            return new List<TestResult>();

        using FileStream stream = new(_filePath, FileMode.Open, FileAccess.Read);
        var result = await JsonSerializer.DeserializeAsync<List<TestResult>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result ?? new List<TestResult>();
    }

    private async Task SaveDataAsync(List<TestResult> results)
    {
        using FileStream stream = new(_filePath, FileMode.Create, FileAccess.Write);
        await JsonSerializer.SerializeAsync(stream, results, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }

    public async Task<List<TestResult>> GetAllResultsAsync()
    {
        return await LoadResultsAsync();
    }

    public async Task SaveResultAsync(TestResult result)
    {
        var results = await LoadResultsAsync();
        results.Add(result);
        await SaveDataAsync(results);
    }

    public async Task<TestResult?> GetBestResultAsync(string sectionTitle, string unitTitle)
    {
        var allResults = await LoadResultsAsync();

        return allResults
            .Where(r => r.SectionTitle == sectionTitle && r.UnitTitle == unitTitle)
            .OrderByDescending(r => r.CorrectAnswers)
            .ThenBy(r => r.TimeTaken.TotalSeconds)
            .FirstOrDefault();
    }

}
