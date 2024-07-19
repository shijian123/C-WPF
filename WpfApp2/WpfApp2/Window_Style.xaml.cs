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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Window_Style.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Style : Window
    {
        private int num1 = 10;
        public Window_Style()
        {
            InitializeComponent();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hello");
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {

            addTitle.Text = "数字：" + (++num1).ToString();
        }
        private void AddButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // 鼠标进入按钮区域时执行的代码
            num1 = 10;
            addTitle.Text = "鼠标在按钮内";
        }

        private void AddButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // 鼠标离开按钮区域时执行的代码
            addTitle.Text = "鼠标不在按钮内";
        }
    }
}
