using AutoMapper;
using Business.Dtos.Requests.Like;
using Business.Dtos.Responses.Like;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class LikeProfile : Profile
{
    public LikeProfile()
    {
        CreateMap<Like, CreateLikeRequest>().ReverseMap();
        CreateMap<Like, CreatedLikeResponse>().ReverseMap();

        CreateMap<IPaginate<Like>, Paginate<GetLikeResponse>>().ReverseMap();
        CreateMap<Like, GetLikeResponse>().ReverseMap();
    }
}