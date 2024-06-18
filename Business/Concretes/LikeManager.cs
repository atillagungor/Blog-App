using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Like;
using Business.Dtos.Responses.Like;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class LikeManager : ILikeService
{
    IMapper _mapper;
    ILikeDal _likeDal;
    public LikeManager(IMapper mapper, ILikeDal likeDal)
    {
        _mapper = mapper;
        _likeDal = likeDal;
    }
    public async Task<CreatedLikeResponse> AddAsync(CreateLikeRequest createLikeRequest)
    {
        var existingLike = await _likeDal.GetAsync(l => l.UserId == createLikeRequest.UserId && l.PostId == createLikeRequest.PostId);
        if (existingLike != null)
        {
            throw new BusinessException("Bu postu daha önce beğendiniz.", "DuplicateLikeError");
        }
        var newLike = new Like
        {
            UserId = createLikeRequest.UserId,
            PostId = createLikeRequest.PostId,
            CreatedDate = DateTime.UtcNow
        };

        await _likeDal.AddAsync(newLike);

        return _mapper.Map<CreatedLikeResponse>(newLike);
    }
}