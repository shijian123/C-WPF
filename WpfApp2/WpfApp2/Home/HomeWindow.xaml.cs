using System;
using System.Collections.Generic;
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
    /// HomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            AddListViewItems();
            
        }

        private void AddListViewItems()
        {
            ListViewItem item1 = new ListViewItem();
            item1.Content = "退出登录";
            item1.MouseDoubleClick += ListViewItem_MouseDoubleClick;
            myListView.Items.Add(item1);

            for (int i = 1; i <= 3; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Content = $"Item {i}";
                item.MouseDoubleClick += ListViewItem_MouseDoubleClick;
                myListView.Items.Add(item);
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            if (sender is ListViewItem item)
            {
                int index = myListView.Items.IndexOf(item);
                if (index == 2)
                {
                    NavigationWindow window = new NavigationWindow();
                    window.Source = new Uri("Home/Home_ListPage.xaml", UriKind.Relative);
                    //window.Navigate(new Uri("Home/Home_ListPage.xaml", UriKind.Relative));
                    window.Show();
                    //MessageBox.Show($"你点击了第三个项: {item.Content}");
                }
                else if (index == 4) 
                {
                    // 获取隐藏的 MainWindow 实例并显示它
                    MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    if (mainWindow != null)
                    {
                        mainWindow.Show();
                        this.Close(); // 关闭当前窗口
                    }
                } else
                {
                    MessageBox.Show(item.Content.ToString()+ index.ToString());
                }

            }

        }
    }
}
