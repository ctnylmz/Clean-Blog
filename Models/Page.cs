namespace Clean_Blog.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string? Img { get; set; }
        public string? BigTitle { get; set; }
        public string? SmallTitle { get; set; }
        public string? Description { get; set; }
        public int? PageNumber { get; set; }
    }
}
