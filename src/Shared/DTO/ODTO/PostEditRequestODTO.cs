namespace pressAgency.Shared.DTO.ODTO
{
    public class PostEditRequestODTO
    {
        public PostsODTO Post { get; set; } = new();
        public string LockState { get; set; } = string.Empty;
        public PostLockStatusODTO Lock { get; set; } = new();
    }

    public class PostLockStatusODTO
    {
        public int PostLockId { get; set; }
        public string? LockedAt { get; set; }
        public string? LockExpiresAt { get; set; }
        public bool LockedByCurrentUser { get; set; }
        public string? LockedBy { get; set; }
    }
}
