using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Services.Interfaces
{
    public interface IAuthorsServices
    {
        public Task<PagedResult<AuthorsODTO>> GetAllAuthors(int page, int pageSize);

        public Task<AuthorsODTO> GetSingleAuthor(int authorId);
    }
}
