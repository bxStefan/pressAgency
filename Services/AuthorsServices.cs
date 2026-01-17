using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Services.Interfaces;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Services
{
    public class AuthorsServices : IAuthorsServices
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsServices(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public Task<PagedResult<AuthorsODTO>> GetAllAuthors(int page, int pageSize)
        {
            return _authorsRepository.GetAllAuthors(page, pageSize);
        }

        public Task<AuthorsODTO> GetSingleAuthor(int authorId)
        {
            return _authorsRepository.GetSingleAuthor(authorId);
        }
    }
}
