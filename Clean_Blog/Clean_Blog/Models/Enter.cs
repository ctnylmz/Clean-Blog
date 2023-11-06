using Microsoft.AspNetCore.Identity;

namespace Clean_Blog.Models
{
    public class Enter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UserId { get; set; }
    }
}
