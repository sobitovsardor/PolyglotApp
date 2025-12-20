using PolyglotApp.Domain.Entities.Enums;
using PolyglotApp.Domain.Entities.Test;
using PolyglotApp.Service.Interface.Test;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;

namespace PolyglotApp.Desktop.ViewModels.Test
{
    public class TestExecutionViewModel : INotifyPropertyChanged
    {
        private readonly ITestService _testService;
        private readonly string _sectionTitle;
        private readonly string _unitTitle;
        private readonly string _fromLang;
        private readonly string _toLang;
        private readonly Difficulty _difficulty;

        private readonly DateTime _startTime;
        private readonly System.Timers.Timer _timer;



        private int _currentIndex = 0;
        private int _timeLeft;

        public ObservableCollection<TestQuestion> Questions { get; set; } = new();
        public TestQuestion? CurrentQuestion => Questions.Count > 0 ? Questions[_currentIndex] : null;

        public ObservableCollection<string> CurrentOptions { get; set; } = new();

        public int TotalQuestions => Questions.Count;
        public int CurrentIndexDisplay => _currentIndex + 1;

        public int TimeLeft
        {
            get => _timeLeft;
            private set
            {
                _timeLeft = value;
                OnPropertyChanged();
            }
        }

        public event Action<TestResult>? TestFinished;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public TestExecutionViewModel(
            ITestService testService,
            string sectionTitle,
            string unitTitle,
            string fromLang,
            string toLang,
            Difficulty difficulty)
        {
            _testService = testService;
            _sectionTitle = sectionTitle;
            _unitTitle = unitTitle;
            _fromLang = fromLang;
            _toLang = toLang;
            _difficulty = difficulty;

            _startTime = DateTime.Now;
            TimeLeft = (int)difficulty;

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();


            LoadQuestions();
        }

        private async void LoadQuestions()
        {
            var questions = await _testService.GenerateTestAsync(_sectionTitle, _unitTitle, _fromLang, _toLang);
            Questions.Clear();
            foreach (var q in questions)
                Questions.Add(q);

            OnPropertyChanged(nameof(TotalQuestions));
            OnPropertyChanged(nameof(CurrentIndexDisplay));
            OnPropertyChanged(nameof(CurrentQuestion));

            LoadOptions();
        }

        private void LoadOptions()
        {
            if (CurrentQuestion == null) return;

            var rnd = new Random();
            var options = new[] { CurrentQuestion.CorrectTranslation }
                .Concat(
                    Questions.Where(q => q != CurrentQuestion)
                             .Select(q => q.CorrectTranslation)
                             .Distinct()
                             .OrderBy(_ => rnd.Next())
                             .Take(3)
                )
                .OrderBy(_ => rnd.Next())
                .ToList();

            CurrentOptions.Clear();
            foreach (var option in options)
                CurrentOptions.Add(option);

            OnPropertyChanged(nameof(CurrentOptions));
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            TimeLeft--;
            if (TimeLeft <= 0)
            {
                FinishTest();
            }
        }

        public void SubmitAnswer(string answer)
        {
            if (CurrentQuestion == null) return;

            CurrentQuestion.UserAnswer = answer;

            if (_currentIndex + 1 < Questions.Count)
            {
                _currentIndex++;

                OnPropertyChanged(nameof(CurrentIndexDisplay));
                OnPropertyChanged(nameof(CurrentQuestion));

                LoadOptions();
            }
            else
            {
                FinishTest();
            }
        }

        private async void FinishTest()
        {
            _timer.Stop();

            var result = new TestResult
            {
                SectionTitle = _sectionTitle,
                UnitTitle = _unitTitle,
                Difficulty = _difficulty,
                TotalQuestions = Questions.Count,
                CorrectAnswers = Questions.Count(q => q.IsCorrect),
                TimeTaken = DateTime.Now - _startTime,
                Mistakes = Questions.Where(q => !q.IsCorrect).ToList()
            };

            await _testService.SaveTestResultAsync(result);
            MessageBox.Show("Test saved successfully!");
            TestFinished?.Invoke(result);
        }
    }
}
