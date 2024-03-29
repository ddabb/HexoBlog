﻿using HexoBlog.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

     

        public async Task LoadTagArticleS(string name,string type)
        {
            try
            {
                // 构建RestRequest  
                var request = new RestRequest($"/api/{type}/{name}", Method.Get);

                // 发送请求并处理响应  
                var response = _restClient.Execute<string>(request);

                var options = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                Articles.Clear(); // 清除旧数据  
                await Task.Run(() =>
                {
                    var data = response.Content;
                    Debug.WriteLine("LoadTagArticleAsync" + data);
                    Articles = JsonConvert.DeserializeObject<CategoryItem>(data, options).PostList!;
                });
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
