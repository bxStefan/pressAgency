namespace pressAgency.Domain.Entites
{
    public class Posts
    {
        public int PostId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AuthorId { get; set; }

        public Authors? Author { get; set; }
    }
}
