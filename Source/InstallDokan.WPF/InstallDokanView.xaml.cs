using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

public partial class InstallDokanView : Window
{
    public InstallDokanView(CultureInfo cultureInfo, uint dokanVersion)
    {
        InitializeComponent();

        if (cultureInfo.LCID == CultureInfo.CreateSpecificCulture("zh-CN").LCID)
        {
            this.driverInstallState.Inlines.Clear();
            this.driverInstallState.Inlines.Add(new Run("Dokan 驱动: "));
            if (dokanVersion == 0)
            {
                this.driverInstallState.Inlines.Add(new Run("未安装") { Foreground = new SolidColorBrush(Colors.Red) });
            }
            else
            {
                this.driverInstallState.Inlines.Add(new Run("版本过低") { Foreground = new SolidColorBrush(Colors.Red) });
                this.driverInstallState.Inlines.Add(new Run($" (当前版本号为 {dokanVersion:X})"));
            }
        }
        else
        {
            this.driverInstallState.Inlines.Clear();
            this.driverInstallState.Inlines.Add(new Run("Dokan Driver: "));
            if (dokanVersion == 0)
            {
                this.driverInstallState.Inlines.Add(new Run("Not Installed") { Foreground = new SolidColorBrush(Colors.Red) });
            }
            else
            {
                this.driverInstallState.Inlines.Add(new Run("Version is too low") { Foreground = new SolidColorBrush(Colors.Red) });
                this.driverInstallState.Inlines.Add(new Run($" ({dokanVersion:X})"));
            }
        }
    }

    void OK_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
        Close();
    }

    private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }
}
