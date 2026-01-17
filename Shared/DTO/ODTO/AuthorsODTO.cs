namespace pressAgency.Shared.DTO.ODTO
{
    public class AuthorsODTO
    {
        public int AuthorId { get; set; }
        public string? AuthorEmail { get; set; }
        public string? AuthorName { get; set; }
        public int? PostsByAuthor { get; set; }
    }
}
