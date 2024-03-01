using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexoBlog.Service
{
    internal class HtmlCleaner
    {
        public static string RemoveImages(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // 获取所有的img节点，并将它们添加到一个新的List中  
            var imgNodesToRemove = new List<HtmlNode>();
            foreach (var imgNode in doc.DocumentNode.Descendants("img"))
            {
                imgNodesToRemove.Add(imgNode);
            }

            // 遍历新的List并移除img节点  
            foreach (var imgNode in imgNodesToRemove)
            {
                imgNode.Remove();
            }

            // 返回清理后的HTML字符串  
            return doc.DocumentNode.OuterHtml;
        }
    }
}
