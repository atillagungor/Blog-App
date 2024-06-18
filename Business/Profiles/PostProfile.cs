using AutoMapper;
using Business.Dtos.Requests.Post;
using Business.Dtos.Responses.Post;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Post, CreatePostRequest>().ReverseMap();
        CreateMap<Post, CreatedPostResponse>().ReverseMap();

        CreateMap<Post, UpdatePostRequest>().ReverseMap();
        CreateMap<Post, UpdatedPostResponse>().ReverseMap();

        CreateMap<Post, DeletePostRequest>().ReverseMap();
        CreateMap<Post, DeletedPostResponse>().ReverseMap();

        CreateMap<IPaginate<Post>, Paginate<GetPostRespone>>().ReverseMap();
        CreateMap<Post, GetPostRespone>().ReverseMap();
    }
}