using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Domain.Repository.Interfaces
{
    public interface IAuthorsRepository
    {
        public Task<PagedResult<AuthorsODTO>> GetAllAuthors(int page, int pageSize);
        public Task<AuthorsODTO> GetSingleAuthor(int authorId);
    }
}
