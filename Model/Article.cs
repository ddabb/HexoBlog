namespace HexoBlog.Model
{
    public class Article
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Date { get; set; }
        public DateTime Updated { get; set; }
        public bool Comments { get; set; }
        public string Path { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string More { get; set; }
        public List<CategoryItem> Categories { get; set; }
        public List<CategoryItem> Tags { get; set; }
    }
}
