using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Post;
using Business.Dtos.Responses.Post;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        private readonly IMapper _mapper;

        public PostManager(IPostDal postDal, IMapper mapper)
        {
            _postDal = postDal;
            _mapper = mapper;
        }

        public async Task<CreatedPostResponse> AddAsync(CreatePostRequest createPostRequest)
        {
            var newPost = new Post
            {
                Content = createPostRequest.Content,
                Title = createPostRequest.Title,
                CreatedDate = DateTime.UtcNow,
                UserId = createPostRequest.UserId,
                CategoryId = createPostRequest.CategoryId
            };

            await _postDal.AddAsync(newPost);

            return _mapper.Map<CreatedPostResponse>(newPost);
        }

        public async Task<UpdatedPostResponse> UpdateAsync(UpdatePostRequest updatePostRequest)
        {
            var post = await _postDal.GetAsync(p => p.Id == updatePostRequest.Id);

            if (post == null)
            {
                throw new BusinessException("Post not found.", "PostNotFoundError");
            }

            post.Content = updatePostRequest.Content;
            post.Title = updatePostRequest.Title;
            post.CategoryId = updatePostRequest.CategoryId;

            var updatedPost = await _postDal.UpdateAsync(post);

            return _mapper.Map<UpdatedPostResponse>(updatedPost);
        }

        public async Task<DeletedPostResponse> DeleteAsync(DeletePostRequest deletePostRequest)
        {
            var post = await _postDal.GetAsync(p => p.Id == deletePostRequest.Id);

            if (post == null)
            {
                throw new BusinessException("Post not found.", "PostNotFoundError");
            }

            var deletedPost = await _postDal.DeleteAsync(post, true);

            return _mapper.Map<DeletedPostResponse>(deletedPost);
        }

        public async Task<DeletedPostResponse> DeleteById(Guid id)
        {
            var post = await _postDal.GetAsync(p => p.Id == id);

            if (post == null)
            {
                throw new BusinessException("Post not found.", "PostNotFoundError");
            }

            var deletedPost = await _postDal.DeleteAsync(post, true);

            return _mapper.Map<DeletedPostResponse>(deletedPost);
        }

        public async Task<DeletedPostResponse> DeleteByMailAsync(string email)
        {
            var post = await _postDal.GetAsync(p => p.User.Email == email);

            if (post == null)
            {
                throw new BusinessException("Post not found.", "PostNotFoundError");
            }

            var deletedPost = await _postDal.DeleteAsync(post, true);

            return _mapper.Map<DeletedPostResponse>(deletedPost);
        }

        public async Task<IPaginate<GetPostRespone>> GetListPosts(PageRequest pageRequest)
        {
            var posts = await _postDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);

            return _mapper.Map<Paginate<GetPostRespone>>(posts);
        }
    }
}