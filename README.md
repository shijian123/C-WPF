C# 是一个现代的、通用的、面向对象的编程语言，它是由微软（Microsoft）开发的，由 Ecma 和 ISO 核准认可的。



### C#的基础代码

#### 数值

```
var num1 = 111;
var num2 = 22;

Console.WriteLine("请输入你的年龄:");
string ageStr = Console.ReadLine();
int age = 0;
// 输入指定规则的年龄值
while (true)
{
    try
    {
        age = int.Parse(ageStr);
        Console.WriteLine("age:" + age);
        break;
    }
    catch (FormatException e)
    {
        Console.WriteLine("请输入一个正确的年龄（必须为数字）");
        ageStr = Console.ReadLine();
    }
}

```

#### 字符串

```
var str1 = "Hello";
var str2 = @"World 
adsfkj 
sdfkj";

Console.WriteLine(str1 + " " + str2 + num1 + num2 + "\n");
Console.ReadKey(); // 等待用户按键

Console.WriteLine(addString("str1", "str2") + "\n");

// 定义方法
string addString(string str1, string str2)
{
    return str1 + " " + str2;
}

```

#### 数组

```
int[] list1 = [1, 2, 3];
Console.WriteLine("list1:" + list1[1]);

List<string> names = new List<string>();
names.Add("name1");
names.Add("name2");
names.Add("name3");
Console.WriteLine(names[1]);

```

#### 字典

```
Dictionary<string, string> dict = new Dictionary<string, string>();
dict.Add("key1", "value1");
dict["key2"] = "value2121";
Console.WriteLine(dict["key2"]);

```

#### 对象

```
HeroModel hero1 = new HeroModel("hero1", 1001, 1010, 101, 110, 101, 11, 10);
HeroModel hero2 = new HeroModel("hero2", 100, 100, 10, 10, 10, 1, 0);
hero1.showInfo();
hero2.showInfo();

hero1.attack(hero2);
hero1.defend(hero2);

hero1.showInfo();
hero2.showInfo();

Console.ReadKey();


class HeroModel
{
    // 属性默认时private

    public string name;
    public int hp;
    public int mp;
    public int atk;
    public int def;
    public int spd;
    public int level;
    public int exp;
    public int maxHp;
    public int maxMp;
    public int maxExp;
    public int maxLevel;
    public int maxAtk;
    public int maxDef;
    public int maxSpd;

    public HeroModel(string name, int hp, int mp, int atk, int def, int spd, int level, int exp)
    {
        this.name = name;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.def = def;
        this.spd = spd;
        this.level = level;
        this.exp = exp;
        this.maxHp = 100;
        this.maxMp = 100;
        this.maxExp = 100;
        this.maxLevel = 100;
        this.maxAtk = 100;
        this.maxDef = 100;
        this.maxSpd = 100;
    }

    public void levelUp()
    {
        if (this.exp >= this.maxExp)
        {
            this.level++;
            this.exp = 0;
            this.maxExp = this.maxExp * 2;
            this.maxHp = this.maxHp + 10;
            this.maxMp = this.maxMp + 10;
            this.maxAtk = this.maxAtk + 10;
            this.maxDef = this.maxDef + 10;
            this.maxSpd = this.maxSpd + 10;
        }
    }

    public void attack(HeroModel hero)
    {
        Console.WriteLine(this.name + "攻击了" + hero.name);
        hero.hp = hero.hp - this.atk;
    }

    public void defend(HeroModel hero)
    {
        Console.WriteLine(this.name + "抵挡了" + hero.name + "的攻击");
        this.hp = this.hp - hero.atk;
    }

    public void showInfo()
    {
        Console.WriteLine("当前英雄:" + this.name);
        Console.WriteLine("hp:" + this.hp);
        Console.WriteLine("mp:" + this.mp);
        Console.WriteLine("atk:" + this.atk);
        Console.WriteLine("def:" + this.def);
        Console.WriteLine("spd:" + this.spd);
        Console.WriteLine("level:" + this.level);
        Console.WriteLine("exp:" + this.exp);
        Console.WriteLine("maxHp:" + this.maxHp);
        Console.WriteLine("maxMp:" + this.maxMp);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");

    }
}


```


#### 接口、继承

```

using System;

interface IMyInterface
{
        // 接口成员
    void MethodToImplement();
}

class InterfaceImplementer : IMyInterface
{
    static void Main()
    {
        InterfaceImplementer iImp = new InterfaceImplementer();
        iImp.MethodToImplement();
    }

    public void MethodToImplement()
    {
        Console.WriteLine("MethodToImplement() called.");
    }
}

class BaseClass
{
    public void SomeMethod()
    {
        // Method implementation
    }
}

class DerivedClass : BaseClass
{
    public void AnotherMethod()
    {
        // Accessing base class method
        base.SomeMethod();
        
        // Method implementation
    }
}
```

#### 命名空间

```
using System;
using first_space;
using second_space;

namespace first_space
{
   class abc
   {
      public void func()
      {
         Console.WriteLine("Inside first_space");
      }
   }
}
namespace second_space
{
   class efg
   {
      public void func()
      {
         Console.WriteLine("Inside second_space");
      }
   }
}   
class TestClass
{
   static void Main(string[] args)
   {
      abc fc = new abc();
      efg sc = new efg();
      fc.func();
      sc.func();
      Console.ReadKey();
   }
}
```

#### 多线程

```
// 多线程应用
 using System;
 using System.Threading;

 namespace MultithreadingApplication
{
    class ThreadCreationProgram
    {
        public static void CallToChildThread()
        {
            Console.WriteLine("Child thread starts");
        }

        static void Main(string[] args)
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");
            Thread childThread = new Thread(childref);
            childThread.Start();
            Console.ReadKey();
        }
    }
}
```

### WPF的学习

#### 搭建登录页面
```
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="Auto"/>
        <RowDefinition />

    </Grid.RowDefinitions>

    <TextBlock Text="首都图书馆" FontSize="20" HorizontalAlignment="Center" />
    <StackPanel Grid.Row="1" Background="#0078d4">
        <TextBlock Text="欢迎登录" FontSize="22" HorizontalAlignment="Center" Margin="5" Foreground="White"/>
    </StackPanel>
    <Grid Grid.Row="2"  Grid.RowSpan="2" HorizontalAlignment="Center" Margin="0,20,0,0">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        
        <Label Content="用户名" FontSize="20"  VerticalAlignment="Center" HorizontalAlignment="Right" Margin="0,0,10,0"/>
        <TextBox Text="{Binding User.username, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay }"  FontSize="20" Width="200" Grid.Column="1" VerticalAlignment="Center" HorizontalAlignment="Left"/>

        <Label Content="密码" FontSize="20" Grid.Row="1"  VerticalAlignment="Center" HorizontalAlignment="Right" Margin="0,0,10,0"/>
        <PasswordBox x:Name="txtPwd" Password="" FontSize="20" Width="200" Grid.Row="1" Grid.Column="1" VerticalAlignment="Center" HorizontalAlignment="Left"/>

        <Button Content="登录" FontSize="20" Width="200" Grid.Row="2" Grid.ColumnSpan="2" Click="Login_Click" HorizontalAlignment="Center" Margin="0,30,0,0"/>
        <Button Content="注册" FontSize="20"   Width="200" Grid.Row="3" Grid.ColumnSpan="2" Command="{Binding RegistAction}" HorizontalAlignment="Center" Margin="0,10,0,0"/>
        <Button Content="忘记密码" FontSize="20" Width="200"  Grid.Row="4" Grid.ColumnSpan="2" Command="{Binding PasswordAction}"  HorizontalAlignment="Center" Margin="0,10,0,0"/>

    </Grid>

</Grid>
```

#### 列表页

```
// UI页面
 <Grid Background="White">
     <Grid.RowDefinitions>
         <RowDefinition Height="Auto"/>
         <RowDefinition Height="Auto"/>
         <RowDefinition />
     </Grid.RowDefinitions>
     <TextBox Text="列表" FontSize="24" HorizontalAlignment="Center" BorderThickness="0"/>
     <ListView x:Name="myListView" ItemsSource="{Binding dataList}" Grid.Row="1" MouseDoubleClick="ListView_MouseDoubleClick">
         <ListView.ItemTemplate>
             <DataTemplate>
                 <StackPanel Orientation="Horizontal">
                     <Rectangle Width="100" Height="100" RadiusX="8" RadiusY="8">
                         <Rectangle.Fill >
                             <ImageBrush ImageSource="{Binding ImgUrl}" Stretch="UniformToFill" AlignmentX="Center" AlignmentY="Center" />
                         </Rectangle.Fill>
                     </Rectangle>
                     <StackPanel Orientation="Vertical" VerticalAlignment="Center" Margin="10,0">
                         <TextBlock Text="{Binding Title}" FontSize="20" VerticalAlignment="Top" Margin="0,10,0,0" />
                         <TextBlock Text="{Binding Name}" FontSize="20"  VerticalAlignment="Bottom" Margin="0,10,0,0" />
                     </StackPanel>
                     
                 </StackPanel>
             </DataTemplate>
         </ListView.ItemTemplate>
     </ListView>
     
 </Grid>
 
 
 // 逻辑页面
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

```

#### 网络请求页面

包括Get、Post请求（超时限制、请求头、请求体、手动设置Content-Type头、异常处理、接口响应），并针对JSON数据进行解析转Model

```
namespace WpfApp2.Home
{
    /// <summary>
    /// Home_Requesage.xaml 的交互逻辑
    /// </summary>
    public partial class Home_RequestPage : Page
    {
        List<CYCoverImageModel> imgList { set; get; }
        HeroPostDetailModel heroPostDetailModel { set; get; }
        private Random random = new Random(); // 声明并初始化 Random 实例

        public Home_RequestPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void RequestGetData_Click(object sender, RoutedEventArgs e)
        {
            heroPostDetailModel = null;
            GetRequestAsync();
        }

        private void RequestPostData_Click(object sender, RoutedEventArgs e)
        {
            PostRequestAsync();
            //Post2RequestAsync();
        }

        private void ChangeImageData_Click(object sender, RoutedEventArgs e)
        {
            if (heroPostDetailModel != null && heroPostDetailModel.postContent.Count > 0)
            {
                // https://herobox-cdn.yingxiong.com/forum/test/1720580699008585336.jpg
                // 从 imgList 中随机取一个 model
                int index = random.Next(heroPostDetailModel.postContent.Count);
                HeroPostContentModel randomModel = heroPostDetailModel.postContent[index];
                var imgUrl = "";
                if (randomModel.contentType == "2")
                {
                    imgUrl = randomModel.url;
                } else
                {
                    imgUrl = "https://herobox-cdn.yingxiong.com/forum/test/1720580699008585336.jpg";
                }
                coverImgUrlText.Text = imgUrl;
                // 设置图片的 URL
                coverImg.Source = new BitmapImage(new Uri(imgUrl));
            } else if (imgList != null && imgList.Count > 0)
            {
                // 从 imgList 中随机取一个 model
                int index = random.Next(imgList.Count);
                CYCoverImageModel randomModel = imgList[index];
                coverImgUrlText.Text = randomModel.img;
                // 设置图片的 URL
                coverImg.Source = new BitmapImage(new Uri(randomModel.img));
            }
            else
            {
                MessageBox.Show("图片列表为空，请先获取数据。");
            }
            
        }


        private async Task GetRequestAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("http://service.aibizhi.adesk.com/v1/lightwp/vertical?adult=0&appid=com.lovebizhi.ipad&appver=5.1&appvercode=64&channel=ipicture&first=1&lan=zh-Hans-CN&limit=30&order=mixin&skip=0&sys_model=iPhone&sys_name=iOS&sys_ver=11.3").Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    showJsonText.Text = content;

                    // 解析json数据
                    //CYCoverImageModel coverImageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<CYCoverImageModel>(content["res"["vertical"]]);

                    // 解析json数据
                    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(content);
                    var verticalList = jsonResponse["res"]["vertical"].ToString();
                    List<CYCoverImageModel> coverImageModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CYCoverImageModel>>(verticalList);

                    // 将解析后的数据赋值给 imgList
                    imgList = coverImageModels;

                    ChangeImageData_Click(null, null);
                }
            }
        }

        // 异步方法发送POST请求
        private async Task PostRequestAsync()
        {
           
            // 创建HttpClient实例
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(20); // 设置超时时间

                // 创建HttpRequestMessage
                var request = new HttpRequestMessage(HttpMethod.Post, "https://herobox.yingxiong.com:25362/forum/getPostDetail");
                

                // 设置请求体
                var postData = new Dictionary<string, string>
                {
                    { "postId", "592228951112287716" }, // 以字符串形式传递数字
                    { "isOnlyPublisher", "0" },
                    { "showOrderType", "" }

                };

                var requestContent = new FormUrlEncodedContent(postData);
                // 手动设置Content-Type头
                requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                requestContent.Headers.ContentType.CharSet = "utf-8";
                // 添加请求头
                // requestContent.Headers.Add("token", "eyJhbGciOiJIUzUxMiJ9.eyJjcmVhdGVkIjoxNzIwNDkyMjY1NzQxLCJ1c2VySWQiOjM1NTQyNTI1ODk4MDc3Mzc1N30.kIeWb-74hSl0bOQvQlAHOtXIq3G-0ZyvkKJC7Q3Tks6JK7eo64S0E7r-xbSwVol6tUlNMYxYPNWX_HvHmHstjA");
                requestContent.Headers.Add("version", "3.3.0");
                requestContent.Headers.Add("channel", "appstore");
                requestContent.Headers.Add("source", "ios");

                request.Content = requestContent;

                try
                {
                    showJsonText.Text = "开始Post 请求";
                    // 发送POST请求
                    HttpResponseMessage response = await client.SendAsync(request);
                    // 确保响应成功
                    response.EnsureSuccessStatusCode();

                    //// 读取响应内容
                    string responseContent = await response.Content.ReadAsStringAsync();
                    showJsonText.Text = responseContent;

                    // 解析json数据
                    var jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseContent);
                    var postDetailJson = jsonResponse["data"]["postDetail"].ToString();
                    heroPostDetailModel = JsonConvert.DeserializeObject<HeroPostDetailModel>(postDetailJson);

                    ChangeImageData_Click(null, null);
                }
                catch (Exception e)
                {
                    // 捕获所有其他异常
                    showJsonText.Text = "发生异常：" + e.Message;
                }
            }


        }
    }
}


public class CYCoverImageModel
{
    public string preview { get; set; }
    public string thumb { get; set; }
    public string img { get; set; }
    public string rank { get; set; }
    public  CYCoverUserModel user { get; set; }
    public  List<string> tag { get; set; }
    public string id { get; set; }

}

public class CYCoverUserModel
{
    public string name { get; set; }
    public string id { get; set; }
    public string avatar { get; set; }
    public string follower { get; set; }

}

public class HeroPostDetailModel
{
    public string id { get; set; }
    public string gameName { get; set; }
    public string headCodeUrl { get; set; }
    public List<HeroPostContentModel> postContent { get; set; }

    public string postTitle { get; set; }
    public string postTime { get; set; }
    public string postType { get; set; }
    public string postUserId { get; set; }
    public string userName { get; set; }

}

public class HeroPostContentModel
{
    public string content { get; set; }
    public string contentType { get; set; }
    public string url { get; set; }

}

```

#### 数据绑定

分为颜色列表的Model属性绑定以及滑块、文本直接的双向绑定，需注意 textBox1 和 Slider_ValueChanged 已注释

```
/// UI页

<Grid>
    <ListBox x:Name="myList">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <Border Width="10" Height="10" Background="{Binding Code}"></Border>
                    <TextBlock Margin="10,0" Text="{Binding Name}"></TextBlock>
                </StackPanel>

            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>

    <StackPanel Margin="0,150,0,0">
        <!--<Slider x:Name="slider" Margin="5" ValueChanged="Slider_ValueChanged"/>-->
        <Slider x:Name="slider" Margin="5" />
        <TextBox x:Name="textBox1"  Margin="5" Height="20"/>
        <TextBox Text="{Binding ElementName=slider, Path=Value, Mode=OneWay}" Margin="5" Height="20"/>
        <TextBox Text="{Binding ElementName=slider, Path=Value, Mode=OneWayToSource}" Margin="5" Height="20"/>
        <TextBox Text="{Binding ElementName=slider, Path=Value, Mode=TwoWay}" Margin="5" Height="20"/>

    </StackPanel>
</Grid>


/// 逻辑页
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

```



#### MVVM-自定义命令、属性变更通知

为了是代码更加的清晰以及更方便的进行大型项目开发，针对项目需要使用 MVVM 框架，这里简单介绍下

##### 自定义命令

首先定义MyCommand，它的代码比较固定，在viewModel中首先声明 ShowCommand 属性，然后为其赋值 Show() 函数，然后就可以在UI页面中使用自定义命令，调用函数了

```

/// UI页面

<Button Content="Show" Command="{Binding ShowCommand}"/>

/// 逻辑页面
 public Window_NotifyChanged()
 {
     InitializeComponent();
     this.DataContext = new MyViewModel();
 }

/// viewModel页面

public class MyViewModel : MyNotifyPropertyChanged
{
    /// <summary>
    ///  命令事件
    /// </summary>
    public MyCommand ShowCommand { get; set; }

    public MyViewModel()
    {

        ShowCommand = new MyCommand(Show);
    }

    public void Show()
    {
        MessageBox.Show("点击了按钮！");
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
```

##### 属性变更通知

首先定义 MyNotifyPropertyChanged 其代码比较固定，自定义的 viewModel 继承MyNotifyPropertyChanged，并声明相应的属性，并设置 get、set 方法，在 set 方法中添加 OnPropertyChanged() 函数，这样进行属性修改时，可以进行同步操作更新UI层

```

/// UI层
<Grid>
    <StackPanel>
        <TextBox Text="{Binding Name}"/>
        <TextBox Margin="5" Text="{Binding Title}"/>
        <Button Content="Show" Command="{Binding ShowCommand}"/>
    </StackPanel>
    
</Grid>

/// 逻辑层
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
            this.DataContext = new MyViewModel();
       }
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

```


#### 三方MVVM

通过上面的 MVVM 实现的方式可以发现自定义的 MVVM 代码都是比较固定的，所以为了更好的开发，微软推出了官方的 MVVM库 CommunityToolkitMvvm

需要注意的是使用 WeakReferenceMessenger 进行消息注册时，当前的String只能注册一次，如果想针对不同的String进行注册，可以使用 public record MyMessage(string Content);             WeakReferenceMessenger.Default.Register<Window_NotifyChanged, MyMessage> 进行注册

```
// UI页
<Grid>
    <StackPanel>
        <TextBox Text="{Binding Name}"/>
        <TextBox Margin="5" Text="{Binding Title}"/>
        <Button Content="Show" Command="{Binding ShowCommand}"/>
    </StackPanel>
    
</Grid>

// 逻辑页
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
```


###参考资料


[官方文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/tour-of-csharp/)

[CommunityToolkitMvvm 官方文档](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)

[菜鸟教程](https://www.runoob.com/csharp/csharp-tutorial.html)


[丑萌气质狗-人生低谷来学C#](https://www.bilibili.com/video/BV1NA4y1R7vL/?spm_id_from=333.999.0.0&vd_source=6259049de2826160278883355675a331)

[丑萌气质狗-WPF界面开发入门](https://www.bilibili.com/video/BV13D4y1u7XX/?spm_id_from=333.337.search-card.all.click&vd_source=6259049de2826160278883355675a331)

[微软系列技术教程-WPF项目实战合集](https://www.bilibili.com/video/BV1nY411a7T8/?spm_id_from=333.1007.top_right_bar_window_custom_collection.content.click&vd_source=6259049de2826160278883355675a331)

