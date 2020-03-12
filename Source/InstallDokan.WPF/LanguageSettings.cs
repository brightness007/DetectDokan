using System.Globalization;
using System.Linq;

public class LanguageSettings
{
    public LanguageSettings()
    {
        SelectedLanguage = SupportedLanguages.Where(x => CultureInfo.CurrentCulture.Equals(x)).FirstOrDefault() ?? SupportedLanguages.FirstOrDefault();
    }

    public CultureInfo SelectedLanguage { get; set; }

    public CultureInfo[] SupportedLanguages { get; set; } = "en-US,zh-CN".Split(',')
                                                            .Select(x => new CultureInfo(x))
                                                            .ToArray();
}
