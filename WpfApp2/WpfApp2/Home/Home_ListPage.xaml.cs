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

namespace WpfApp2.Home
{
    /// <summary>
    /// Home_ListPage.xaml 的交互逻辑
    /// </summary>
    public partial class Home_ListPage : Page
    {
        public List<CYHomeItemModel> dataList { get; set; }
        public Home_ListPage()
        {
            InitializeComponent();
            configMainData();
            this.DataContext = this;

        }

        public void configMainData()
        {
            dataList = new List<CYHomeItemModel>
            {
                new CYHomeItemModel{ Title = "坏的发安德森科技孵化安德森快捷回复卡的时间", Name = "安东尼", ImgUrl = "https://herobox-cdn.yingxiong.com/forum/test/1720580699008585336.jpg"},
                new CYHomeItemModel{ Title = "爱的色放空间打算风口浪尖安德森尽快发货", Name = "唐尼", ImgUrl = "https://herobox-cdn.yingxiong.com/forum/test/1711527607612174908.jpg"},
                new CYHomeItemModel{ Title = "啊撒旦解放和爱的色放计划科技大厦很疯狂", Name = "阿克苏", ImgUrl = "https://herobox-cdn.yingxiong.com/forum/test/1711527607677430255.jpg"},
                new CYHomeItemModel{ Title = "埃达克警方和啊的空间回复卡的手机号发",  Name = "瑞克斯", ImgUrl = "https://herobox-cdn.yingxiong.com/forum/test/1711527607721946394.jpg"}
            };
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = VisualUpwardSearch<ListViewItem>(e.OriginalSource as DependencyObject);

            if (item != null)
            {
                int index = myListView.ItemContainerGenerator.IndexFromContainer(item);
                if (item.Content is CYHomeItemModel itemModel)
                {
                    MessageBox.Show($"你点击了第{index + 1}: {itemModel.Title}");
                }
            }
        }

        // 辅助方法，用于向上搜索特定类型的父元素
        private static T VisualUpwardSearch<T>(DependencyObject source) where T : DependencyObject
        {
            while (source != null && !(source is T))
            {
                source = VisualTreeHelper.GetParent(source);
            }
            return source as T;
        }
    }
}


public class CYHomeItemModel
{
    public string Title { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
}

