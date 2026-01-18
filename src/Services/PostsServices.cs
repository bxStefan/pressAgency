using pressAgency.Domain.Repository.Interfaces;
using pressAgency.Infrastructure.Interfaces;
using pressAgency.Services.Interfaces;
using pressAgency.Shared.DTO.Common;
using pressAgency.Shared.DTO.IDTO;
using pressAgency.Shared.DTO.ODTO;
using static pressAgency.Shared.Enums.LockStateEnum;

namespace pressAgency.Services
{
    public class PostsServices : IPostsServices
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IPostLockRepository _postLockRepository;
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IHttpUserContext _httpUserContext;

        public PostsServices(IPostsRepository postsRepository, 
                             IHttpUserContext httpUserContext, 
                             IPostLockRepository postLockRepository,
                             IAuthorsRepository authorsRepository)
        {
            _postsRepository = postsRepository;
            _httpUserContext = httpUserContext;
            _postLockRepository = postLockRepository;
            _authorsRepository = authorsRepository;
        }

        public async Task<PagedResult<PostsODTO>> GetAllPosts(int page, int pageSize)
        {
            return await _postsRepository.GetAllPosts(page, pageSize);
        }

        public async Task<PostsODTO> GetSinglePost(int postId)
        {
            return await _postsRepository.GetSinglePost(postId);
        }

        public async Task<GenericResponse> CreateNewPost(PostsIDTO newPost)
        {
            int authorId = _httpUserContext.AuthorId;
            var response = new GenericResponse();

            // check if post with same name exists
            var samePostExists = await _postsRepository.CheckForExisitingPost(newPost.Title.Trim().ToLower());

            if (samePostExists)
            {
                response.Status = 400;
                response.Message = "Post already exists";
                return response;
            }

            var createResponse = await _postsRepository.CreatePost(newPost, authorId);

            switch(createResponse)
            {
                case "Success":
                    response.Status = 200;
                    response.Message = "Post created successfully";
                    break;

                case "Fail":
                    response.Status = 500;
                    response.Message = "An error occured while creating the post";
                    break;
            }

            return response;
        }

        public async Task<PostEditRequestODTO> GetPostForEdit(int postId)
        {
            // get requsted post
            var post = await _postsRepository.GetSinglePost(postId);

            // check if post has lock record
            var lockRecord = await _postLockRepository.GetCurrentLock(postId);

            // lock record does not exist, post is free for editing
            if (lockRecord == null)
            {
                // lock post for other users and return lock details
                var newLock = await _postLockRepository.CreateNewLock(postId, _httpUserContext.AuthorId);

                return new PostEditRequestODTO
                {
                    Post = post,
                    LockState = LockState.Created.ToString().ToLower(),
                    Lock = new PostLockStatusODTO
                    {
                        PostLockId = newLock.PostLockId,
                        LockedAt = newLock.LockedAt.ToLocalTime().ToString("dd-MM-yyyy HH:mm"),
                        LockExpiresAt = newLock.LockExpiresAt.ToLocalTime().ToString("dd-MM-yyyy HH:mm"),
                        LockedByCurrentUser = true,
                        LockedBy = _httpUserContext.AuthorEmail
                    }
                };
            }

            // lock expired on current post, free for editing
            if (lockRecord.LockExpiresAt <= DateTime.UtcNow)
            {
                // delete expired lock
                await _postLockRepository.DeleteExpiredLock(lockRecord.PostLockId);

                // lock post for other users and return lock details
                var newLock = await _postLockRepository.CreateNewLock(postId, _httpUserContext.AuthorId);

                return new PostEditRequestODTO
                {
                    Post = post,
                    LockState = LockState.Created.ToString().ToLower(),
                    Lock = new PostLockStatusODTO
                    {
                        PostLockId = newLock.PostLockId,
                        LockedAt = newLock.LockedAt.ToLocalTime().ToString("dd-MM-yyyy HH:mm"),
                        LockExpiresAt = newLock.LockExpiresAt.ToLocalTime().ToString("dd-MM-yyyy HH:mm"),
                        LockedByCurrentUser = true,
                        LockedBy = _httpUserContext.AuthorEmail
                    }
                };
            }

            // post is locked, collect lock details and return status of post

            // check if lock is by current user
            bool byCurrentUser = lockRecord.AuthorId == _httpUserContext.AuthorId;

            string lockedBy = byCurrentUser ? _httpUserContext.AuthorEmail :
                                              (await _authorsRepository.GetAuthorEmail(lockRecord.AuthorId));

            return new PostEditRequestODTO
            {
                Post = post,
                LockState = byCurrentUser ? LockState.Already_Owned.ToString().ToLower() :
                                            LockState.Locked.ToString().ToLower(),
                Lock = new PostLockStatusODTO
                {
                    PostLockId = lockRecord.PostLockId,
                    LockedAt = lockRecord.LockedAt.ToLocalTime().ToString("dd-MM-yyyy HH:mm"),
                    LockExpiresAt = lockRecord.LockExpiresAt.ToLocalTime().ToString("dd-MM-yyyy HH:mm"),
                    LockedByCurrentUser = byCurrentUser,
                    LockedBy = lockedBy
                }
            };
        }

        public async Task<GenericResponse> ExtendPostEditSession(int postId)
        {
            var response = new GenericResponse();

            // get lock
            var lockRecord = await _postLockRepository.GetCurrentLock(postId);

            // lock does not exist, prevent futher operations
            if (lockRecord == null)
            {
                response.Status = 400;
                response.Message = "Edit session for this post is invalid. Expired or not created";

                return response;
            }

            // prevent other users from extending lock
            if (lockRecord.AuthorId != _httpUserContext.AuthorId)
            {
                response.Status = 403;
                response.Message = "You do not have priviledges to edit this post";

                return response;
            }

            // all fine, extend lock
            await _postLockRepository.ExtendCurrentLock(lockRecord);

            response.Status = 200;
            response.Message = "Edit session extended successfully";

            return response;
        }

        public async Task<GenericResponse> SavePost(EditedPostIDTO postToSave)
        {
            // get post
            var post = await _postsRepository.GetSinglePost(postToSave.PostId);

            // Delete should be also locked during editing
            // Since delete is not implemented at all, we are just cheking if valid post is provided to service
            if (post == null) 
            {
                return new GenericResponse
                {
                    Status = 404,
                    Message = "Post does not exist"
                };
            }

            // get lock
            var lockRecord = await _postLockRepository.GetCurrentLock(postToSave.PostId);

            // lock does not exist, prevent futher operations
            if (lockRecord == null)
            {
                return new GenericResponse
                {
                    Status = 400,
                    Message = "Edit session for this post is invalid. Expired or not created"
                };
            }

            // author that did not required this edit session can not operate on save
            if (lockRecord.AuthorId != _httpUserContext.AuthorId)
            {
                return new GenericResponse
                {
                    Status = 403,
                    Message = "You do not have priviledges to edit this post"
                };
            }

            // check if post title is not conflicting with other posts
            var samePostExists = await _postsRepository.CheckForExisitingPostAfterEdit(postToSave.PostId, 
                                                                                       postToSave.Title.Trim().ToLower());

            if (samePostExists)
            {
                return new GenericResponse
                {
                    Status = 400,
                    Message = "Post with same title already exists"
                };
            }

            // all fine, proceed with save
            await _postsRepository.SavePost(postToSave);

            // delete lock after save
            await _postLockRepository.DeleteExpiredLock(lockRecord.PostLockId);

            return new GenericResponse
            {
                Status = 200,
                Message = "Post updated successfully"
            };
        }
    }
}
