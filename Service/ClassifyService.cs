using HexoBlog.Model;
using RestSharp;
using System.Collections.ObjectModel;
using System.Text.Json;
namespace HexoBlog.Service
{
    public class ClassifyService
    {
        public ObservableCollection<CategoryItem> Categories { get; set; } = new ObservableCollection<CategoryItem>();
        public ObservableCollection<CategoryItem> Tags { get; set; } = new ObservableCollection<CategoryItem>();
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

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                Categories.Clear(); // 清除旧数据  


                //if (response.IsCompleted)
                //{

                await Task.Run(() =>
                {
                    var data = response.Content;
                    Categories = JsonSerializer.Deserialize<ObservableCollection<CategoryItem>>(data, options)!;
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

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                Tags.Clear(); // 清除旧数据  


                //if (response.IsCompleted)
                //{

                await Task.Run(() =>
                {
                    var data = response.Content;
                    Tags = JsonSerializer.Deserialize<ObservableCollection<CategoryItem>>(data, options)!;
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
