using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;

public class DokanDriverState: INotifyPropertyChanged
{
    public DokanDriverState(CultureInfo cultureInfo)
    {
        if (cultureInfo.LCID == CultureInfo.CreateSpecificCulture("zh-CN").LCID)
        {
            DokanDriverText = "Dokan 驱动: ";
            OKButtonText = "确定";
            CancelButtonText = "取消";
            SupportedActions = new string[] { "请选择", "安装 Dokan 驱动", "不安装 Dokan 驱动" };
        }
        else
        {
            DokanDriverText = "Dokan Driver: ";
            OKButtonText = "OK";
            CancelButtonText = "Cacnel";
            SupportedActions = new string[] { "Please choose action", "Install Dokan driver", "Do NOT install Dokan driver" };
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public string DokanDriverText { get; }
    
    public string OKButtonText { get; }
    
    public string CancelButtonText { get; }

    public string InstallState { get; set; }

    public Color InstallStateColor { get; set; }

    private int _SelectedActionIndex = 0;

    public int SelectedActionIndex
    {
        get => _SelectedActionIndex;
        set
        {
            _SelectedActionIndex = value;
            OnPropertyChanged("IsValidActionIndex");
        }
    }

    public string[] SupportedActions { get; }

    public bool IsValidActionIndex { get => SelectedActionIndex != 0; }
}