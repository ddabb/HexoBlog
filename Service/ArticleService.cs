
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Xss;
using HexoBlog.Model;
using Microsoft.AspNetCore.Components.Web;

namespace HexoBlog.Service
{
    internal class ArticleService
    {


        private string articleContent;


        public async Task GetArticleContentAsync(string path)
        {
            try
            {
                try
                {
                    //var response = await Http.GetAsync($"articles/{Path}");
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var content = await response.Content.ReadFromJsonAsync<Article>();
                    //    articleContent = HtmlSanitizer.Sanitize(content.Content); // 假设你有一个HtmlSanitizer类来清理HTML内容
                    //}
                    //else
                    //{
                    //    // 处理错误情况
                    //}
                }
                catch (HttpRequestException ex)
                {
                    // 处理异常
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
