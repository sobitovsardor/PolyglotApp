// PolyglotApp.Desktop/ViewModelLocator.cs
using PolyglotApp.Service.Interface;

namespace PolyglotApp.Desktop
{
    public class ViewModelLocator
    {
        public SectionSelectionViewModel SectionSelectionViewModel =>
            new(App.GetService<IDictionaryService>());

        // Keyinroq boshqa viewmodellarga ham qo‘shasiz:
        // public DictionaryUnitViewModel DictionaryUnitViewModel => ...
    }
}
