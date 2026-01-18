using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Domain.Repository.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<PagedResult<AuthorsODTO>> GetAllAuthors(int page, int pageSize);
        Task<AuthorsODTO> GetSingleAuthor(int authorId);
        Task<string> GetAuthorEmail(int authorId);
    }
}
