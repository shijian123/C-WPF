using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;


namespace WpfApp_101.Simple
{
    // 传递的消息
    // public record MyMessage(string Content);

    /// <summary>
    /// Window_NotifyChanged.xaml 的交互逻辑
    /// </summary>
    public partial class Window_NotifyChanged : Window
    {
        public Window_NotifyChanged()
        {
            InitializeComponent();
            //this.DataContext = new MyViewModel();

            ///使用 MVVM Toolkit
            this.DataContext = new MyViewModel_MVVM();
            WeakReferenceMessenger.Default.Register<Window_NotifyChanged, string>(this, (recipient, message) =>
            {
                MessageBox.Show(message);
            });

        }
    }
}



/// <summary>
/// 使用 MVVM Toolkit
/// </summary>
public class MyViewModel_MVVM : ObservableObject
{
    private string _name;
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    private string _title;
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public RelayCommand ShowCommand { get; }

    public MyViewModel_MVVM()
    {
        Name = "Tom";
        Title = "Title";
        ShowCommand = new RelayCommand(Show);
    }

    private void Show()
    {
        // 命令执行时的逻辑
        MessageBox.Show("点击了按钮！");

        Name = "Jerry";
        Title = Name + "点击按钮";

        WeakReferenceMessenger.Default.Send("名字修改为 Jerry");
    }
}













/// <summary>
/// 自定义 ViewModel
/// </summary>
public class MyViewModel : MyNotifyPropertyChanged
{
    /// <summary>
    ///  命令事件
    /// </summary>
    public MyCommand ShowCommand { get; set; }

    /// <summary>
    /// 属性更改
    /// </summary>
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged();
            
        }
    }
    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public MyViewModel()
    {
        Name = "Tom";
        Title = "Title";

        ShowCommand = new MyCommand(Show);
    }

    public void Show()
    {
        MessageBox.Show("点击了按钮！");

        Name = "Jerry";
        Title = Name + "点击按钮";
        
    }
}

/// <summary>
/// 属性更改通知
/// </summary>
public class MyNotifyPropertyChanged: INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


/// <summary>
/// 自定义命令
/// </summary>
public class MyCommand : ICommand
{

    Action _execute;
    public event EventHandler CanExecuteChanged;

    public MyCommand(Action execute)
    {
        _execute = execute;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _execute();
    }
}


