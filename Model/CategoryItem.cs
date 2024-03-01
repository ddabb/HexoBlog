using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace HexoBlog.Model
{
    public class CategoryItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Count { get; set; }
        [JsonProperty("postlist")]
        public ObservableCollection<Article> PostList { get; set; } = new ObservableCollection<Article>();
    }






}
