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

namespace WpfApp_101.Simple
{
    /// <summary>
    /// Window_Binding.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Binding : Window
    {
        public Window_Binding()
        {
            InitializeComponent();
            List<Color> test = new List<Color>();
            test.Add(new Color() { Code = "#FFB6C1", Name = "浅粉色" });
            test.Add(new Color() { Code = "#FFC0CB", Name = "粉红" });
            test.Add(new Color() { Code = "#DC143C", Name = "深红" });
            test.Add(new Color() { Code = "#FFF0F5", Name = "淡紫红" });

            myList.ItemsSource = test;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBox1.Text = slider.Value.ToString();
        }
    }


    public class Color
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
