using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Domain.Repository.Extensions;
using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Shared.Constants;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Domain.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly PressDbContext _dbContext;

        public AuthorsRepository(PressDbContext pressDbContext)
        {
            _dbContext = pressDbContext;
        }

        public async Task<PagedResult<AuthorsODTO>> GetAllAuthors(int page, int pageSize)
        {
            page = page != 0 ? page : Constants.DefaultPage;
            pageSize = pageSize != 0 ? pageSize : Constants.DefaultPageSize;

            return await _dbContext.Authors
                                   .AsNoTracking()
                                   .Select(x => new AuthorsODTO
                                   {
                                       AuthorId = x.AuthorId,
                                       AuthorEmail = x.Email,
                                       AuthorName = x.Name,
                                       PostsByAuthor = x.Posts.Count(p => p.AuthorId == x.AuthorId)
                                   })
                                   .Paginate<AuthorsODTO>(page, pageSize);
        }

        public async Task<string> GetAuthorEmail(int authorId)
        {
            var authorEmail = await _dbContext.Authors
                                              .AsNoTracking()
                                              .Where(x => x.AuthorId == authorId)
                                              .Select(x => x.Email)
                                              .FirstOrDefaultAsync();

            return authorEmail ?? string.Empty;
        }

        public async Task<AuthorsODTO> GetSingleAuthor(int authorId)
        {
            var author = await _dbContext.Authors
                                         .AsNoTracking()
                                         .Where(x => x.AuthorId == authorId)
                                         .Select(x => new AuthorsODTO
                                         {
                                             AuthorId = x.AuthorId,
                                             AuthorEmail = x.Email,
                                             AuthorName = x.Name,
                                             PostsByAuthor = x.Posts.Count(p => p.AuthorId == x.AuthorId)
                                         })
                                         .FirstOrDefaultAsync();

            return author ?? new AuthorsODTO();
        }
    }
}
