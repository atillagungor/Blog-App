using Business.Dtos.Requests.Post;
using Business.Dtos.Responses.Post;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IPostService
{
    Task<CreatedPostResponse> AddAsync(CreatePostRequest createPostRequest);
    Task<IPaginate<GetPostRespone>> GetListPosts(PageRequest pageRequest);
    Task<DeletedPostResponse> DeleteById(Guid id);
    Task<DeletedPostResponse> DeleteAsync(DeletePostRequest deletePostRequest);
    Task<DeletedPostResponse> DeleteByMailAsync(string email);
    Task<UpdatedPostResponse> UpdateAsync(UpdatePostRequest updatePostRequest);
}