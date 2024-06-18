using AutoMapper;
using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();

        CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

        CreateMap<Category, DeleteCategoryRequest>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

        CreateMap<IPaginate<Category>, Paginate<GetCategoryResponse>>().ReverseMap();
        CreateMap<Category, GetCategoryResponse>().ReverseMap();
    }
}