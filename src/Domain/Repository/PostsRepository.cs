using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Domain.Entites;
using pressAgency.Domain.Repository.Extensions;
using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Shared.Constants;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.IDTO;
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

        public async Task<bool> CheckForExisitingPost(string postName)
        {
            return await _dbContext.Posts.AnyAsync(x => x.Title.ToLower().Equals(postName));
        }

        public async Task<string> CreatePost(PostsIDTO newPost, int authorId)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                Posts post = new()
                {
                    Title = newPost.Title.Trim(),
                    Content = newPost.Content.Trim(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    AuthorId = authorId
                };

                _dbContext.Posts.Add(post);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                return "Fail";
            }

            return "Success";
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
                                       Author = x.Author.Name,
                                       LockedForEdit = x.PostsLocks.Any(pl => pl.PostId == x.PostId &&
                                                                        pl.LockExpiresAt > DateTime.UtcNow)
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
                                           Author = x.Author.Name ?? "Redaction",
                                           LockedForEdit = x.PostsLocks.Any(pl => pl.PostId == x.PostId &&
                                                                            pl.LockExpiresAt > DateTime.UtcNow)
                                       })
                                       .FirstOrDefaultAsync(x => x.PostId == postId);

            return post ?? new PostsODTO();
        }
    }
}
