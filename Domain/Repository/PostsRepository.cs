using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Domain.Repository.Extensions;
using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Shared;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.ODTO;

namespace pressAgency.Domain.Repository
{
    public class PostsRepository : IPostsRepository
    {
        private readonly PressDbContext _dbContext;

        public PostsRepository(PressDbContext pressDbContext)
        {
            _dbContext = pressDbContext;
        }

        public async Task<PagedResult<PostsODTO>> GetAllPosts(int page, int pageSize)
        {
            page = page != 0 ? page : Constants.DefaultPage;
            pageSize = pageSize != 0 ? pageSize : Constants.DefaultPageSize;

            return await _dbContext.Posts
                                   .AsNoTracking()
                                   .Include(x => x.Author)
                                   .Select(x => new PostsODTO
                                   {
                                       PostId = x.PostId,
                                       Title = x.Title,
                                       Content = x.Content,
                                       DatePublished = x.CreatedAt.ToLocalTime()
                                                                  .ToString("dd-MM-yyyy HH:mm"),
                                       LastUpdated = x.UpdatedAt.ToLocalTime()
                                                                .ToString("dd-MM-yyyy HH:mm"),
                                       Author = x.Author.Name
                                   })
                                   .Paginate(page, pageSize);
        }

        public async Task<PostsODTO> GetSinglePost(int postId)
        {
            var post = await _dbContext.Posts
                                       .AsNoTracking()
                                       .Include(x => x.Author)
                                       .Select(x => new PostsODTO
                                       {
                                           PostId = x.PostId,
                                           Title = x.Title,
                                           Content = x.Content,
                                           DatePublished = x.CreatedAt.ToLocalTime()
                                                                      .ToString("dd-MM-yyyy HH:mm"),
                                           LastUpdated = x.UpdatedAt.ToLocalTime()
                                                                    .ToString("dd-MM-yyyy HH:mm"),
                                           Author = x.Author.Name
                                       })
                                       .FirstOrDefaultAsync(x => x.PostId == postId);

            return post ?? new PostsODTO();
        }
    }
}
