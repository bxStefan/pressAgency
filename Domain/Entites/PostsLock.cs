namespace pressAgency.Domain.Entites
{
    public class PostsLock
    {
        public int PostLockId { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public DateTime LockAt { get; set; }
        public DateTime LockedExpiresAt { get; set; }

        public Posts? Post { get; set; }
        public Authors? Author { get; set; } 
    }
}
