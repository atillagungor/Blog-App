using Business.Dtos.Requests.Like;
using Business.Dtos.Responses.Like;

namespace Business.Abstracts
{
    public interface ILikeService
    {
        Task<CreatedLikeResponse> AddAsync(CreateLikeRequest createLikeRequest);
    }
}