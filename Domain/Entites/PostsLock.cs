namespace pressAgency.Domain.Entites
{
    public class PostsLock
    {
        public int PostLockId { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public DateTime LockedAt { get; set; }
        public DateTime LockExpiresAt { get; set; }

        public Posts? Post { get; set; }
        public Authors? Author { get; set; } 
    }
}
