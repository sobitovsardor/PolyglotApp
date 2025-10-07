using PolyglotApp.DataAccess.Interfaces.Test;
using PolyglotApp.Domain.Entities.Test;
using System.Text.Json;

namespace PolyglotApp.DataAccess.Repositories.Test
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly string _filePath;

        public TestResultRepository(string filePath)
        {
            _filePath = filePath;
        }

        private async Task<List<TestResult>> LoadResultsAsync()
        {
            if (!File.Exists(_filePath))
                return new List<TestResult>();

            using FileStream stream = new(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var result = await JsonSerializer.DeserializeAsync<List<TestResult>>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result ?? new List<TestResult>();
        }

        private async Task SaveDataAsync(List<TestResult> results)
        {
            using FileStream stream = new(_filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            await JsonSerializer.SerializeAsync(stream, results, new JsonSerializerOptions { WriteIndented = true });
        }

        public async Task<List<TestResult>> GetAllResultsAsync() => await LoadResultsAsync();

        public async Task SaveResultAsync(TestResult result)
        {
            var results = await LoadResultsAsync();
            results.Add(result);
            await SaveDataAsync(results);
        }

        public async Task<TestResult?> GetBestResultAsync(string sectionTitle, string unitTitle)
        {
            var results = await LoadResultsAsync();
            return results
                .Where(r => r.SectionTitle == sectionTitle && r.UnitTitle == unitTitle)
                .OrderByDescending(r => r.CorrectAnswers)
                .ThenBy(r => r.TimeTaken)
                .FirstOrDefault();
        }

        public async Task DeleteResultsForUnitAsync(string sectionTitle, string unitTitle)
        {
            var results = await LoadResultsAsync();
            results.RemoveAll(r => r.SectionTitle == sectionTitle && r.UnitTitle == unitTitle);
            await SaveDataAsync(results);
        }

        public async Task DeleteResultsBySectionAsync(string sectionTitle)
        {
            var results = await LoadResultsAsync();
            results.RemoveAll(r => r.SectionTitle == sectionTitle);
            await SaveDataAsync(results);
        }
    }
}
