using Newtonsoft.Json;

namespace HexoBlog.Model
{
    public class CategoryItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Count { get; set; }
        [JsonProperty("postlist")]
        public List<Article> PostList { get; set; } = new List<Article>();
    }


  



}
