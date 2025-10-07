using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.DataAccess.Interfaces.Test;
using PolyglotApp.Domain.Entities.Test;
using PolyglotApp.Service.Extensions;
using PolyglotApp.Service.Interface.Test;
using System.Linq;

namespace PolyglotApp.Service.Services.Test
{
    public class TestService : ITestService
    {
        private readonly IDictionaryRepository _dictionaryRepository;
        private readonly ITestResultRepository _testResultRepository;

        public TestService(IDictionaryRepository dictionaryRepository, ITestResultRepository testResultRepository)
        {
            _dictionaryRepository = dictionaryRepository;
            _testResultRepository = testResultRepository;
        }

        public async Task<List<TestQuestion>> GenerateTestAsync(string sectionTitle, string unitTitle, string fromLang, string toLang)
        {
            var words = await _dictionaryRepository.GetWordsAsync(sectionTitle, unitTitle);
            var random = new Random();

            return words.OrderBy(_ => random.Next())
                .Take(20)
                .Select(word => new TestQuestion
                {
                    WordText = word.GetTextByLang(fromLang),
                    CorrectTranslation = word.GetTextByLang(toLang),
                    FromLanguage = fromLang,
                    ToLanguage = toLang
                })
                .ToList();
        }

        public async Task SaveTestResultAsync(TestResult result)
        {
            await _testResultRepository.SaveResultAsync(result);
        }

        public async Task<TestResult?> GetBestResultAsync(string sectionTitle, string unitTitle)
        {
            return await _testResultRepository.GetBestResultAsync(sectionTitle, unitTitle);
        }

        public async Task DeleteResultsForUnitAsync(string sectionTitle, string unitTitle)
        {
            await _testResultRepository.DeleteResultsForUnitAsync(sectionTitle, unitTitle);
        }

        public async Task DeleteResultsForSectionAsync(string sectionTitle)
        {
            await _testResultRepository.DeleteResultsBySectionAsync(sectionTitle);
        }
    }
}
