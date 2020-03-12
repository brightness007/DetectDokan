using System.Windows;

namespace InstallDokan.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (this.ShutdownMode != ShutdownMode.OnExplicitShutdown)
            {
                this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            }

            var languageSettings = new LanguageSettings();
            var chooseLanguageView = new ChooseLanguageView() { DataContext = languageSettings };
            var result = chooseLanguageView.ShowDialog();
            if (result == true)
            {
                bool dokanInstalled = DetectDokan.DokanDriverUtility.QueryVersion(out uint dokanVersion);
                if (!dokanInstalled || dokanVersion < 0x190)
                {
                    DokanDriverState driverState = new DokanDriverState(languageSettings.SelectedLanguage);
                    var installDokanView = new InstallDokanView(languageSettings.SelectedLanguage, dokanVersion) { DataContext = driverState };
                    installDokanView.Left = chooseLanguageView.Left;
                    installDokanView.Top = chooseLanguageView.Top;
                    installDokanView.WindowStartupLocation = WindowStartupLocation.Manual;
                    result = installDokanView.ShowDialog();
                    if (result == true)
                    {
                        MessageBox.Show((driverState.SelectedActionIndex == 1) ? "Action: Install driver" : "Action: Do NOT install driver", "Result", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Action: Cancelled", "Result", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Dokan driver is already installed", "Result", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Action: Cancelled", "Result", MessageBoxButton.OK);
            }

            this.Shutdown();
        }
    }
}
