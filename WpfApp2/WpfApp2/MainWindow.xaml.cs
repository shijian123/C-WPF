using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // PasswordBox 不支持绑定，所以需要单独处理

        //UserModel user;

        LoginViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            //user = new UserModel();
            viewModel = new LoginViewModel(this);
            this.DataContext = viewModel;
        }
        private void Login_Click(object senderr, RoutedEventArgs e)
        {

            if (viewModel.User.username == "" || txtPwd.Password == "")
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else if (viewModel.User.username != "admin" || txtPwd.Password != "admin")
            {
                MessageBox.Show("用户名或密码错误" + viewModel.User.username + "1" + txtPwd.Password.ToString());
                viewModel.User.username = string.Empty;
                txtPwd.Password = string.Empty;
            }
            else
            {
                // MessageBox.Show("登录成功");
                //HomeWindow homeWindow = new HomeWindow();
                //homeWindow.Show();
                NavigationWindow window = new NavigationWindow();
                window.Source = new Uri("Home/HomeMainPage.xaml", UriKind.Relative);
                window.Show();
                this.Close();
            }

        }


    }

    ///  设置一个模型类，用于绑定数据
    public class UserModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("username");

            }
        }

        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// 设置一个ViewModel类，用于绑定数据
    public class LoginViewModel {
        private UserModel _user;
        public UserModel User
        {
            get {
                if (_user == null)
                {
                    _user = new UserModel();
                }
                return _user;
            }
            set {
                _user = value;
                //OnPropertyChanged("LoginViewModel");
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        private Window _window;
        public LoginViewModel(Window window)
        {
            _window = window;
        }




        public void Regist_Click(object parameter)
        {
            MessageBox.Show("注册成功");
        }
        public void Password_Click(object parameter)
        {
            MessageBox.Show("忘记密码");
        }

        private bool CanExecute(object parameter)
        {
            return true;
        }

        //public RelayCommand LoginAction
        //{
        //    get
        //    {
        //        return new RelayCommand(Login_Click, CanExecute);
        //    }
        //}
        public RelayCommand RegistAction
        {
            get
            {
                return new RelayCommand(Regist_Click, CanExecute);
            }
        }

        public RelayCommand PasswordAction
        {
            get
            {
                return new RelayCommand(Password_Click, CanExecute);
            }
        }
    }


    /// <summary>
    /// 命令类
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    //public class PasswordBoxHelper
    //{
    //    public static string GetMyPassword(DependencyObject obj)
    //    {
    //        return (string)obj.GetValue(MyPasswordProperty);
    //    }

    //    public static void SetMyPassword(DependencyObject obj, string value)
    //    {
    //        obj.SetValue(MyPasswordProperty, value);
    //    }

    //    public static readonly DependencyProperty MyPasswordProperty =
    //        DependencyProperty.RegisterAttached("MyPassword",
    //            typeof(string), typeof(PasswordBoxHelper),
    //            new FrameworkPropertyMetadata(string.Empty, OnPasswordChanged));


    //    public static bool GetIsEnableBind(DependencyObject obj)
    //    {
    //        return (bool)obj.GetValue(IsEnableBindProperty);
    //    }
    //    public static void SetIsEnableBind(DependencyObject obj, bool value)
    //    {
    //        obj.SetValue(IsEnableBindProperty, value);
    //    }
    //    public static readonly DependencyProperty IsEnableBindProperty =
    //        DependencyProperty.RegisterAttached("IsEnableBind",
    //            typeof(bool), typeof(PasswordBoxHelper),
    //            new FrameworkPropertyMetadata(false, OnPasswordPropertyChanged));

    //    //private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPrppertyChange )
    //}

    //class CustomButton111： Button
    //{
    //}
    //class CustomButton： Button
    //{
    //    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CustomButton), new PropertyMetadata(null, OnCommandChanged));
    //    public ICommand Command
    //{
    //    get { return (ICommand)GetValue(CommandProperty); }
    //    set { SetValue(CommandProperty, value); }
    //}

    //    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //{
    //    CustomButton button = d as CustomButton;
    //    if (button != null)
    //    {
    //        button.OnCommandChanged(e);
    //    }
    //}

    //    private void OnCommandChanged(DependencyPropertyChangedEventArgs e)
    //{
    //    if (e.OldValue != null)
    //    {
    //        (e.OldValue as ICommand).CanExecuteChanged -= CanExecuteChanged;
    //    }
    //    if (e.NewValue != null)
    //    {
    //        (e.NewValue as ICommand).CanExecuteChanged += CanExecuteChanged;
    //    }
    //}

    //    private void CanExecuteChanged(object sender, EventArgs e)
    //{
    //    if (Command != null)
    //    {
    //        IsEnabled = Command.CanExecute(CommandParameter);
    //    }
    //}

    //    public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(CustomButton), new PropertyMetadata(null, OnCommandParameterChanged));

    //    public object CommandParameter
    //{
    //    get { return GetValue(CommandParameterProperty); }
    //    set { SetValue(CommandParameterProperty, value); }
    //}

    //    private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //{
    //    CustomButton button = d as CustomButton;
    //    if (button != null)
    //    {
    //        button.OnCommandParameterChanged(e);
    //    }
    //}

    //    private void OnCommandParameterChanged(DependencyPropertyChangedEventArgs e)
    //{
    //    if (Command != null)
    //    {
    //        IsEnabled = Command.CanExecute(CommandParameter);
    //    }
    //}

    //    protected override void OnClick()
    //    {
    //            if (Command != null)
    //            {
    //                Command.Execute(CommandParameter);
    //            }
    //    }
    //}

}

