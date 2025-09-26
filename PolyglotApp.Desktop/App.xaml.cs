using Microsoft.Extensions.DependencyInjection;
using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.DataAccess.Interfaces.Test;
using PolyglotApp.DataAccess.Repositories;
using PolyglotApp.DataAccess.Repositories.Test;
using PolyglotApp.Service.Interface;
using PolyglotApp.Service.Services;       // <-- TestService namespace
using System;
using System.IO;
using System.Windows;

namespace PolyglotApp.Desktop
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            // fayl yo'llari
            var dictionaryFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "dictionary.json");
            var appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PolyglotApp");
            Directory.CreateDirectory(appData);
            var testResultsPath = Path.Combine(appData, "test_results.json");

            // Repository va Service ro'yxatdan o'tkazish
            serviceCollection.AddSingleton<IDictionaryRepository>(sp => new DictionaryRepository(dictionaryFilePath));
            serviceCollection.AddSingleton<IDictionaryService, DictionaryService>();

            serviceCollection.AddSingleton<ITestResultRepository>(sp => new TestResultRepository(testResultsPath));

            // !!! MUHIM: ITestService ni ro'yxatdan o'tkazamiz
            serviceCollection.AddSingleton<ITestService, TestService>();

            Services = serviceCollection.BuildServiceProvider();

            base.OnStartup(e);
        }

        public static T GetService<T>() where T : notnull
            => Services.GetRequiredService<T>();
    }
}

