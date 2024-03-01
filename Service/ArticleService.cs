﻿using HexoBlog.Model;
using RestSharp;
using System.Diagnostics;
using System.Text.Json;

namespace HexoBlog.Service
{
    internal class ArticleService
    {
        private readonly RestClient _restClient;
        public ArticleService()
        {
            _restClient = new RestClient("https://www.60points.com");
        }

        private string articleContent;


        public async Task<string> GetArticleContentAsync(string path)
        {
            try
            {
                Debug.WriteLine($"GetArticleContentAsync {path}");
                var request = new RestRequest($"api/articles/{path}", Method.Get);

                var response = _restClient.Execute<string>(request);

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };



                //if (response.IsCompleted)
                //{

                await Task<string>.Run(() =>
                {
                    var data = response.Content;
                    if (!string.IsNullOrEmpty(data))
                    {
                        articleContent = JsonSerializer.Deserialize<Article>(data, options)?.Content!;
                    }

                });

                return articleContent;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
