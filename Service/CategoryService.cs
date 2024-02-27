using HexoBlog.Model;
using RestSharp;
using System.Collections.ObjectModel;
using System.Text.Json;
namespace HexoBlog.Service
{
    public class CategoryService
    {
        public ObservableCollection<CategoryItem> Categories { get; set; } = new ObservableCollection<CategoryItem>();
        private readonly RestClient _restClient;
        public CategoryService()
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
    }
}
