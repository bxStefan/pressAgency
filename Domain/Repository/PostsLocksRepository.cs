using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Context;
using pressAgency.Domain.Entites;
using pressAgency.Domain.Repository.Interfaces;

namespace pressAgency.Domain.Repository
{
    public class PostsLocksRepository : IPostLockRepository
    {
        private readonly PressDbContext _dbContext;

        public PostsLocksRepository(PressDbContext pressDbContext)
        {
            _dbContext = pressDbContext;
        }

        public async Task<PostsLock> CreateNewLock(int postId, int authorId)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var newLock = new PostsLock
                {
                    PostId = postId,
                    AuthorId = authorId,
                    LockedAt = DateTime.UtcNow,
                    LockExpiresAt = DateTime.UtcNow.AddMinutes(10)
                };

                _dbContext.PostsLocks.Add(newLock);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();

                return newLock;
            }
            catch
            {
                await transaction.RollbackAsync();
                return new PostsLock();
            }
        }

        public async Task DeleteExpiredLock(int postLockId)
        {
            var expiredLock = await _dbContext.PostsLocks.FindAsync(postLockId);

            if(expiredLock != null)
            {
                _dbContext.PostsLocks.Remove(expiredLock);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<PostsLock?> GetCurrentLock(int postId)
        {
            return await _dbContext.PostsLocks.FirstOrDefaultAsync(x => x.PostId == postId);
        }

        public async Task ExtendCurrentLock(PostsLock currentLock)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                currentLock.LockExpiresAt = currentLock.LockExpiresAt.AddMinutes(10);
                _dbContext.PostsLocks.Update(currentLock);

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch 
            {
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}
