﻿using HexoBlog.Model;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
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


        public async Task<MarkupString> GetArticleContentAsync(string path)
        {
            try
            {
                Debug.WriteLine($"GetArticleContentAsync {path}");
                var request = new RestRequest($"{path}", Method.Get);

                var response = _restClient.Execute<string>(request);

                var options = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };


                //if (response.IsCompleted)
                //{

                await Task<string>.Run(() =>
                {
                    var data = response.Content;
                    if (!string.IsNullOrEmpty(data))
                    {
                        articleContent = JsonConvert.DeserializeObject<Article>(data, options)?.Content!;
                    }

                });

                return new MarkupString(HtmlCleaner.RemoveImages(articleContent));

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
