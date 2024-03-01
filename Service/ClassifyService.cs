using HexoBlog.Model;
using RestSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
namespace HexoBlog.Service
{
    public class ClassifyService
    {
        public ObservableCollection<CategoryItem> Categories { get; set; } = new ObservableCollection<CategoryItem>();
        public ObservableCollection<CategoryItem> Tags { get; set; } = new ObservableCollection<CategoryItem>();

        public CategoryItem TagsInfo { get; set; } = new CategoryItem();
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

        public async Task LoadTagArticleAsync(string json)
        {
            try
            {

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
                    TagsInfo = JsonConvert.DeserializeObject<CategoryItem>(data, options)!;
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
