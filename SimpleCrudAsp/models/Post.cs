using System.ComponentModel.DataAnnotations;

namespace SimpleCrudAsp.models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}
