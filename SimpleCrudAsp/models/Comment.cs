namespace SimpleCrudAsp.models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int? PostId { get; set; }
        public Post? Post { get; set; } = null!;

        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
