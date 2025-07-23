using Microsoft.Extensions.DependencyInjection;
using PolyglotApp.DataAccess.Interfaces;
using PolyglotApp.DataAccess.Repositories;
using PolyglotApp.Service.Interfaces;
using PolyglotApp.Service.Services;
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

            // ✅ Fayl yo'lini ko‘rsatamiz
            var dictionaryFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "dictionary.json");

            // ✅ DictionaryRepository ni string parametri bilan ro'yxatdan o'tkazamiz
            serviceCollection.AddSingleton<IDictionaryRepository>(provider =>
                new DictionaryRepository(dictionaryFilePath));

            // ✅ Service ni qo‘shamiz
            serviceCollection.AddSingleton<IDictionaryService, DictionaryService>();

            Services = serviceCollection.BuildServiceProvider();
            base.OnStartup(e);
        }

        public static T GetService<T>() where T : notnull
            => Services.GetRequiredService<T>();
    }
}
