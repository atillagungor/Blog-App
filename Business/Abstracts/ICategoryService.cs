using Business.Dtos.Requests.Category;
using Business.Dtos.Responses.Category;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICategoryService
{
    Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest);
    Task<IPaginate<GetCategoryResponse>> GetListCategories(PageRequest pageRequest);
    Task<DeletedCategoryResponse> DeleteById(Guid id);
    Task<DeletedCategoryResponse> DeleteAsync(DeleteCategoryRequest deleteCategoryRequest);
    Task<DeletedCategoryResponse> DeleteByMailAsync(string email);
    Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
}