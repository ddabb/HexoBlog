using HexoBlog.Model;
using RestSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;


using System.Net;
namespace HexoBlog.Service
{
    public class ClassifyService
    {
        public ObservableCollection<CategoryItem> Categories { get; set; } = new ObservableCollection<CategoryItem>();
        public ObservableCollection<CategoryItem> Tags { get; set; } = new ObservableCollection<CategoryItem>();

        public ObservableCollection<Article> Articles { get; set; } = new ObservableCollection<Article>();
        private readonly RestClient _restClient;
        public ClassifyService()
        {
            _restClient = new RestClient("https://www.60points.com");
        }
        public async Task LoadCategoriesAsync()
        {
            try
            {

                var request = new RestRequest("/api/categories.json", Method.Get);

                var response = _restClient.Execute<string>(request);

                var options = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                Categories.Clear(); // 清除旧数据  


                await Task.Run(() =>
                {
                    var data = response.Content;
                    Categories = JsonConvert.DeserializeObject<ObservableCollection<CategoryItem>>(data, options)!;
                });

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task LoadTagArticleAsync(NavigationManager nav)
        {
            try
            {

                // 获取当前的 URI
                var uri = nav.Uri;
                var type = "tags";
                var json = "";


                //// 解析查询字符串
                //var queryParameters = new Uri(uri).Query;

                //// 尝试从查询字符串中获取params参数
                //if (queryParameters.TryGetValue("params", out var paramsValues) && paramsValues.Count > 0)
                //{
                //    string encodedJson = paramsValues[0]; // 获取第一个params值

                //    // 对URL编码的JSON字符串进行解码
                //    string decodedJson = System.Net.WebUtility.UrlDecode(encodedJson);

                //    // 反序列化JSON字符串为对象
                //    var articleParams = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(decodedJson);

                //    if (articleParams != null && articleParams.ContainsKey("name") && articleParams.ContainsKey("type"))
                //    {
                //        Name = articleParams["name"];
                //        string type = articleParams["type"];
                //        string decodedString = WebUtility.UrlDecode(Name);
                //        json = decodedString.Split('/').Last();

                //    }
                //}

                var request = new RestRequest($"/api/tags/{json}", Method.Get);

                var response = _restClient.Execute<string>(request);

                var options = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };


                Tags.Clear(); // 清除旧数据  


                //if (response.IsCompleted)
                //{

                await Task.Run(() =>
                {
                    var data = response.Content;
                    Debug.WriteLine("LoadTagArticleAsync" + data);
                    Articles = JsonConvert.DeserializeObject<CategoryItem>(data, options).PostList!;
                });

                //}

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task LoadTagAsync()
        {
            try
            {

                var request = new RestRequest("/api/tags.json", Method.Get);

                var response = _restClient.Execute<string>(request);

                var options = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                Tags.Clear(); // 清除旧数据  


                //if (response.IsCompleted)
                //{

                await Task.Run(() =>
                {
                    var data = response.Content;
                    Tags = JsonConvert.DeserializeObject<ObservableCollection<CategoryItem>>(data, options)!;
                });

                //}

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
