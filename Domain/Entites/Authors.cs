namespace pressAgency.Domain.Entites
{
    public class Authors
    {
        public int AuthorId { get; set; }
        public required string Email { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Posts>? Posts { get; set; }
        public virtual ICollection<PostsLock>? PostsLocks { get; set; }
    }
}
