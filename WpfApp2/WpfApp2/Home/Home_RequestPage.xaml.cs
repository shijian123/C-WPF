using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfApp2.Home
{
    /// <summary>
    /// Home_RequestPage.xaml 的交互逻辑
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